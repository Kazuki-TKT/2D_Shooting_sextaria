using UnityEngine;
using MoreMountains.Feedbacks;

public class STG_StartCanvas : MonoBehaviour
{

    [SerializeField]
    MMFeedbacks _mmFeedback;

    public GameStateManager _GameStateManager;
    private void Start()
    {
        //_GameStateManager._GameState.Value = GameState.Title;
    }
    private void Update()
    {
        
    }

    void PressEnter()
    {
        _mmFeedback.PlayFeedbacks();
    }
}
