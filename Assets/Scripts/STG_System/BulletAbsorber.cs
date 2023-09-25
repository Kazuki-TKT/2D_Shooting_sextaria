using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using KanKikuchi.AudioManager;
public class BulletAbsorber : MonoBehaviour
{
    [SerializeField]
    SEAssistant sEAssistant;
    public float absorbRange = 3f;  // 弾丸を吸い込む範囲の半径
    [SerializeField]
    MMFeedbacks _mmFeedback;

    private STG_Boss sTG_Boss;

    public int plusHp;
    public GameObject[] itemPrefab;
    private void Awake()
    {
        sTG_Boss = GameObject.Find("Oxia_Boss_Final").GetComponent<STG_Boss>();
    }
    private void Update()
    {
        // 吸い込む範囲内にあるオブジェクトを取得
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, absorbRange);

        // 吸い込む範囲内の「Bullet」タグを持つオブジェクトを吸い込む
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Bullet"))
            {
                // 吸い込む処理をここに実装
                // 例えば、オブジェクトを非アクティブにするか、破壊するなど
                sEAssistant.Play();
                sTG_Boss._eHP += plusHp;
                sTG_Boss.Percentage100();
                _mmFeedback.PlayFeedbacks();
                UbhBullet bullet = collider.GetComponentInParent<UbhBullet>();
                if (bullet != null && bullet.isActive)
                {
                    //Debug.Log($"<color=#fff5ee><b>弾OFF</b></color>");
                    UbhObjectPool.instance.ReleaseBullet(bullet);
                }
            }
        }
    }
    private void Dead()
    {
            Vector3 pos = transform.position;
            // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
            float x = Random.Range(pos.x + 0.5f, pos.x - 0.5f);
            Instantiate(itemPrefab[0], new Vector3(x, pos.y + 2f, pos.z), Quaternion.identity);
            Instantiate(itemPrefab[1], new Vector3(x, pos.y + 2f, pos.z), Quaternion.identity);
    }

    private void OnDestroy()
    {
        Dead();
    }
}
