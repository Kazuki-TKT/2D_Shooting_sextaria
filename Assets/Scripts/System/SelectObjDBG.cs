using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectObjDBG : MonoBehaviour
{
    private GameObject selectedObject;
    private GameObject lastSelected;
    void Update()
    {
        if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null)
        {
            if (selectedObject != EventSystem.current.currentSelectedGameObject)
            {
                selectedObject = EventSystem.current.currentSelectedGameObject;
               // Debug.Log("Selected Object: " + $"<color=blue><b>{selectedObject.name}</b></color>");
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
           // Debug.Log("Left mouse button clicked!");
            if (selectedObject != null)
            {
               // Debug.Log("Click!!: " + $"<color=green><b>{selectedObject.name}</b></color>");
                Button selectedButtonComponent = selectedObject.GetComponent<Button>();
                selectedButtonComponent.Select();

            }
        }
    }
}
