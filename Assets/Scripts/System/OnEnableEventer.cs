using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class OnEnableEventer : MonoBehaviour
{

    public UnityEvent unityEvent;

    private void OnEnable()
    {
        unityEvent.Invoke();
    }
}
