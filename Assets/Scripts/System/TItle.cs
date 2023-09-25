using UnityEngine;
using MoreMountains.Feedbacks;
using UnityEngine.Events;

public class TItle : MonoBehaviour
{

    [SerializeField]
    MMFeedbacks _mmFeedback;

    public GameStateManager _GameStateManager;
    private void Awake()
    {
        _GameStateManager._GameState.Value = GameState.Title;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) PressEnter();
    }

    void PressEnter()
    {
        _mmFeedback.PlayFeedbacks();
    }
}
