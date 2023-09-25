using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using KanKikuchi.AudioManager;


public class GameStateManager : MonoBehaviour
{
    [SerializeField]
    Text stateText;

    public GameStateReactiveProperty _GameState;

    public bool logEnable;

    string bgmName;
    // Start is called before the first frame update
    private void Awake()
    {
        Application.targetFrameRate = 60;
        if (logEnable == true)
        {
            Debug.unityLogger.logEnabled = false;
        }
    }
    void Start()
    {

        _GameState
          .DistinctUntilChanged()
          .Subscribe(_ => Log());
    }

    // Update is called once per frame
    void Update()
    {
        //BGMSwitcher.FadeOut(BGMPath.BATTLE27);
    }

    private void Log()
    {
        //stateText.text = _GameState.Value.ToString();
        //Debug.Log($"<color=yellow><b>{_GameState.Value}</b></color>");
        switch (_GameState.Value)
        {
            case GameState.Title:
                BGMManager.Instance.Play(
                    audioPath: BGMPath.COMET_HIGHWAY, //再生したいオーディオのパス
                    volumeRate: 0.7f,                  //音量の倍率
                    delay: 0,                 //再生されるまでの遅延時間
                    pitch: 1f,                 //ピッチ
                    isLoop: true,             //ループ再生するか
                    allowsDuplicate: false    //他のBGMと重複して再生させるか
                    );
                break;
            case GameState.MainMenu:
                var currentBGMNames = BGMManager.Instance.GetCurrentAudioNames();
                foreach (var name in currentBGMNames)
                {
                   bgmName = name;
                }
                if (bgmName== "Comet_Highway") return;
                BGMSwitcher.FadeOut(BGMPath.COMET_HIGHWAY, volumeRate: 0.7f, isLoop: true);
                break;
            case GameState.StoryMenu:
                BGMSwitcher.FadeOut(BGMPath.DAILY_NEWS, isLoop: true, volumeRate: 1f);
                break;
            case GameState.GameScore:
                BGMSwitcher.FadeOut(BGMPath.BITWORKS, isLoop: true, volumeRate: 1f);
                break;
            case GameState.Character1st:
                var currentBGMNamess = BGMManager.Instance.GetCurrentAudioNames();
                foreach (var name in currentBGMNamess)
                {
                    bgmName = name;
                }
                if (bgmName == "flashparty") return;
                BGMSwitcher.FadeOut(BGMPath.FLASHPARTY, isLoop: true, volumeRate: 1f);
                break;
            case GameState.Character2nd:
                var currentBGMNamesss = BGMManager.Instance.GetCurrentAudioNames();
                foreach (var name in currentBGMNamesss)
                {
                    bgmName = name;
                }
                if (bgmName == "flashparty") return;
                BGMSwitcher.FadeOut(BGMPath.FLASHPARTY, isLoop: true, volumeRate: 1f);
                break;
            case GameState.GameSetting:
                BGMSwitcher.FadeOut(BGMPath.SHIKOTSUISEKI, isLoop: true, volumeRate: 1f);
                break;
            case GameState.FreeMode:
                BGMSwitcher.FadeOut(BGMPath.GODLORD, isLoop: true, volumeRate: 1f);
                break;
        }
    }

    // Debug.Log("<color=yellow><b>このメッセージの色を変えるよ！</b></color>");
}
