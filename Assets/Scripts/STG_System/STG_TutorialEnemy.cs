using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Fungus;

public class STG_TutorialEnemy : MonoBehaviour
{
    public SpriteRenderer image;
    public Image imageThumnail;

    public Slider enemyHPSlider;
    int Max;

    [SerializeField]
    STG_Manager manager;

    private const string ANIM_DAMAGE_TRIGGER = "Damage";

    ReactiveProperty<int> _eHP = new ReactiveProperty<int>();

    [SerializeField]
    private GameObject _explosionPrefab = null;

    [Header("敵の番号。インスペクターで指定する")]
    public int enemyNo;

    [Header("敵の情報。番号で検索して、スクリプタブル・オブジェクトから取得する")]
    public EnemyDataList.EnemyData enemyData;

    private Animator _animator;

    public bool TutorialWhile;
    public bool FlowMessage;
    private STG_TutorialEmiiter tutorialEmiiter;

    [SerializeField]
    Flowchart flowchart;

    public string messageText;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();

        if (manager == null) manager = GameObject.Find("STG_GameManager").GetComponent<STG_Manager>();
        manager._tutorialEnemy = this;
        if (imageThumnail == null) imageThumnail = GameObject.Find("EnemyThumbnail").GetComponent<Image>();
        imageThumnail.sprite = image.GetComponent<SpriteRenderer>().sprite;
        if (enemyHPSlider == null) enemyHPSlider = GameObject.Find("EnemyHP_bar").GetComponent<Slider>();
        enemyHPSlider.value = 100;
        // DataBaseManagerの管理しているスクリプタブル・オブジェクトに敵データを取得しにいく
        enemyData = EnemyDataBaseManager.instance.GetEnemyData(enemyNo);
        Debug.Log(enemyData.enemyName);

        if (TutorialWhile == true)
        {
            tutorialEmiiter = GameObject.Find("TutorialEmiiter0").GetComponent<STG_TutorialEmiiter>();
        }
        if (FlowMessage == true)
        {
            flowchart = GameObject.Find("Gaming").GetComponent<Flowchart>();
        }

        Max = enemyData.maxHp;
        _eHP.Value = enemyData.maxHp;
        _eHP.Where(x => x <= 0)
            .Subscribe(_ => Dead())
            .AddTo(this);
    }
    /// <summary>
    /// プレイヤーの弾が当たった時の処理
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _animator.SetTrigger(ANIM_DAMAGE_TRIGGER);
            _eHP.Value -= collision.GetComponentInParent<IBullet>().BulletAtk;
            Percentage100();
            UbhBullet bullet = collision.GetComponentInParent<UbhBullet>();
            if (bullet != null && bullet.isActive)
            {
                UbhObjectPool.instance.ReleaseBullet(bullet);
            }
        }
    }

    public void Dead()
    {
        imageThumnail.sprite = Resources.Load<Sprite>("hatena");
        Explosion();
        if (TutorialWhile == true)
        {
            tutorialEmiiter._flag = false;
        }
        if (FlowMessage == true)
        {
            flowchart.SendFungusMessage(messageText);
        }
        this.gameObject.SetActive(false);
        ItemDrop();
    }


    public void ItemDrop()
    {
        if (enemyData.dropItemNos.Length ==0) return;
        for (int i = 0; i < enemyData.dropItemNos.Length; i++)
        {
            // アイテムの番号と合致するプレファブのデータを取得する
            GameObject itemPrefab = EnemyDataBaseManager.instance.GetDropItemPrefabDate(enemyData.dropItemNos[i]);    // ☆　追加
            Vector3 pos = transform.position;

            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(pos.x + 1.4f, pos.x - 1.4f);
            Debug.Log(x);
            //取得したプレファブのデータを使ってアイテムを生成する
            Instantiate(itemPrefab, new Vector3(x, pos.y + 0.3f, pos.z), Quaternion.identity);

        }
    }

    private void OnDisable()
    {
        if (manager != null) manager._tutorialEnemy = null;
    }

    public void Explosion()
    {
        if (_explosionPrefab != null)
        {
            Instantiate(_explosionPrefab, transform.position, transform.rotation);
        }
    }

    public Animator GetAnimator()
    {
        return _animator;
    }

    public void MobGameOver()
    {
        this.gameObject.SetActive(false);
    }
    public void Percentage100()
    {
        int currentHealth = _eHP.Value; // 体力の現在の値
        float maxHealth = Max; // 体力の最大値
        float percentage = (currentHealth / maxHealth) * 100; // パーセンテージを計算
        //currentHealth = Mathf.RoundToInt((percentage / 100) * maxHealth); // 100%にした値を計算
        //Debug.Log(currentHealth);
        enemyHPSlider.value = percentage;

    }
}
