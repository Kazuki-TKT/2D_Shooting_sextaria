using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryOnStory : MonoBehaviour
{
    [SerializeField]
    StoryMenuButton storyMenu;

    public void StoryMenuButtonSet(StoryMenuButton storyMenuButton)
    {
        storyMenu = storyMenuButton;
    }

    public void Buttle()
    {
        storyMenu.OnButtleStory();
    }
}
