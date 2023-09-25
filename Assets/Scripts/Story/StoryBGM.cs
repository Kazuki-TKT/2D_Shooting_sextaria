using UnityEngine;
using KanKikuchi.AudioManager;
public class StoryBGM : MonoBehaviour
{
    int _nowClip=100;
    [SerializeField]
    AudioClip[] _seClip;

    public float volumeRate;
    public void SEStart(int x,bool play)
    {
        _nowClip = x;
        SEManager.Instance.Play(_seClip[x], isLoop: play);
    }
    public void SEStop()
    {
        if (_nowClip == 100) {
            Debug.Log(_nowClip);
            return; }
        switch (_nowClip)
        {
            case 0:
                SEManager.Instance.Stop(SEPath.SHASEI);
                break;
            case 1:
                SEManager.Instance.Stop(SEPath.PISTON_NORMAL);
                break;
            case 2:
                SEManager.Instance.Stop(SEPath.PISTON_FIRST);
                break;
            case 3:
                SEManager.Instance.Stop(SEPath.PISTON_SHASEI);
                break;
            case 4:
                SEManager.Instance.Stop(SEPath.PIZR_NORMAL);
                break;
            case 5:
                SEManager.Instance.Stop(SEPath.PIZR_FIRST);
                break;
        }
        _nowClip = 100;
    }
    public void BGM_Utyu01()
    {
        BGMSwitcher.FadeOut(BGMPath.YUYAKE_OVERLAY, volumeRate: volumeRate);
    }
    public void BGM_Joy()
    {
        BGMSwitcher.FadeOut(BGMPath.GGBGM_11_HAPPENINGMP3CUTNET, volumeRate: volumeRate);
    }

    public void BGM_Night()
    {
        BGMSwitcher.FadeOut(BGMPath.GGBGM_15_NIGHTMP3CUTNET, volumeRate: volumeRate);
    }

    public void BGM_EnemySex()
    {
        BGMSwitcher.FadeOut(BGMPath.GGBGM_24_EMOTINON8MP3CUTNET, volumeRate: volumeRate);
    }
    public void BGM_RucySex()
    {
        BGMSwitcher.FadeOut(BGMPath.GGBGM_23_EMOTINON7MP3CUTNET, volumeRate: volumeRate);
    }

    public void BGM_Nurse()
    {
        BGMSwitcher.FadeOut(BGMPath.GGBGM_13_BEACH2MP3CUTNET, volumeRate: volumeRate);
    }

    public void BGM_Afternoon()
    {
        BGMSwitcher.FadeOut(BGMPath.GGBGM_03_AFTERNOONMP3CUTNET, volumeRate: volumeRate);
    }
    public void BGM_Town()
    {
        BGMSwitcher.FadeOut(BGMPath.GGBGM_02_TOWNMP3CUTNET, volumeRate: volumeRate);
    }
    public void BGM_City()
    {
        BGMSwitcher.FadeOut(BGMPath.GGBGM_05_CITYMP3CUTNET, volumeRate: volumeRate);
    }
    public void BGM_Commical()
    {
        BGMSwitcher.FadeOut(BGMPath.GGBGM_06_COMICALMP3CUTNET, volumeRate: volumeRate);
    }

    public void BGM_Lounge()
    {
        BGMSwitcher.FadeOut(BGMPath.GGBGM_10_LOUNGEMP3CUTNET, volumeRate: volumeRate);
    }

    public void BGM_THUNDERBOLT()
    {
        BGMSwitcher.FadeOut(BGMPath.THUNDERBOLT, volumeRate: volumeRate);
    }

    public void BGM_LazyNight()
    {
        BGMSwitcher.FadeOut(BGMPath.LAZY_NIGHT, volumeRate: volumeRate);
    }

    public void BGM_SURVIVING_CYBER()
    {
        BGMSwitcher.FadeOut(BGMPath.SURVIVING_CYBER, volumeRate: volumeRate);
    }

    public void BGM_Dancing()
    {
        BGMSwitcher.FadeOut(BGMPath.DANCINGAT_UNIVERSE, volumeRate: volumeRate);
    }

    public void BGM_Sad()
    {
        BGMSwitcher.FadeOut(BGMPath.GGBGM_09_SADMP3CUTNET, volumeRate: volumeRate);
    }
    public void BGM_EveryDay()
    {
        BGMSwitcher.FadeOut(BGMPath.GGBGM_01_EVERYDAYMP3CUTNET, volumeRate: volumeRate);
    }
}
