using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using KanKikuchi.AudioManager;
public class GallertStoryButton : MonoBehaviour
{
    public string messageText1;
    public string messageText2;
    bool clearflag;

    [SerializeField]
    GameStateManager gameState;

    [SerializeField]
    Flowchart flowchart;

    [SerializeField]
    StoryScrollbar story;

    [SerializeField]
    FadeCanvasMy fadeCanvas;

    [SerializeField]
    UISelectAction selectAction;
    
    //public void OnStory1()
    //{
    //    if (messageText1 != null)
    //    {
    //        fadeCanvas.FadeAToB();
    //        flowchart.SendFungusMessage(messageText1);
    //        selectAction._GameStateManager._GameState.Value = GameState.Story;
    //    }
        
    //}
    //public void OnStory2()
    //{
    //    if (messageText2 != null)
    //    {
    //        fadeCanvas.FadeAToB();
    //        flowchart.SendFungusMessage(messageText2);
    //        selectAction._GameStateManager._GameState.Value = GameState.Story;
    //    }
        
    //}

}
