using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class STG_CharaImageMove : MonoBehaviour
{
    public enum CharaName
    {
        lucy,
        laura,
        atria,
        izal,
        wes,
        elnath,
        oxia,
        ryusei,
        mob
    }
    public Image charaImage;
    public CharaName chara;
    public RectTransform targetRectTransform;

    public void CharaIconTransform(CharaName charaName)
    {
        switch (charaName)
        {
            case CharaName.lucy:
                targetRectTransform.anchoredPosition = new Vector2(0, -370);
                break;
            case CharaName.laura:
                targetRectTransform.anchoredPosition = new Vector2(0, -390);
                break;
            case CharaName.atria:
                targetRectTransform.anchoredPosition = new Vector2(0, -380);
                break;
            case CharaName.izal:
                targetRectTransform.anchoredPosition = new Vector2(-23, -370);
                break;
            case CharaName.wes:
                targetRectTransform.anchoredPosition = new Vector2(0, -317);
                break;
            case CharaName.elnath:
                targetRectTransform.anchoredPosition = new Vector2(13.5f, -356);
                break;
            case CharaName.oxia:
                targetRectTransform.anchoredPosition = new Vector2(35, -385);
                break;
            case CharaName.ryusei:
                charaImage.sprite = null;
                break;
        }
    }
}
