using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using KanKikuchi.AudioManager;
using MoreMountains.Feedbacks;
public class STG_Boss : MonoBehaviour
{
    private Vector3 initialScale;

    [SerializeField]
    MMFeedbacks _deadFeadBacks=null;

    public SpriteRenderer image;

    [SerializeField]
    STG_Manager manager;

    [SerializeField]
    STG_GameLevelManager gameLevel;
    [SerializeField]
    GameStateManager gameState;

    [Header("難易度が違うと、HPをプラスする値")]
    public int normal, hard;

    private const string ANIM_DAMAGE_TRIGGER = "Damage";

    public int _eHP;
    bool eHPFlag;

    [Space(20)]
    [SerializeField]
    private GameObject _explosionPrefab = null;

    [SerializeField]
    private GameObject _LastexplosionPrefab = null;

    [Header("敵の番号。インスペクターで指定する")]
    public int enemyNo;

    [Header("敵の情報。番号で検索して、スクリプタブル・オブジェクトから取得する")]
    public EnemyDataList.EnemyData enemyData;

    private Animator _animator;

    private STG_TutorialEmiiter tutorialEmiiter;

    public List<GameObject> objectsList;
    [Space(20)]
    [Header("フローチャート（Gaming）")]
    [SerializeField]
    Flowchart flowchart;
    [Header("フローチャートに送るメッセージ")]
    [SerializeField]
    string[] messageText;

    private string fungusText;

    [Space(20)]
    [SerializeField]
    GameObject[] bulletPrefab;

    [SerializeField]
    public bool finalBattle; //最後のバトルの時はこれがONになる

    private string _waveName;

    public Image imageThumnail;

    public Slider enemyHPSlider;

    int Max;

    public bool colliderFlag = false;

    public bool Oxia;

    public string AnimParaName;

    public bool Wes=false;
    void Start()
    {
        initialScale = transform.localScale;
        _animator = GetComponent<Animator>();
        // Debug.Log(_animator);
        //SetBoss();
    }

    private void OnEnable()
    {
        if (Wes == true) Wes = false;
        enemyHPSlider.value = 100;
        SetBoss();
    }

    void SetBoss()
    {
        eHPFlag = false;
        manager._boss = this;
        // DataBaseManagerの管理しているスクリプタブル・オブジェクトに敵データを取得しにいく
        enemyData = EnemyDataBaseManager.instance.GetEnemyData(enemyNo);
        //Debug.Log(enemyData.enemyName);

        switch (gameLevel._GameLevel.Value)
        {
            case GameLevel.Easy:
                _eHP = enemyData.maxHp;
                Max = _eHP;
                break;
            case GameLevel.Normal:
                _eHP = enemyData.maxHp + normal;
                Max = _eHP;
                break;
            case GameLevel.Hard:
                _eHP = enemyData.maxHp + hard;
                Max = _eHP;
                break;
        }
        //Debug.Log(_eHP);
        imageThumnail.sprite = image.GetComponent<SpriteRenderer>().sprite;
    }

    private void FixedUpdate()
    {
        if (gameState._GameState.Value == GameState.GamingStory) return;
        if (finalBattle == false)
        {
            if (_eHP < 0 && eHPFlag == false)
            {
                Dead();
                eHPFlag = true;
            }
        }
        else
        {
            if (_eHP < 0 && eHPFlag == false)
            {
                if (_deadFeadBacks != null) { _deadFeadBacks.PlayFeedbacks(); }
                else{ Dead_Final(); }
                //Dead_Final();
                eHPFlag = true;
            }
        }
        if (_eHP > Max) _eHP = Max;

    }
    /// <summary>
    /// プレイヤーの弾が当たった時の処理
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameState._GameState.Value == GameState.GamingStory) return;
        if (colliderFlag == true) return;
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (Wes == false)
            {
                SEManager.Instance.Play(SEPath.BULLET_IMPACT14, volumeRate: 0.2f, pitch: 0.8f);
                _animator.SetTrigger(ANIM_DAMAGE_TRIGGER);
                _eHP -= collision.GetComponentInParent<IBullet>().BulletAtk;
                Percentage100();
                UbhBullet bullet = collision.GetComponentInParent<UbhBullet>();
                if (bullet != null && bullet.isActive)
                {
                    UbhObjectPool.instance.ReleaseBullet(bullet);
                }
            }
            else
            {
                SEManager.Instance.Play(SEPath.BULLET_IMPACT14, volumeRate: 0.2f, pitch: 0.8f);
                _animator.SetTrigger(ANIM_DAMAGE_TRIGGER);
                _eHP -= collision.GetComponentInParent<IBullet>().BulletAtk/2;
                Percentage100();
                UbhBullet bullet = collision.GetComponentInParent<UbhBullet>();
                if (bullet != null && bullet.isActive)
                {
                    UbhObjectPool.instance.ReleaseBullet(bullet);
                }
            }
            
        }
    }


    public void Dead()
    {
        _animator.SetBool(AnimParaName, false);
        flowchart.SendFungusMessage(messageText[0]);
        //if (fungusText != null)
        //{

        //    flowchart.SendFungusMessage(fungusText);
        //}
        //else
        //{
            
        //}
        imageThumnail.sprite = Resources.Load<Sprite>("hatena");
        enemyHPSlider.value = 100;
        Explosion();    //破壊エフェクト
        BulletOff();    //弾幕を消去
        manager._boss = null;
        //if (finalBattle == false)
        //{
        //    ItemDrop(); //アイテムドロップ
        //}
       //his.gameObject.SetActive(false);
    }
    public void Dead_Final()
    {
        imageThumnail.sprite = Resources.Load<Sprite>("hatena");
        enemyHPSlider.value = 100;
        Explosion();    //破壊エフェクト
        BulletOff();    //弾幕を消去

        manager._boss = null;
        flowchart.SendFungusMessage(messageText[0]);
        this.gameObject.SetActive(false);

        
        //if (fungusText != null)
        //{ flowchart.SendFungusMessage(fungusText); }
        //else
        //{
            
        //};
    }

    private void OnDisable()
    {
        transform.localScale = initialScale;
        image.color = new Color32(255, 255, 255, 255);
        enemyData = null;
        _animator.SetBool(AnimParaName, false);
    }

    public void ItemDrop()
    {
        if (enemyData.dropItemNos.Length == 0) return;
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

    public void Explosion()
    {
        if (_explosionPrefab != null && finalBattle == false)
        {
            Instantiate(_explosionPrefab, transform.position, transform.rotation);
        }
        if (_LastexplosionPrefab != null && finalBattle == true)
        {
            Instantiate(_LastexplosionPrefab, transform.position, transform.rotation);
        }
    }
    public void StopAnimation()
    {
        _animator.SetBool(AnimParaName, false);
    }
    public Animator GetAnimator()
    {
        return _animator;
    }

    /// <summary>
    /// Fungusで使用
    /// </summary>
    /// <param name="name">Waveの名前</param>
    /// <param name="wave">Waveを始める場合はtrue,終了はfalse</param>
    /// <param name="textNum">Fungusに送るメッセージのNo</param>
    /// <param name="final">最後のウェーブかどうか</param>
    public void AnimatorWave(string name, bool wave, int textNum)
    {
        //死亡時、Fungusに送るテキストを決める
        if (wave == true) fungusText = messageText[textNum];
        //アニメーターの名前、Bool
        _animator.SetBool(name, wave);
        //パラメーター名
        _waveName = name;
    }

    public void SendMessage()
    {
        BulletOff();
    }

    public void FinalBattle()
    {
        finalBattle = true;
    }

    public void BulletOff()
    {
        UbhObjectPool.instance.ReleaseAllBullet();
    }

    public void BossGameOver()
    {
        _animator.SetBool(_waveName, false);
        _waveName = null;
        this.gameObject.SetActive(false);
    }

    public void BossBack()
    {
        if (finalBattle == false)
        {
            _animator.SetBool("Back", false);
            _animator.SetBool("Wave1", false);
        }
    }

    public void Percentage100()
    {
        int currentHealth = _eHP; // 体力の現在の値
        float maxHealth = Max; // 体力の最大値
        float percentage = (currentHealth / maxHealth) * 100; // パーセンテージを計算
        //currentHealth = Mathf.RoundToInt((percentage / 100) * maxHealth); // 100%にした値を計算
        //Debug.Log(currentHealth);
        enemyHPSlider.value = percentage;

    }

    public void WesOnOFF()
    {
        Wes = !Wes;
    }
}
