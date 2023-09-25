using UnityEngine;
using KanKikuchi.AudioManager;

public class STG_BGM : MonoBehaviour
{

    public void BattleOut()
    {
        BGMSwitcher.FadeOut(BGMPath.KIKIKOMI, isLoop: true);
    }
    public void Atria_BGM1()
    {
        BGMSwitcher.FadeOut(BGMPath.BARSTSPEAD, isLoop: true);
    }
    public void Atria_BGM2()
    {
        BGMSwitcher.FadeOut(BGMPath.MICROCHIP, isLoop: true);
    }
    public void Izal_BGM1()
    {
        BGMSwitcher.FadeOut(BGMPath.SUPUNRING, isLoop: true);
    }
    public void Izal_BGM2()
    {
        BGMSwitcher.FadeOut(BGMPath.PAINRIGHT, isLoop: true);
    }
    public void Wes_BGM1()
    {
        BGMSwitcher.FadeOut(BGMPath.SKYFOX, isLoop: true);
    }
    public void Wes_BGM2()
    {
        BGMSwitcher.FadeOut(BGMPath.GRA_VITY_STRIKE_R, isLoop: true);
    }
    public void Elnath_BGM1()
    {
        BGMSwitcher.FadeOut(BGMPath.CHOZUNO, isLoop: true);
    }
    public void Elnath_BGM2()
    {
        BGMSwitcher.FadeOut(BGMPath.DEAD_BY_CROW, isLoop: true);
    }
    public void Oxia_BGM1()
    {
        BGMSwitcher.FadeOut(BGMPath.WARNING_EGG, isLoop: true);
    }
    public void Oxia_BGM2()
    {
        BGMSwitcher.FadeOut(BGMPath.APPSPICE, isLoop: true);
    }
    public void Ranshi_BGM()
    {
        BGMSwitcher.FadeOut(BGMPath.CHYCOFUTURE, isLoop: true);
    }
    public void Tuto_BGM()
    {
        BGMSwitcher.FadeOut(BGMPath.KAISYUKAIRO, isLoop: true);
    }
    public void Tuto_BGM2()
    {
        BGMSwitcher.FadeOut(BGMPath.FIREBALL, isLoop: true);
    }
    public void Mob_BGM()
    {
        BGMSwitcher.FadeOut(BGMPath.SLASHGYANG, isLoop: true);
    }
    public void Oxia_BGM3()
    {
        BGMSwitcher.FadeOut(BGMPath.SUITEKI, isLoop: true);
    }
}
