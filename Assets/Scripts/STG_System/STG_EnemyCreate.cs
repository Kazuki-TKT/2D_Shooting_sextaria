using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class STG_EnemyCreate : MonoBehaviour
{
    public GameObject _deleateObj;

    [SerializeField]
    GameObject[] _enemyPrefab;

    [Header("次の敵キャラを生成するまでの時間")]
    public float enemyCreateTime;

    [Header("最初の敵キャラを生成するまでの時間")]
    public float firstCreateTime;

    [SerializeField]
    GameObject _nextGroup;
    void Start()
    {
        //var children = transform.GetComponentsInChildren<Transform>(true);
        var childDestroyObservable = Observable
            .EveryUpdate()
            .Select(_ => transform.GetComponentsInChildren<Transform>(true).Length)
            .DistinctUntilChanged()
            .Where(count => count == 1)
            .Take(1);

        childDestroyObservable.Subscribe(_ => Destroy(gameObject)).AddTo(this);

        StartCoroutine(EnemyCreate());
    }

    IEnumerator EnemyCreate()
    {
        if (firstCreateTime != 0) yield return new WaitForSeconds(firstCreateTime);
        for (int i = 0; i < _enemyPrefab.Length; i++)
        {
            GameObject obj = Instantiate(_enemyPrefab[i], transform);
            //Debug.Log(obj.name + ":" + i);
            yield return new WaitForSeconds(enemyCreateTime);
        }
        if (_nextGroup != null) NextGroup();
        Destroy(_deleateObj);
    }

    public void NextGroup()
    {
        GameObject childObject = Instantiate(_nextGroup, transform.parent);
    }
}
