using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class STG_OokamiShot : MonoBehaviour
{
    [SerializeField]
    GameObject OokamiGroup;

    [SerializeField]
    UbhShotCtrl[] ubhShot;
    [SerializeField]
    ParticleSystem[] fire;
    [SerializeField]
    private Vector3 targetPosition;
    [SerializeField]
    private Vector3 firstPosition;
    public float moveSpeed;

    int index1, index2;
    private Tween moveTween;

    bool flag;

    public bool shotEnd;

    
    private void OnEnable()
    {
        OokamiGroup.SetActive(true);
        flag = false;
        shotEnd = false;
    }
    public void MoveToTargetPosition()
    {
        // 最初の位置から指定した場所まで移動するTweenを作成
        moveTween= OokamiGroup.transform.DOMove(targetPosition, moveSpeed).SetEase(Ease.InOutQuad).OnComplete(OokamiEffect);
    }
    public void MoveToInitialPosition()
    {
        // 指定した場所から最初の位置に戻るTweenを作成
        Debug.Log("オオカミ終了");
        moveTween = OokamiGroup.transform.DOMove(firstPosition, moveSpeed).OnComplete(StopOokami);
        shotEnd = false;
    }
    public void OokamiEffect()
    {
        if (fire.Length < 2)
        {
            Debug.LogError("The 'fire' array should have at least 2 elements.");
            return;
        }
        // ランダムな2つのインデックスを選択
        index1 = Random.Range(0, ubhShot.Length);
        index2 = Random.Range(0, ubhShot.Length);
        while (index2 == index1) // インデックスが重複しないようにする
        {
            index2 = Random.Range(0, ubhShot.Length);
        }
        // 選択した2つのパーティクルシステムを再生
        fire[index1].Play();
        fire[index2].Play();
        flag = true;
    }
    public void OokamiShot()
    {
        ubhShot[index1].StartShotRoutine();
        ubhShot[index2].StartShotRoutine();
    }
    public void StopOokami()
    {
        if (flag == false) return;
        ubhShot[index1].StopShotRoutine();
        ubhShot[index2].StopShotRoutine();
        fire[index1].Stop();
        fire[index2].Stop();
        flag = false;
    }

    private void OnDisable()
    {
        StopOokami();
        OokamiGroup.SetActive(false);
        if (moveTween != null && moveTween.IsActive())
        {
            moveTween.Kill();
        }
    }

    public void TweenKill()
    {
        // オブジェクトが破棄される際にTweenをキャンセルする
        if (moveTween != null && moveTween.IsActive())
        {
            moveTween.Kill();
        }
    }
    public void EndShot()
    {
        shotEnd = true;
        Debug.Log("shotEnd");
    }
    private void FixedUpdate()
    {
        if (shotEnd == true)
        {
            MoveToInitialPosition();
        }
    }
}
