using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition_NoActive : MonoBehaviour
{
    private Vector3 initialPosition;

    private void Start()
    {
        // 初期位置を保存する
        initialPosition = transform.position;
    }

    private void OnDisable()
    {
        // オブジェクトが非アクティブになったら初期位置に戻す
        transform.position = initialPosition;
    }
}
