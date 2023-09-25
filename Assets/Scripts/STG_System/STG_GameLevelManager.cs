using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class STG_GameLevelManager : MonoBehaviour
{
    public GameLevelReactiveProperty _GameLevel;

    // Start is called before the first frame update
    void Start()
    {
        _GameLevel
          .DistinctUntilChanged()
          .Subscribe(_ => Log());
    }

    private void Log()
    {
        Debug.Log($"<color=yellow><b>{_GameLevel.Value}</b></color>");
    }

    public void SelectLevel(int x)
    {
        switch (x)
        {
            case 1:
                _GameLevel.Value = GameLevel.Easy;
                break;
            case 2:
                _GameLevel.Value = GameLevel.Normal;
                break;
            case 3:
                _GameLevel.Value = GameLevel.Hard;
                break;
        }
        
    }
}
