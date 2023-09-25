using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;
using System.Threading;
using Cysharp.Threading.Tasks;
public class LinearMove : MonoBehaviour,EnemyMove
{
    [SerializeField]
    Rigidbody2D _rigidbody2D;

    public Vector2 Vector2;

    public float _delayTime;
    public float _moveTime;
    public float _moveRange;

    public enum ShotType
    {
        Normal,
        StopShoot,
    }

    public ShotType type;
    /*-----DOTween-----*/
    //SetDelay 開始時間を遅らせる
    //SetSpeedBased 速度基準のアニメーションに変更
    //SetLink　アニメーション途中に消去されたら停止
    //OnComplete　完了後の処理

    //public float _delayTime;
    //public float _moveTime;
    //public float _moveRange;
    public void EnemyMove()
    {
        switch (type)
        {
            case ShotType.Normal:
                NormalMove();
                    break;
        }
    }

    void NormalMove()
    {
        _rigidbody2D
            .DOMove(new Vector2(Vector2.x, Vector2.y), _moveTime)
            .SetEase(Ease.Linear)
            .SetDelay(_delayTime)
            .SetLink(gameObject);
    }
}
