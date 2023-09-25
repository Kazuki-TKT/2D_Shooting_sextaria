using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class StoryButton : MonoBehaviour
{
    [SerializeField]
    GameStateManager gameState;

    public Flowchart flowchart;
    public FadeCanvasMy fade,fade2;
    public FadeCanvasMy fadeGH1=null,fadeGH2=null;
    [Header("GameObject")]
    public GameObject sayDialog,hSayDialog;
    public float waitTime = 1.0f;

    [Header("DialogInput.cs")]
    [SerializeField]
    DialogInput dialog,hDialog,ghDialog;

    [SerializeField]
    GameObject skipObj;

    [SerializeField]
    GameObject hBackObj;

    List<Block> blocks;

    public bool GH1, GH2;
    void Start()
    {
        //FFFFFF
    }

    public void SkipStory()
    {
        hBackObj.SetActive(false);
        StartCoroutine(StopStory());
    }
    public void SkipStoryGH()
    {
        hBackObj.SetActive(false);
        StartCoroutine(StopStoryGH());
    }
    public void SkipButtleStory()
    {
        StartCoroutine(StopButtleStory());
    }
    public void SkipButtleStoryFree()
    {
        StartCoroutine(StopButtleStoryFree());
    }
    IEnumerator StopStory()
    {
        if (Time.timeScale != 1)
        { Time.timeScale = 1; }
            if (flowchart != null && flowchart.HasExecutingBlocks())
        {
            flowchart.StopAllBlocks(); // 現在実行中のブロックを停止する
        }
        while (sayDialog.activeSelf|| hSayDialog.activeSelf)
        {
            yield return new WaitForSeconds(waitTime);
        }
        fade.FadeBToA();
    }
    IEnumerator StopStoryGH()
    {
        if (Time.timeScale != 1)
        { Time.timeScale = 1; }
        if (flowchart != null && flowchart.HasExecutingBlocks())
        {
            flowchart.StopAllBlocks(); // 現在実行中のブロックを停止する
        }
        while (sayDialog.activeSelf || hSayDialog.activeSelf)
        {
            yield return new WaitForSeconds(waitTime);
        }
        if (GH1 == true) { fadeGH1.FadeBToA();GH1 = false; };
        if (GH2 == true) { fadeGH2.FadeBToA(); GH2 = false; };
    }

    public void GH1true()
    {
        GH1 = true;GH2= false;
    }
    public void GH2true()
    {
        GH2 = true; GH1 = false;
    }
    IEnumerator StopButtleStory()
    {
        if (Time.timeScale != 1)
        { Time.timeScale = 1; }
        if (flowchart != null && flowchart.HasExecutingBlocks())
        {
            flowchart.StopAllBlocks(); // 現在実行中のブロックを停止する
        }
        yield return null;
        fade.FadeBToA();
    }
    IEnumerator StopButtleStoryFree()
    {
        if (Time.timeScale != 1)
        { Time.timeScale = 1; }
        if (flowchart != null && flowchart.HasExecutingBlocks())
        {
            flowchart.StopAllBlocks(); // 現在実行中のブロックを停止する
        }
        yield return null;
        fade2.FadeBToA();
    }
    public void StopFlowChart()
    {
        flowchart.StopAllBlocks();
    }

    public void NextCommands()
    {

        if (gameState._GameState.Value == GameState.Story|| gameState._GameState.Value == GameState.GamingStory || gameState._GameState.Value == GameState.GameClear)
        {
            dialog.SetNextLineFlag();
        }
        else
        {
            Debug.Log(gameState._GameState.Value);
        }
    }
    public void H_NextCommands()
    {

        if (gameState._GameState.Value == GameState.Story || gameState._GameState.Value == GameState.GamingStory)
        {
            hDialog.SetNextLineFlag();
        }
        else
        {
            Debug.Log(gameState._GameState.Value);
        }
    }
    public void GH_NextCommands()
    {

        if (gameState._GameState.Value == GameState.Story || gameState._GameState.Value == GameState.GamingStory)
        {
            ghDialog.SetNextLineFlag();
        }
        else
        {
            Debug.Log(gameState._GameState.Value);
        }
    }
    public void HbackOnOFF()
    {
        if (hBackObj.activeSelf==false)
        {
            hBackObj.SetActive(true);
        }
        else
        {
            hBackObj.SetActive(false);
            
        }
    }
  
    
}
