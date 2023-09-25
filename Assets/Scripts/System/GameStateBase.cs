using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public enum GameState
{
    None,
    Title,
    MainMenu,
    StoryMenu,
    Story,
    StorySkipMenu,
    Character1st,
    Character2nd,
    GamePause,
    GameScore,
    GameSetting,
    Gaming,
    GamingStory,
    GameOver,
    GameClear,
    Result,
    FreeMode,
}

[System.Serializable]

public class GameStateReactiveProperty : ReactiveProperty<GameState>
{
    public GameStateReactiveProperty() { }
    public GameStateReactiveProperty(GameState initialValue) : base(initialValue) { }
}
