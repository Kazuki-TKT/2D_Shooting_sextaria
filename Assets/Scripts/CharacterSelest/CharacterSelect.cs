using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using KanKikuchi.AudioManager;

public class CharacterSelect : MonoBehaviour
{
    public GameObject ButtonGroup1, ButtonGroup2;
    [SerializeField]
    Sprite blackimage;

    public string messageText1;
    public string messageText2;

    [SerializeField]
    Image ButtonImage1,ButtonImage2, ButtonImageL;

    [SerializeField]
    GameStateManager gameState;

    [SerializeField]
    Flowchart flowchart;

    [SerializeField]
    FadeCanvasMy fadeCanvas;
    [SerializeField]
    FadeCanvasMy fadeCanvasL;
    [SerializeField]
    StoryButton storyButton;
    [SerializeField]
    UISelectAction selectAction;

    [SerializeField]
    StoryScrollbar story;

    [SerializeField]
    CharacterDataBaseManager character;

    [SerializeField]
    Text _charaNameText;

    [SerializeField]
    Text _charaProfileText;

    [SerializeField]
    bool _changeType=true;

    [SerializeField]
    Image _mainCharaImage;

    int _charaNum;

    int _charaSpriteNum;

    [SerializeField]
    GallertStoryButton gallertStory;

    bool clearflag;
    private void Start()
    {
        _changeType = true;
    }

    private void OnEnable()
    {
        _changeType = true;
    }
    public void ChangeType()
    {
        _changeType = !_changeType;
        if (_changeType == true)
        {
            _mainCharaImage.sprite = character.GetCharaData(_charaNum).charaSprites[_charaSpriteNum];
        }
        else
        {
            _mainCharaImage.sprite = character.GetCharaData(_charaNum).charaSprites_Hadaka[_charaSpriteNum];
        }
    }

    public void ChangeTypeTrue()
    {
        _changeType = true;
    }
    public void CharaSelect(int x)
    {
        _charaNum = x;
        _mainCharaImage.sprite = character.GetCharaData(x).charaSprites[0];
        _charaNameText.text=character.GetCharaData(x).charaName;
        _charaProfileText.text = character.GetCharaData(x).profileText;

        for (int i = 0; i < character.GetCharaData(x).storyNum.Length; i++)
        {
            CheckClearFlag(character.GetCharaData(x).storyNum[i]);
        }
    }
   
    public void ChangeFaceType(int x)
    {
        _charaSpriteNum = x;
        if (_changeType == true)
        {
            switch (x)
            {
                case 0:
                    _mainCharaImage.sprite = character.GetCharaData(_charaNum).charaSprites[x];
                    break;
                case 1:
                    _mainCharaImage.sprite = character.GetCharaData(_charaNum).charaSprites[x];
                    break;
                case 2:
                    _mainCharaImage.sprite = character.GetCharaData(_charaNum).charaSprites[x];
                    break;
                case 3:
                    _mainCharaImage.sprite = character.GetCharaData(_charaNum).charaSprites[x];
                    break;
                case 4:
                    _mainCharaImage.sprite = character.GetCharaData(_charaNum).charaSprites[x];
                    break;
                case 5:
                    _mainCharaImage.sprite = character.GetCharaData(_charaNum).charaSprites[x];
                    break;
                case 6:
                    _mainCharaImage.sprite = character.GetCharaData(_charaNum).charaSprites[x];
                    break;
            }
        }
        else
        {
            switch (x)
            {
                case 0:
                    _mainCharaImage.sprite = character.GetCharaData(_charaNum).charaSprites_Hadaka[x];
                    break;
                case 1:
                    _mainCharaImage.sprite = character.GetCharaData(_charaNum).charaSprites_Hadaka[x];
                    break;
                case 2:
                    _mainCharaImage.sprite = character.GetCharaData(_charaNum).charaSprites_Hadaka[x];
                    break;
                case 3:
                    _mainCharaImage.sprite = character.GetCharaData(_charaNum).charaSprites_Hadaka[x];
                    break;
                case 4:
                    _mainCharaImage.sprite = character.GetCharaData(_charaNum).charaSprites_Hadaka[x];
                    break;
                case 5:
                    _mainCharaImage.sprite = character.GetCharaData(_charaNum).charaSprites_Hadaka[x];
                    break;
                case 6:
                    _mainCharaImage.sprite = character.GetCharaData(_charaNum).charaSprites_Hadaka[x];
                    break;
            }
        }
    }

    void Num1()
    {
        messageText1 = character.GetCharaData(_charaNum).message[0];
        ButtonImage1.sprite = character.GetCharaData(_charaNum).Hthumneil[0];
    }
    void Num2()
    {
        messageText2 = character.GetCharaData(_charaNum).message[1];
        ButtonImage2.sprite = character.GetCharaData(_charaNum).Hthumneil[1];
    }
    void NumL()
    {
        messageText1 = character.GetCharaData(_charaNum).message[0];
        ButtonImageL.sprite = character.GetCharaData(_charaNum).Hthumneil[0];
    }
    void CheckElse1()
    {
        messageText1 = null;
        ButtonImage1.sprite = blackimage;
    }
    void CheckElse2()
    {
        messageText2 = null;
        ButtonImage2.sprite = blackimage;
    }

   void Group1On()
    {
            ButtonGroup2.SetActive(false);
            ButtonGroup1.SetActive(true);
    }

    void Group2On()
    {
            ButtonGroup1.SetActive(false);
            ButtonGroup2.SetActive(true);
    }
    public void CheckClearFlag(int x)
    {
        switch (x)
        {
            case 4://アトリア１
                Group1On();
                clearflag = story.StoryClearFlag(StoryState.StoryList.Story04);
                if (clearflag == true)
                {
                    Num1();
                }
                else
                {
                    CheckElse1();
                }
                break;
            case 6://ルーシー１
                Group1On();
                clearflag = story.StoryClearFlag(StoryState.StoryList.Story06);
                if (clearflag == true)
                {
                    Num1();
                }
                else
                {
                    CheckElse1();
                }
                break;
            case 7://ラウラ１
                Group2On();
                clearflag = story.StoryClearFlag(StoryState.StoryList.Story07);
                if (clearflag == true)
                {
                    NumL();
                }
                else
                {
                    CheckElse1();
                }
                break;
            case 9://アトリア２
                Group1On();
                clearflag = story.StoryClearFlag(StoryState.StoryList.Story09);
                if (clearflag == true)
                {
                    Num2();
                }
                else
                {
                    CheckElse2();
                }
                break;
            case 12://イザル１
                Group1On();
                clearflag = story.StoryClearFlag(StoryState.StoryList.Story12);
                if (clearflag == true)
                {
                    Num1();
                }
                else
                {
                    CheckElse1();
                }
                break;
            case 13://イザル２
                Group1On();
                clearflag = story.StoryClearFlag(StoryState.StoryList.Story13);
                if (clearflag == true)
                {
                    Num2();
                }
                else
                {
                    CheckElse2();
                }
                break;
            case 14://ルーシー２
                Group1On();
                clearflag = story.StoryClearFlag(StoryState.StoryList.Story14);
                if (clearflag == true)
                {
                    Num2();
                }
                else
                {
                    CheckElse2();
                }
                break;
            case 15://オクシア１
                Group1On();
                clearflag = story.StoryClearFlag(StoryState.StoryList.Story15);
                if (clearflag == true)
                {
                    Num1();
                }
                else
                {
                    CheckElse1();
                }
                break;
            case 17://ウェズ１
                Group1On();
                clearflag = story.StoryClearFlag(StoryState.StoryList.Story17);
                if (clearflag == true)
                {
                    Num1();
                }
                else
                {
                    CheckElse1();
                }
                break;
            case 18://ウェズ２
                Group1On();
                clearflag = story.StoryClearFlag(StoryState.StoryList.Story18);
                if (clearflag == true)
                {
                    Num2();
                }
                else
                {
                    CheckElse2();
                }
                    break;
            case 20://エルナト１
                Group1On();
                clearflag = story.StoryClearFlag(StoryState.StoryList.Story20);
                if (clearflag == true)
                {
                    Num1();
                }
                else
                {
                    CheckElse1();
                }
                break;
            case 22://エルナト２
                Group1On();
                clearflag = story.StoryClearFlag(StoryState.StoryList.Story22);
                if (clearflag == true)
                {
                    Num2();
                }
                else
                {
                    CheckElse2();
                }
                break;
            case 26://オクシア２
                Group1On();
                clearflag = story.StoryClearFlag(StoryState.StoryList.Story26);
                if (clearflag == true)
                {
                    Num2();
                }
                else
                {
                    CheckElse2();
                }
                break;
        }
    }

    public void OnStory1()
    {
        if (messageText1 != null)
        {
            storyButton.GH1true();
            fadeCanvas.FadeAToB();
            flowchart.SendFungusMessage(messageText1);
            selectAction._GameStateManager._GameState.Value = GameState.Story;
            SEManager.Instance.Play(SEPath.MENU5_A);
        }
        else
        {
            SEManager.Instance.Play(SEPath.MENU1_C);
        }

    }
    public void OnStory2()
    {
        if (messageText2 != null)
        {
            storyButton.GH1true();
            fadeCanvas.FadeAToB();
            flowchart.SendFungusMessage(messageText2);
            selectAction._GameStateManager._GameState.Value = GameState.Story;
            SEManager.Instance.Play(SEPath.MENU5_A);
        }
        else
        {
            SEManager.Instance.Play(SEPath.MENU1_C);
        }
    }
    public void OnLaura1()
    {
        if (messageText1 != null)
        {
            storyButton.GH2true();
            fadeCanvasL.FadeAToB();
            flowchart.SendFungusMessage(messageText1);
            selectAction._GameStateManager._GameState.Value = GameState.Story;
            SEManager.Instance.Play(SEPath.MENU5_A);
        }
        else
        {
            SEManager.Instance.Play(SEPath.MENU1_C);
        }
    }
}
