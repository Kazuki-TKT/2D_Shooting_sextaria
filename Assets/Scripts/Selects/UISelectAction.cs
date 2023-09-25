using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using KanKikuchi.AudioManager;

public class UISelectAction : MonoBehaviour
{
    public GameStateManager _GameStateManager;
    public Button _firstSelect;

    [SerializeField]
    private Button _homeButton;

    Navigation nav;

    public Button _lastSelectButton;

    int seNum = 0;

    void Start()
    {
        if (_homeButton != null)
        {
            nav = _homeButton.navigation;
        }
    }

    private void OnEnable()
    {
        seNum = 0;
    }
    private void OnDisable()
    {
        seNum = 0;
    }
    private void Update()
    {

    }

    public void FirstSelect()
    {
        _firstSelect.Select();
        seNum = 1;
        //Debug.Log(seNum);
    }

    public void LastSelect()
    {
        _lastSelectButton.Select();
        seNum = 1;
        Debug.Log(_lastSelectButton);

        //Debug.Log(seNum);
    }
    public void ButtonSelect()
    {
        //現在セレクトしているボタンを取得し、
        //ホームボタンのセレクトアップに設定する
        GameObject selectedButton = EventSystem.current.currentSelectedGameObject;
        Button selectedButtonComponent = selectedButton.GetComponent<Button>();
        _lastSelectButton = selectedButtonComponent;
        //Debug.Log(_lastSelectButton);
        if (_homeButton != null && _homeButton != selectedButtonComponent)
        {
            nav.selectOnUp = selectedButtonComponent;
            _homeButton.navigation = nav;
            //Debug.Log(selectedButtonComponent);
        }

        if (seNum == 0) return;
        //SEManager.Instance.Play(SEPath.SELECT_001_1);

    }

    public void OK()
    {
        //SEManager.Instance.Play(SEPath.OK_001_1);
        seNum = 0;
    }

    public void StateMainMenu()
    {
        _GameStateManager._GameState.Value = GameState.MainMenu;
    }

    public void StateCharacter1stCanvas()
    {
        _GameStateManager._GameState.Value = GameState.Character1st;
    }

    public void StateCharacter2ndCanvas()
    {
        _GameStateManager._GameState.Value = GameState.Character2nd;
    }

    public void StateStoryMenu()
    {
        _GameStateManager._GameState.Value = GameState.StoryMenu;
    }

    public void StateStory()
    {
        _GameStateManager._GameState.Value = GameState.Story;
    }

    public void StateStorySkipMenu()
    {
        _GameStateManager._GameState.Value = GameState.StorySkipMenu;
    }
    public void StateSetting()
    {
        _GameStateManager._GameState.Value = GameState.GameSetting;
    }

    public void StateGaming()
    {
        _GameStateManager._GameState.Value = GameState.Gaming;
    }
    public void StateGamingStory()
    {
        _GameStateManager._GameState.Value = GameState.GamingStory;
    }
    public void StateGameScore()
    {
        _GameStateManager._GameState.Value = GameState.GameScore;
    }
    public void StateGameClear()
    {
        _GameStateManager._GameState.Value = GameState.GameClear;
    }

    public void StateFreeMode()
    {
        _GameStateManager._GameState.Value = GameState.FreeMode;
    }
}
