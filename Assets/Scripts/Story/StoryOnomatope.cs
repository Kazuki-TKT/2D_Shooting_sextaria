using UnityEngine;

public class StoryOnomatope : MonoBehaviour
{
    [SerializeField]
    GameObject[] _onomatopeObj;


    private void Start()
    {
        
    }

    public void OpenOnomatope(int x)
    {
       
        _onomatopeObj[x].SetActive(true);
    }
    public void HideOnomatope(int x)
    {
        
            _onomatopeObj[x].SetActive(false);
    }

    private void OnDisable()
    {
        for(int i = 0; i < _onomatopeObj.Length; i++)
        {
            if (_onomatopeObj[i].activeSelf == true) _onomatopeObj[i].SetActive(false);
        }
    }

    
}
