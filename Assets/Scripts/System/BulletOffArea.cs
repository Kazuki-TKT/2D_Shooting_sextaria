using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOffArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        HitCheck(other.transform);

    }
    private void HitCheck(Transform colTrans)
    {
        // *It is compared with name in order to separate as Asset from project settings.
        //  However, it is recommended to use Layer or Tag.
        // Containsで値の名前が含まれているかどうか
        string goName = colTrans.name;

        if (goName.Contains(STG_Player.NAME_ENEMY_BULLET) ||
            goName.Contains(UbhEnemy.NAME_PLAYER_BULLET))
        {
            //Debug.Log($"<color=#fff5ee><b>弾</b></color>");
            UbhBullet bullet = colTrans.parent.GetComponentInParent<UbhBullet>();
            if (bullet != null && bullet.isActive)
            {
                //Debug.Log($"<color=#fff5ee><b>弾OFF</b></color>");
                UbhObjectPool.instance.ReleaseBullet(bullet);
            }
        }
    }
   }
