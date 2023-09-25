using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectMover : MonoBehaviour
{
    private Tween _tween = null;
    public Transform target; // 移動先のTransform
    public float duration; // 移動にかかる時間
    public Ease easeType; // DOTweenのイージングタイプ
    [SerializeField]
    private UISelectAction uiSelectAction;

    public GameStateManager _GameStateManager;

    [SerializeField]
    bool first=false;

    void Start()
    {
        
    }
    private void OnEnable()
    {
        if (first == true) return;
        transform.DOMove(target.position, duration)
           .SetEase(easeType)
           .OnComplete(() => {
                // 移動完了時にonComplete関数を実行
                if (uiSelectAction != null)
               {
                   uiSelectAction.FirstSelect();
                   _GameStateManager._GameState.Value = GameState.MainMenu;
               }
           });
        first = true;
    }
    private void OnDisable()
    {
        // Tween破棄
        if (DOTween.instance != null)
        {
            _tween?.Kill();
        }
    }

}
