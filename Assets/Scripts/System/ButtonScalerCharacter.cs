using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonScalerCharacter : MonoBehaviour,  IDeselectHandler
{
    private Tween _tween = null;
    [SerializeField]
    public float scale = 1.2f; // 拡大するスケール

    private Vector3 originalScale; // 元のスケール

    public GameObject selectedObj;
    private void Start()
    {
        originalScale = transform.localScale; // 初期化
    }

    // セレクト時に呼ばれる
    public void OnSelection()
    {
        transform.DOScale(new Vector3(scale, scale, 1), 0.2f).SetLink(gameObject);
        selectedObj.SetActive(true);
    }
    public void OnNotSelection()
    {
        transform.DOScale(new Vector3(scale, scale, 1), 0.2f).SetLink(gameObject);
    }

    // デセレクト時に呼ばれる
    public void OnDeselect(BaseEventData eventData)
    {
        transform.DOScale(originalScale, 0.2f).SetLink(gameObject);
        selectedObj.SetActive(false);
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
