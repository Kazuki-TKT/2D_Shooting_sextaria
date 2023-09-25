using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletChoose : MonoBehaviour
{
    [SerializeField]
    Text SpName, SpExp;

    [SerializeField]
    STG_PowerUp _PowerUp;

    [SerializeField]
    Text _SubBulletName;

    [SerializeField]
    Text _SubBulletExpName;

    [SerializeField]
    Text _SpecialName;

    [SerializeField]
    Text _SpecialExpName;

    [SerializeField]
    Image SubImage, SpImage;

    public List<SubBulletText> subBullets;
    public List<SpText> spTexts;


    public void SubSet(SubBulletText.SubBulletTitle subBulletTitle)
    {
        SubBulletText data = subBullets.Find(data => data.subBulletTitle == subBulletTitle);
        _SubBulletName.text = data.subName;
        _SubBulletExpName.text = data.subExp;
        SubImage.sprite = data.subSprite;
    }
    public void SpSet(SpText.SpTitle spTitle)
    {
        SpText data = spTexts.Find(data => data.spTitle == spTitle);
        _SpecialName.text = data.spName;
        _SpecialExpName.text = data.spExp;
        SpName.text= data.spName;
        SpExp.text= data.spExp;
        SpImage.sprite = data.spSprite;
    }

    public void SubChoose(int x)
    {
        switch (x)
        {
            case 1:
                SubSet(SubBulletText.SubBulletTitle.Sub1);
                break;
            case 2:
                SubSet(SubBulletText.SubBulletTitle.Sub2);
                break;
            case 3:
                SubSet(SubBulletText.SubBulletTitle.Sub3);
                break;
            case 4:
                SubSet(SubBulletText.SubBulletTitle.Sub4);
                break;
            case 5:
                SubSet(SubBulletText.SubBulletTitle.Sub5);
                break;
        }
    }
    public void SpChoose(int x)
    {
        switch (x)
        {
            case 1:
                SpSet(SpText.SpTitle.Sp1);
                break;
            case 2:
                SpSet(SpText.SpTitle.Sp2);
                break;
            case 3:
                SpSet(SpText.SpTitle.Sp3);
                break;
            case 4:
                SpSet(SpText.SpTitle.Sp4);
                break;
            case 5:
                SpSet(SpText.SpTitle.Sp5);
                break;
        }
    }

    private void OnEnable()
    {
        if (_PowerUp._storyFlag == true)
        {
            int subNum = _PowerUp.selectSubNum;
            int spNum = _PowerUp.specialNum;
            switch (subNum)
            {
                case 1:
                    SubSet(SubBulletText.SubBulletTitle.Sub1);
                    break;
                case 2:
                    SubSet(SubBulletText.SubBulletTitle.Sub2);
                    break;
                case 3:
                    SubSet(SubBulletText.SubBulletTitle.Sub3);
                    break;
                case 4:
                    SubSet(SubBulletText.SubBulletTitle.Sub4);
                    break;
                case 5:
                    SubSet(SubBulletText.SubBulletTitle.Sub5);
                    break;
            }
            switch (spNum)
            {
                case 1:
                    SpSet(SpText.SpTitle.Sp1);
                    break;
                case 2:
                    SpSet(SpText.SpTitle.Sp2);
                    break;
                case 3:
                    SpSet(SpText.SpTitle.Sp3);
                    break;
                case 4:
                    SpSet(SpText.SpTitle.Sp4);
                    break;
                case 5:
                    SpSet(SpText.SpTitle.Sp5);
                    break;
            }
        }
        if (_PowerUp._freeFlag == true)
        {
            int subNum = _PowerUp.selectSubNumFree;
            int spNum = _PowerUp.specialNumFree;
            switch (subNum)
            {
                case 1:
                    SubSet(SubBulletText.SubBulletTitle.Sub1);
                    break;
                case 2:
                    SubSet(SubBulletText.SubBulletTitle.Sub2);
                    break;
                case 3:
                    SubSet(SubBulletText.SubBulletTitle.Sub3);
                    break;
                case 4:
                    SubSet(SubBulletText.SubBulletTitle.Sub4);
                    break;
                case 5:
                    SubSet(SubBulletText.SubBulletTitle.Sub5);
                    break;
            }
            switch (spNum)
            {
                case 1:
                    SpSet(SpText.SpTitle.Sp1);
                    break;
                case 2:
                    SpSet(SpText.SpTitle.Sp2);
                    break;
                case 3:
                    SpSet(SpText.SpTitle.Sp3);
                    break;
                case 4:
                    SpSet(SpText.SpTitle.Sp4);
                    break;
                case 5:
                    SpSet(SpText.SpTitle.Sp5);
                    break;
            }
        }
    }
}

[System.Serializable]
public class SubBulletText
{
    public enum SubBulletTitle
    {
        Sub1,
        Sub2,
        Sub3,
        Sub4,
        Sub5,
    }
    public SubBulletTitle subBulletTitle;
    public string subName;
    [TextArea]
    public string subExp;
    public Sprite subSprite;
}

[System.Serializable]
public class SpText
{
    public enum SpTitle
    {
        Sp1,
        Sp2,
        Sp3,
        Sp4,
        Sp5,
    }
    public SpTitle spTitle;
    public string spName;
    [TextArea]
    public string spExp;
    public Sprite spSprite;
}
