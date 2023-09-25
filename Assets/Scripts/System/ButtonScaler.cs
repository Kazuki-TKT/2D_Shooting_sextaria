using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonScaler : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private Tween _tween = null;
    [SerializeField]
    public float scale = 1.2f; // 拡大するスケール

    private Vector3 originalScale; // 元のスケール

    [SerializeField]
    Material _emiisionMaterial;

    [SerializeField]
    Image image;
    private void Start()
    {
        originalScale = transform.localScale; // 初期化
        image = GetComponent<Image>();
        //Button button=GetComponent<Button>();
        //button.onClick.AddListener(MaterialNULL);
    }

    // セレクト時に呼ばれる
    public void OnSelect(BaseEventData eventData)
    {
        if(_emiisionMaterial!=null)image.material = _emiisionMaterial;
        transform.DOScale(new Vector3(scale, scale, 1), 0.2f).SetLink(gameObject);
    }

    // デセレクト時に呼ばれる
    public void OnDeselect(BaseEventData eventData)
    {
        image.material = null;
        transform.DOScale(originalScale, 0.2f).SetLink(gameObject);
    }

    public void MaterialNULL()
    {
        image.material = null;
    }

    public void OriginalScale()
    {
        transform.localScale = originalScale;
    }
    
    private void OnDisable()
    {
        image.material = null;
        // Tween破棄
        if (DOTween.instance != null)
        {
            _tween?.Kill();
        }
    }
    public void OnSelect_2()
    {
        image.material = _emiisionMaterial;
        transform.DOScale(new Vector3(scale, scale, 1), 0.2f).SetLink(gameObject);
    }
}
