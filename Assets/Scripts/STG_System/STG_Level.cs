using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public enum GameLevel
{
    Easy,
    Normal,
    Hard
}

[System.Serializable]

public class GameLevelReactiveProperty : ReactiveProperty<GameLevel>
{
    public GameLevelReactiveProperty() { }
    public GameLevelReactiveProperty(GameLevel initialValue) : base(initialValue) { }
}
