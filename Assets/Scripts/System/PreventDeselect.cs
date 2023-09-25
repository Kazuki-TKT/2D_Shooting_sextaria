using UnityEngine;
using UnityEngine.EventSystems;

public class PreventDeselect : MonoBehaviour, IPointerDownHandler
{
    private GameObject lastSelected;

    public void OnPointerDown(PointerEventData eventData)
    {
        lastSelected = EventSystem.current.currentSelectedGameObject;
        Debug.Log(lastSelected);
    }

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null && lastSelected != null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelected);
        }
    }
}