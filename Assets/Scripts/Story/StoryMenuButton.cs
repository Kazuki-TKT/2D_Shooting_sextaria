using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Fungus;
using KanKikuchi.AudioManager;

public class StoryMenuButton : MonoBehaviour, ISelectHandler
{
    public Scrollbar scrollbar;

    [SerializeField]
    STG_Start start;
    [SerializeField]
    GameObject GameStartCanvas;

    [SerializeField]
    float barVal;

    [SerializeField]
    GameStateManager gameState;

    [SerializeField]
    StoryScrollbar story;

    [SerializeField]
    Flowchart flowchart;

    [SerializeField]
    FadeCanvasMy fadeCanvas;

    [SerializeField]
    UISelectAction selectAction;


    public string messageText;

    bool clearflag;
    
    private void Start()
    {

    }

    public void selectedButton()
    {

    }

    public void OnClick_Story(int x)
    {
        Debug.Log(gameState._GameState.Value);
        if (gameState._GameState.Value == GameState.StoryMenu)
        {
            switch (x)
            {
                case 1:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story01);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 2:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story02);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        //戦闘
                        OnButtleStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 3:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story03);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {

                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 4:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story04);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 5:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story05);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 6:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story06);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 7:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story07);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        //戦闘
                        //OnButtleStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 8:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story08);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 9:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story09);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 10:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story10);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        //戦闘

                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 11:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story11);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 12:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story12);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 13:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story13);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 14:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story14);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 15:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story15);
                    if (clearflag == true)
                    {
                        //戦闘
                        SEManager.Instance.Play(SEPath.MENU5_A);
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 16:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story16);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 17:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story17);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 18:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story18);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 19:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story19);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 20:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story20);
                    if (clearflag == true)
                    {
                        
                        //戦闘
                        SEManager.Instance.Play(SEPath.MENU5_A);
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 21:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story21);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 22:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story22);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 23:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story23);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        //戦闘
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 24:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story24);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
                case 25:
                    clearflag = story.StoryClearFlag(StoryState.StoryList.Story25);
                    if (clearflag == true)
                    {
                        SEManager.Instance.Play(SEPath.MENU5_A);
                        OnStory();
                    }
                    else
                    {
                        SEManager.Instance.Play(SEPath.MENU1_C);
                    }
                    break;
            }

            
        }
    }
    public void OnSelectStory(int x)
    {
        if (gameState._GameState.Value == GameState.StoryMenu)
        {
            switch (x)
            {
                case 1:
                    story.SelectStory(StoryState.StoryList.Story01);
                    break;
                case 2:
                    story.SelectStory(StoryState.StoryList.Story02);
                    break;
                case 3:
                    story.SelectStory(StoryState.StoryList.Story03);
                    break;
                case 4:
                    story.SelectStory(StoryState.StoryList.Story04);
                    break;
                case 5:
                    story.SelectStory(StoryState.StoryList.Story05);
                    break;
                case 6:
                    story.SelectStory(StoryState.StoryList.Story06);
                    break;
                case 7:
                    story.SelectStory(StoryState.StoryList.Story07);
                    break;
                case 8:
                    story.SelectStory(StoryState.StoryList.Story08);
                    break;
                case 9:
                    story.SelectStory(StoryState.StoryList.Story09);
                    break;
                case 10:
                    story.SelectStory(StoryState.StoryList.Story10);
                    break;
                case 11:
                    story.SelectStory(StoryState.StoryList.Story11);
                    break;
                case 12:
                    story.SelectStory(StoryState.StoryList.Story12);
                    break;
                case 13:
                    story.SelectStory(StoryState.StoryList.Story13);
                    break;
                case 14:
                    story.SelectStory(StoryState.StoryList.Story14);
                    break;
                case 15:
                    story.SelectStory(StoryState.StoryList.Story15);
                    break;
                case 16:
                    story.SelectStory(StoryState.StoryList.Story16);
                    break;
                case 17:
                    story.SelectStory(StoryState.StoryList.Story17);
                    break;
                case 18:
                    story.SelectStory(StoryState.StoryList.Story18);
                    break;
                case 19:
                    story.SelectStory(StoryState.StoryList.Story19);
                    break;
                case 20:
                    story.SelectStory(StoryState.StoryList.Story20);
                    break;
                case 21:
                    story.SelectStory(StoryState.StoryList.Story21);
                    break;
                case 22:
                    story.SelectStory(StoryState.StoryList.Story22);
                    break;
                case 23:
                    story.SelectStory(StoryState.StoryList.Story23);
                    break;
                case 24:
                    story.SelectStory(StoryState.StoryList.Story24);
                    break;
                case 25:
                    story.SelectStory(StoryState.StoryList.Story25);
                    break;
            }


        }
    }
    public void OnSelect(BaseEventData eventData)
    {
        scrollbar.value = barVal;
    }

    public void OnStory()
    {
        fadeCanvas.FadeAToB();
        flowchart.SendFungusMessage(messageText);
        selectAction._GameStateManager._GameState.Value = GameState.Story;
    }

    public void OnButtleStory()
    {
        //fadeCanvas.FadeA_IN();
        //GameStartCanvas.SetActive(true);
        //fadeCanvas.FadeA_OUT();
        
        fadeCanvas.FadeAToB();
        start.message = messageText;
        //flowchart.SendFungusMessage(messageText);
        //selectAction._GameStateManager._GameState.Value = GameState.GamingStory;
        //StartCoroutine(ButtleStoryCoroutine());
    }

    public void MessageSet(string text)
    {
        messageText = text;
    }
    
    //private IEnumerator ButtleStoryCoroutine()
    //{
    //    fadeCanvas.FadeA_IN();
    //    GameStartCanvas.SetActive(true);
    //    fadeCanvas.FadeA_OUT();
    //    yield return StartCoroutine(MyFunction());
    //    flowchart.SendFungusMessage(messageText);
    //    selectAction._GameStateManager._GameState.Value = GameState.GamingStory;
    //}
    //IEnumerator MyFunction()
    //{
    //    // MyFunctionの処理
    //    _mmFeedback.PlayFeedbacks();
    //    yield break;
    //}

}
