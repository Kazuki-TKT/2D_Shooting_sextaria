using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconsSystem : MonoBehaviour
{
    [SerializeField]
    Image _iconImage1, _iconImage2,_titleImage,_whereImage,_efectImage;

    [SerializeField]
    Text _titleText, _whereText;

    [SerializeField] GameObject _ICON1, _ICON2;
    [SerializeField] Vector2[] _position;

    [SerializeField] List<Icons> icons;

    [SerializeField]
    Sprite _syutyuSen, _eroPink,live,smoke,elnathSmoke;
    public enum Positions
    {
        中央,
        右,
        左,
        右2,
        左2,
    }
    void Start()
    {
        _iconImage1.color = new Color(255, 255, 255, 0);
        _iconImage2.color = new Color(255, 255, 255, 0);
    }
    private void OnDisable()
    {
        _iconImage1.color = new Color32(255, 255, 255, 0);
        _iconImage2.color = new Color32(255, 255, 255, 0);
        _titleImage.color = new Color32(255, 255, 255, 0);
        _whereImage.color = new Color32(255, 255, 255, 0);
        _titleText.color = new Color32(255, 255, 255, 0);
        _whereText.color = new Color32(192, 0, 4, 0);
        _efectImage.color = new Color32(255, 255, 255, 0);
    }

    public void SyuTyuSen()
    {
        _efectImage.sprite = _syutyuSen;
        _efectImage.color = new Color32(255, 255, 255, 255);
    }
    public void EroPink()
    {
        _efectImage.sprite = _eroPink;
        _efectImage.color = new Color32(255, 255, 255, 255);
    }
    public void IzalLive()
    {
        _efectImage.sprite = live;
        _efectImage.color = new Color32(255, 255, 255, 255);
    }
    public void Smoke()
    {
        _efectImage.sprite = smoke;
        _efectImage.color = new Color32(255, 255, 255, 255);
    }
    public void ElnathSmoke()
    {
        _efectImage.sprite = elnathSmoke;
        _efectImage.color = new Color32(0, 0, 0, 255);
    }
    public void Efect_Hide()
    {
        _efectImage.color = new Color32(255, 255, 255, 0);
    }
    public void Icon1_Hide()
    {
        _iconImage1.color = new Color32(255, 255, 255, 0);
    }
   
    IEnumerator Wait(Icons.Icon icon, Positions positions, float second)
    {
        yield return new WaitForSeconds(second);
        Icons data = icons.Find(data => data.icon == icon);
        _iconImage1.sprite = data.iconsprite;
        _iconImage1.color = new Color32(255, 255, 255, 255);
        switch (positions)
        {
            case Positions.中央:
                if (data.lr == Icons.LR.左) _ICON1.transform.localPosition = new Vector3(_position[0].x, _position[0].y, transform.position.z);
                if (data.lr == Icons.LR.右) _ICON1.transform.localPosition = new Vector3(_position[1].x, _position[1].y, transform.position.z);
                break;
            case Positions.右:
                if (data.lr == Icons.LR.左) _ICON1.transform.localPosition = new Vector3(_position[2].x, _position[2].y, transform.position.z);
                if (data.lr == Icons.LR.右) _ICON1.transform.localPosition = new Vector3(_position[3].x, _position[3].y, transform.position.z);
                break;
            case Positions.左:
                if (data.lr == Icons.LR.右) _ICON1.transform.localPosition = new Vector3(_position[4].x, _position[4].y, transform.position.z);
                if (data.lr == Icons.LR.左) _ICON1.transform.localPosition = new Vector3(_position[5].x, _position[5].y, transform.position.z);
                break;
            case Positions.右2:
                if (data.lr == Icons.LR.右) _ICON1.transform.localPosition = new Vector3(_position[6].x, _position[6].y, transform.position.z);
                if (data.lr == Icons.LR.左) _ICON1.transform.localPosition = new Vector3(_position[7].x, _position[7].y, transform.position.z);
                break;
            case Positions.左2:
                if (data.lr == Icons.LR.右) _ICON1.transform.localPosition = new Vector3(_position[8].x, _position[8].y, transform.position.z);
                if (data.lr == Icons.LR.左) _ICON1.transform.localPosition = new Vector3(_position[9].x, _position[9].y, transform.position.z);
                break;
        }
    }
    public void ICON1(Icons.Icon icon, Positions positions,float second)
    {
        StartCoroutine(Wait(icon,positions,second));
    }

    public void TitleText(string title)
    {
        _titleText.text = title;
    }

    public void WhereText(string where)
    {
       
        _whereText.text = where;
    }
}

[System.Serializable]
public class Icons
{
    public enum Icon
    {
        ビックリ,
        ハテナ,
        ビックリハテナ,
        悦ぶ,
        汗,
        黙る,
        怒り,
        ハート,
        音符,
        キラキラ,
        不安,
        ぐるぐる
    }

    public Icon icon;
    public enum LR
    {
        左,
        右
    }

    public LR lr;
    public Sprite iconsprite;
}
