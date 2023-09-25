using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class STG_PowerUPBulletManager : MonoBehaviour
{
    [SerializeField]
    SEAssistant OnSubSE;

    [SerializeField]
    ParticleSystem sub1Particle;

    [SerializeField]
    ParticleSystem sub2Particle;

    [SerializeField]
    UbhShotCtrl.ShotInfo[] shotCtrl;

    [SerializeField]
    UbhShotCtrl ubhM,ubhS1,ubhS2;
    [Space(5)]

    [SerializeField] List<PowerUpBulletsMain> PowerUpBulletsMains;

    [SerializeField] List<PowerUpBulletsSub1> PowerUpBulletsSub1s;

    [SerializeField] List<PowerUpBulletsSub2> PowerUpBulletsSub2s;

    GameObject subBulletObj1, subBulletObj2;
    private void Start()
    {
        //MainBullet(PowerUpBulletsMain.BulletsMain.MainBullet1);
    }
    public void ChangeMainBullet(PowerUpBulletsMain.BulletsMain bullets)
    {
        
        PowerUpBulletsMain data = PowerUpBulletsMains.Find(data => data.bulletsMain == bullets);
        data.baseShotMainObject.SetActive(true);
        shotCtrl[0].m_shotObj = data.baseShotMain;
        shotCtrl[0].m_afterDelay = data.derayTime;
        ubhM.m_shotList[0]=shotCtrl[0];
    }

    public void ChangeSub1Bullet(PowerUpBulletsSub1.BulletsSub1 bullets)
    {
        sub1Particle.Play();
        OnSubSE.Play();
        PowerUpBulletsSub1 data = PowerUpBulletsSub1s.Find(data => data.bulletsSub1 == bullets);
        data.baseShotSub1Object.SetActive(true);
        subBulletObj1 = data.baseShotSub1Object;
        shotCtrl[1].m_shotObj = data.baseShotSub1;
        shotCtrl[1].m_afterDelay = data.derayTime;
        ubhS1.m_shotList[0] = shotCtrl[1];
    }
    public void OffSub1Bullet()
    {
        subBulletObj1.SetActive(false);
    }

    public void ChangeSub2Bullet(PowerUpBulletsSub2.BulletsSub2 bullets)
    {
        sub2Particle.Play();
        OnSubSE.Play();
        PowerUpBulletsSub2 data = PowerUpBulletsSub2s.Find(data => data.bulletsSub2 == bullets);
        data.baseShotSub2Object.SetActive(true);
        subBulletObj2 = data.baseShotSub2Object;
        shotCtrl[2].m_shotObj = data.baseShotSub2;
        shotCtrl[2].m_afterDelay = data.derayTime;
        ubhS2.m_shotList[0] = shotCtrl[2];
    }

    public void OffSub2Bullet()
    {
        subBulletObj2.SetActive(false);
    }
}

[System.Serializable]
public class PowerUpBulletsMain
{
    public enum BulletsMain
    {
        MainBullet1,
        MainBullet2,
        MainBullet3,
    }

    public BulletsMain bulletsMain;
    public GameObject baseShotMainObject;
    public UbhBaseShot baseShotMain;
    public float derayTime;
}

[System.Serializable]
public class PowerUpBulletsSub1
{
    public enum BulletsSub1
    {
        SubBullet1_1,
        SubBullet1_2,
        SubBullet1_3,
        SubBullet1_4,
        SubBullet1_5,
    }

    public BulletsSub1 bulletsSub1;
    public GameObject baseShotSub1Object;
    public UbhBaseShot baseShotSub1;
    public float derayTime;
}

[System.Serializable]
public class PowerUpBulletsSub2
{
    public enum BulletsSub2
    {
        SubBullet2_1,
        SubBullet2_2,
        SubBullet2_3,
        SubBullet2_4,
        SubBullet2_5,
    }

    public BulletsSub2 bulletsSub2;
    public GameObject baseShotSub2Object;
    public UbhBaseShot baseShotSub2;
    public float derayTime;
}
