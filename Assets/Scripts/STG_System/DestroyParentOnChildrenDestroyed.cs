using UnityEngine;
using UniRx;

public class DestroyParentOnChildrenDestroyed : MonoBehaviour
{
    

    private void Start()
    {
        var children = transform.GetComponentsInChildren<Transform>(true);
        var childDestroyObservable = Observable
            .EveryUpdate()
            .Select(_ => transform.GetComponentsInChildren<Transform>(true).Length)
            .DistinctUntilChanged()
            .Where(count => count == 1)
            .Take(1);

        childDestroyObservable.Subscribe(_ => Destroy(gameObject)).AddTo(this);
    }

}
