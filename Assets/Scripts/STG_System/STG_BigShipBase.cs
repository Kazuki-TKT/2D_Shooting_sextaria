using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace MotherShip
{
    public class STG_BigShipBase : MonoBehaviour
    {
        private const string ANIM_DAMAGE_TRIGGER = "Damage";

        ReactiveProperty<int> _eHP = new ReactiveProperty<int>();

        //[SerializeField]
        //private GameObject _explosionPrefab = null;

        [Header("敵の番号。インスペクターで指定する")]
        public int enemyNo;

        [Header("敵の情報。番号で検索して、スクリプタブル・オブジェクトから取得する")]
        public EnemyDataList.EnemyData enemyData;

        private Animator _animator;

        STG_Score _score;
        Image imageThumnail;

        Sprite defaultImage;
        Sprite enemyImage;
        Slider enemyHPSlider;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            enemyImage = gameObject.GetComponent<SpriteRenderer>().sprite;
            _score = GameObject.Find("ScoreGroup").GetComponent<STG_Score>();
            imageThumnail = GameObject.Find("EnemyThumbnail").GetComponent<Image>();
            enemyHPSlider = GameObject.Find("EnemyHP_bar").GetComponent<Slider>();
            defaultImage = Resources.Load<Sprite>("hatena");
        }
        void Start()
        {

            // DataBaseManagerの管理しているスクリプタブル・オブジェクトに敵データを取得しにいく
            enemyData = EnemyDataBaseManager.instance.GetEnemyData(enemyNo);
            Debug.Log(enemyData.enemyName);

            _score = GameObject.Find("ScoreGroup").GetComponent<STG_Score>();

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
                _animator.SetTrigger(ANIM_DAMAGE_TRIGGER);
                _eHP.Value -= collision.GetComponentInParent<IBullet>().BulletAtk;
                Percentage100();
                UbhBullet bullet = collision.GetComponentInParent<UbhBullet>();
                if (bullet != null && bullet.isActive)
                {
                    UbhObjectPool.instance.ReleaseBullet(bullet);
                }
            }
            //if (collision.gameObject.CompareTag("Player"))
            //{
            //    //_animator.SetTrigger(ANIM_DAMAGE_TRIGGER);
            //    //HitDead();
            //}
        }
        public void Percentage100()
        {
            int currentHealth = _eHP.Value; // 体力の現在の値
            float maxHealth = enemyData.maxHp; // 体力の最大値
            float percentage = (currentHealth / maxHealth) * 100; // パーセンテージを計算
                                                                  //currentHealth = Mathf.RoundToInt((percentage / 100) * maxHealth); // 100%にした値を計算
            enemyHPSlider.value = percentage;

        }
        public void Dead()
        {
            enemyHPSlider.value = 100;
            
                imageThumnail.sprite = defaultImage;
            

            Explosion();
            _score.AddPoint(enemyData.scorePoint);
            //Destroy(gameObject);
            ItemDrop();
        }
        public void HitDead()
        {
            Explosion();
            Destroy(gameObject);
        }

        /// <summary>
        /// 経験値をEXPmanagerにあげる処理
        /// </summary>
        //public void GiveEXP()
        //{
        //    EXPManager eXPManager = GameObject.Find("EXPManager").GetComponent<EXPManager>();
        //    eXPManager.StockEXP(enemyData.exp);　　　　　// ☆　修正

        //    Debug.Log(gameObject.name + "経験値" + enemyData.exp);　　　　// ☆　修正
        //}
        /// <summary>
        /// 敵が倒れた時ランダムの確率で、登録したアイテムがランダムでドロップ
        /// </summary>
        public void ItemDrop()
        {
            for (int i = 0; i < enemyData.dropItemNos.Length; i++)
            {


                // アイテムの番号と合致するプレファブのデータを取得する
                GameObject itemPrefab = EnemyDataBaseManager.instance.GetDropItemPrefabDate(enemyData.dropItemNos[i]);    // ☆　追加
                Vector3 pos = transform.position;

                // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
                float x = Random.Range(pos.x + 1.4f, pos.x - 1.4f);
                //Debug.Log(x);
                //取得したプレファブのデータを使ってアイテムを生成する
                Instantiate(itemPrefab, new Vector3(x, pos.y + 0.3f, pos.z), Quaternion.identity);

            }
        }

        public void Explosion()
        {
            GetComponent<ExplosionController>().StartExplosion();
            //if (_explosionPrefab != null)
            //{
            //    Instantiate(_explosionPrefab, transform.position, transform.rotation);
            //}
        }

        public Animator GetAnimator()
        {
            return _animator;
        }
    }
}
