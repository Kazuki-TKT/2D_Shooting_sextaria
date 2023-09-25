using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class EnemyCtrl : UbhMonoBehaviour
{
    //[FormerlySerializedAs("_Speed")]
    //public float m_speed;

    //[SerializeField]
    //Rigidbody2D _rigidbody2D;
    //[SerializeField, FormerlySerializedAs("_UseStop")]
    //private bool m_useStop = false;
    //[SerializeField, FormerlySerializedAs("_StopPoint")]
    //private float m_stopPoint = 2f;

    /*-----DOTween-----*/
    //SetDelay 開始時間を遅らせる
    //SetLink　アニメーション途中に消去されたら停止

    //public float _delayTime;
    //public float _moveTime;
    //public float _moveRange;

    Tweener tweener;


    private void Awake()
    {
        
    }
    void Start()
    {
        if (gameObject.GetComponent<EnemyMove>() != null)
        {
            EnemyMove enemyMove = gameObject.GetComponent<EnemyMove>();
            enemyMove.EnemyMove();
        }
        
        //tweener = transform.DOMoveY(transform.position.y - _moveRange, _moveTime).SetEase(Ease.Linear);
        //tweener = transform.DOMove(new Vector2(0, -2), _moveTime).SetDelay(2).SetLink(gameObject);
        //tweener = transform.DOMoveY(transform.position.y - _moveRange, _moveTime).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        // _rigidbody2D.DOMove(new Vector2(0, -2), duration:5f).SetDelay(2).SetLink(gameObject);
        //Move(transform.up * -1);
    }
    private void FixedUpdate()
    {
        //if (m_useStop)
        //{
        //    if (transform.position.y < m_stopPoint)
        //    {
        //        rigidbody2D.velocity = UbhUtil.VECTOR2_ZERO;
        //        m_useStop = false;
        //    }
        //}
    }

    //public void Move(Vector2 direction)
    //{
    //    rigidbody2D.velocity = direction * m_speed;
    //}

    //public void Move2()
    //{

    //}
}
