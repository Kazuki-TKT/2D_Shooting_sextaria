using UnityEngine;
using UniRx;

public class BossBase : MonoBehaviour
{
    private const string ANIM_DAMAGE_TRIGGER = "Damage";

    ReactiveProperty<int> _eHP = new ReactiveProperty<int>();

    [SerializeField]
    private GameObject _explosionPrefab = null;

    [Header("敵の番号。インスペクターで指定する")]
    public int enemyNo;

    [Header("敵の情報。番号で検索して、スクリプタブル・オブジェクトから取得する")]
    public EnemyDataList.EnemyData enemyData;

    private Animator _animator;

    STG_Score _score;

    void Start()
    {
        _animator = GetComponent<Animator>();

        // DataBaseManagerの管理しているスクリプタブル・オブジェクトに敵データを取得しにいく
        enemyData = EnemyDataBaseManager.instance.GetEnemyData(enemyNo);
        Debug.Log(enemyData.enemyName);

        _score = GameObject.Find("ScoreGroup").GetComponent<STG_Score>();

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
        Explosion();
        _score.AddPoint(enemyData.scorePoint);
        Destroy(gameObject);
        ItemDrop();
    }
    public void HitDead()
    {
        Explosion();
        Destroy(gameObject);
    }

    public void ItemDrop()
    {
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
