using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KanKikuchi.AudioManager;

public class GameAudioSetting : MonoBehaviour
{
    [SerializeField]
    AudioSource _voiceSource;

    [SerializeField]
    private float _bgmVolume=0.6f;

    [SerializeField]
    private float _seVolume = 0.6f;

    [SerializeField]
    private float _vcVolume = 0.6f;
    [SerializeField]
    Text[] _bgmText;

    [SerializeField]
    Text[] _seText;

    [SerializeField]
    Text[] _vcText;

    private void Awake()
    {
        _bgmVolume = PlayerPrefs.GetFloat("BGM", 1f);
        _seVolume = PlayerPrefs.GetFloat("SE", 1f);
        _vcVolume = PlayerPrefs.GetFloat("VC", 1f);
        _voiceSource.volume = _vcVolume;
        BGMManager.Instance.ChangeBaseVolume(_bgmVolume);
        SEManager.Instance.ChangeBaseVolume(_seVolume);
        
        for (int i = 0; i < _bgmText.Length; i++)
        {
            _bgmText[i].text = "" + _bgmVolume * 100;
            _seText[i].text = "" + _seVolume * 100;
            _vcText[i].text = "" + _vcVolume * 100;
        }
    }
    void Start()
    {

        //_bgmVolume = 0.6f;
        //
        //_bgmVolume = PlayerPrefs.GetFloat("BGM", 1f);
        //_seVolume = PlayerPrefs.GetFloat("SE", 1f);
        //_vcVolume= PlayerPrefs.GetFloat("VC", 1f);
        //_voiceSource.volume = _vcVolume;
        //BGMManager.Instance.ChangeBaseVolume(_bgmVolume);
        //SEManager.Instance.ChangeBaseVolume(_seVolume);
        //BGMManager.Instance.Play(
        //            audioPath: BGMPath.COMET_HIGHWAY, //再生したいオーディオのパス
        //              //音量の倍率
        //            delay: 0,                 //再生されるまでの遅延時間
        //            pitch: 1,                 //ピッチ
        //            isLoop: true,             //ループ再生するか
        //            allowsDuplicate: false    //他のBGMと重複して再生させるか
        //            );
        //for(int i = 0; i < _bgmText.Length; i++)
        //{
        //    _bgmText[i].text = "" + _bgmVolume * 100;
        //    _seText[i].text = "" + _seVolume * 100;
        //    _vcText[i].text = "" + _vcVolume * 100;
        //}
        //_bgmText[0].text = "" + _bgmVolume * 100;
        //_bgmText[1].text = "" + _bgmVolume * 100;
        //_bgmText[2].text = "" + _bgmVolume * 100;
        //_seText[0].text = "" + _seVolume * 100;
        //_seText[1].text = "" + _seVolume * 100;
        //_seText[2].text = "" + _seVolume * 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setting_BGM_Volume()
    {
        //BGM全体のボリュームを変更
        if (_bgmVolume >= 1)
        {
            _bgmVolume = 0;
            for (int i = 0; i < _bgmText.Length; i++)
            {
                _bgmText[i].text = "" + _bgmVolume * 100;
            }
            //_bgmText[0].text = "" + _bgmVolume * 100;
            //_bgmText[1].text = "" + _bgmVolume * 100;
            //_bgmText[2].text = "" + _bgmVolume * 100;
            BGMManager.Instance.ChangeBaseVolume(_bgmVolume);
            return;
        }

        _bgmVolume += 0.2f;
        BGMManager.Instance.ChangeBaseVolume(_bgmVolume);
        Debug.Log($"BGM音量：<color=#00ff00ff><b>{_bgmVolume}</b></color>");
        for (int i = 0; i < _bgmText.Length; i++)
        {
            _bgmText[i].text = "" + _bgmVolume * 100;
        }
        //_bgmText[0].text = ""+_bgmVolume * 100;
        //_bgmText[1].text = "" + _bgmVolume * 100;
        //_bgmText[2].text = "" + _bgmVolume * 100;
        //
        PlayerPrefs.SetFloat("BGM", _bgmVolume);
        PlayerPrefs.Save();
       

    }

    public void Setting_SE_Volume()
    {
        //SE全体のボリュームを変更
        if (_seVolume >= 1)
        {
            _seVolume = 0;
            for (int i = 0; i < _seText.Length; i++)
            {
                _seText[i].text = "" + _seVolume * 100;
            }
            //_seText[0].text = "" + _seVolume * 100;
            //_seText[1].text = "" + _seVolume * 100;
            //_seText[2].text = "" + _seVolume * 100;
            SEManager.Instance.ChangeBaseVolume(_seVolume);
            return;
        }
        _seVolume += 0.2f;
        SEManager.Instance.ChangeBaseVolume(_seVolume);
        Debug.Log($"SE音量：<color=#00ff00ff><b>{_seVolume}</b></color>");
        for (int i = 0; i < _seText.Length; i++)
        {
            _seText[i].text = "" + _seVolume * 100;
        }
        //_seText[0].text = "" + _seVolume * 100;
        //_seText[1].text = "" + _seVolume * 100;
        //_seText[2].text = "" + _seVolume * 100;
        //
        PlayerPrefs.SetFloat("SE", _seVolume);
        PlayerPrefs.Save();
    }

    public void Setting_VC_Volume()
    {
        //SE全体のボリュームを変更
        if (_vcVolume >= 1)
        {
            _vcVolume = 0;
            for (int i = 0; i < _vcText.Length; i++)
            {
                _vcText[i].text = "" + _vcVolume;
            }
            _voiceSource.volume = _vcVolume;
            return;
        }
        _vcVolume += 0.2f;
        _voiceSource.volume = _vcVolume;
        Debug.Log($"VC音量：<color=#00ff00ff><b>{_vcVolume}</b></color>");
        for (int i = 0; i < _vcText.Length; i++)
        {
            _vcText[i].text = "" + _vcVolume * 100;
        }
        
        PlayerPrefs.SetFloat("VC", _vcVolume);
        PlayerPrefs.Save();
    }
    public void BGMText()
    {
        _bgmText[0].text = "" + _bgmVolume * 100;
    }
    public void SEText()
    {
        _seText[0].text = "" + _seVolume * 100;
    }
}
