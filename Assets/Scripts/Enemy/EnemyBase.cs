using UnityEngine;
using UniRx;
using KanKikuchi.AudioManager;
using UnityEngine.UI;
public class EnemyBase : MonoBehaviour
{

    private const string ANIM_DAMAGE_TRIGGER = "Damage";

   public ReactiveProperty<int> _eHP = new ReactiveProperty<int>();

    [SerializeField]
    private GameObject _explosionPrefab = null;

    [Header("敵の番号。インスペクターで指定する")]
    public int enemyNo;

    [Header("敵の情報。番号で検索して、スクリプタブル・オブジェクトから取得する")]
    public EnemyDataList.EnemyData enemyData;

    private Animator _animator;

    [SerializeField]
    STG_Score _score;

    [SerializeField]
    STG_GetScoreGroup _getScore;

    Image imageThumnail;
 
    Sprite defaultImage;
    Sprite enemyImage;
    Slider enemyHPSlider;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        enemyImage = gameObject.GetComponent<SpriteRenderer>().sprite;
    }
    void Start()
    {
        
        // DataBaseManagerの管理しているスクリプタブル・オブジェクトに敵データを取得しにいく
        if (EnemyDataBaseManager.instance.GetEnemyData(enemyNo) != null)
        {
            enemyData = EnemyDataBaseManager.instance.GetEnemyData(enemyNo);
        }
        else
        {
            Debug.LogWarning(this.gameObject.name + " : " + enemyData.enemyName);
        }
        

        if (_getScore != null)
        {
            _score = _getScore.score;
            imageThumnail = _getScore.image;
            enemyHPSlider = _getScore.slider;
        }
        else
        {
            _score = GameObject.Find("ScoreGroup").GetComponent<STG_Score>();
            imageThumnail = GameObject.Find("EnemyThumbnail").GetComponent<Image>();
            enemyHPSlider = GameObject.Find("EnemyHP_bar").GetComponent<Slider>();
            defaultImage= Resources.Load<Sprite>("hatena");
        }
        

        _eHP.Value = enemyData.maxHp;
        _eHP.Where(x => x <= 0)
            .Take(1)
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
            imageThumnail.sprite = enemyImage;
            SEManager.Instance.Play(SEPath.BULLET_IMPACT14, volumeRate: 0.2f,pitch:0.8f);
            _animator.SetTrigger(ANIM_DAMAGE_TRIGGER);
            _eHP.Value -= collision.GetComponentInParent<IBullet>().BulletAtk;
            Percentage100();
            UbhBullet bullet = collision.GetComponentInParent<UbhBullet>();
            if (bullet != null && bullet.isActive)
            {
                UbhObjectPool.instance.ReleaseBullet(bullet);
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            _animator.SetTrigger(ANIM_DAMAGE_TRIGGER);
            HitDead();
        }
    }

    public void Dead()
    {
        enemyHPSlider.value = 100;
        if (_getScore != null) { imageThumnail.sprite = _getScore.defaultIMG; } else
        {
            imageThumnail.sprite = defaultImage;
        }
        
        ItemDrop();
        Explosion();
        _score.AddPoint(enemyData.scorePoint);
        Destroy(gameObject);
        
    }
   
    public void HitDead()
    {
        enemyHPSlider.value = 0;
        Explosion();
        Destroy(gameObject);
    }

    public void AnimeDead()
    {
        Destroy(gameObject);
    }
    public void Percentage100()
    {
        int currentHealth = _eHP.Value; // 体力の現在の値
        float maxHealth = enemyData.maxHp; // 体力の最大値
        float percentage = (currentHealth / maxHealth) * 100; // パーセンテージを計算
        //currentHealth = Mathf.RoundToInt((percentage / 100) * maxHealth); // 100%にした値を計算
        enemyHPSlider.value = percentage;
        
    }
    public void ItemDrop()
    {
        //Debug.Log(enemyData.dropItemNos.Length);
        for (int i = 0; i < enemyData.dropItemNos.Length; i++)
        {
            // アイテムの番号と合致するプレファブのデータを取得する
            GameObject itemPrefab = EnemyDataBaseManager.instance.GetDropItemPrefabDate(enemyData.dropItemNos[i]);    // ☆　追加
            Vector3 pos = transform.position;

            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(pos.x+1.4f, pos.x  -1.4f);
            //Debug.Log(x);
            //取得したプレファブのデータを使ってアイテムを生成する
            Instantiate(itemPrefab, new Vector3(x, pos.y + 0.3f, pos.z), Quaternion.identity);
        }
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
}
