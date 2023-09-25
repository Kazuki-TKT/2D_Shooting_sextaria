using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STG_BossShootChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    [SerializeField]
    STG_GameLevelManager gameLevel;

    [Space(30)]
    [SerializeField]
    UbhShotCtrl[] ubhShotEasy;
    [SerializeField]
    UbhShotCtrl[] ubhShotNormal;
    [SerializeField]
    UbhShotCtrl[] ubhShotHard;
    //Set
    [Space(50)]
    [Header("攻撃1")]
    [SerializeField]
    UbhShotCtrl useShot1=null;

    [Header("攻撃2")]
    [SerializeField]
    UbhShotCtrl useShot2 = null;

    [Header("攻撃3")]
    [SerializeField]
    UbhShotCtrl useShot3 = null;

    [Header("攻撃4")]
    [SerializeField]
    UbhShotCtrl useShot4 = null;

    [Header("攻撃5")]
    [SerializeField]
    UbhShotCtrl useShot5 = null;

    [Header("攻撃6")]
    [SerializeField]
    UbhShotCtrl useShot6 = null;

    [Header("攻撃7")]
    [SerializeField]
    UbhShotCtrl useShot7 = null;

    [Header("攻撃8")]
    [SerializeField]
    UbhShotCtrl useShot8 = null;
    void Start()
    {
        if(gameLevel ==null)
        gameLevel = GameObject.Find("GameStateManager").GetComponent<STG_GameLevelManager>();
    }

    private void OnEnable()
    {
        spriteRenderer.color = new Color32(255, 255, 255, 255); 
        BossLevelChange();
    }

    private void BossLevelChange()
    {
        switch (gameLevel._GameLevel.Value)
        {
            case GameLevel.Easy:
                ShotSet(ubhShotEasy);
                break;
            case GameLevel.Normal:
                ShotSet(ubhShotNormal);
                break;
            case GameLevel.Hard:
                ShotSet(ubhShotHard);
                break;
        }
    }

    private void ShotSet(UbhShotCtrl[] ubh)
    {
        if (ubh[0] != null) useShot1 = ubh[0];
        if (ubh[1] != null) useShot2 = ubh[1];
        if (ubh[2] != null) useShot3 = ubh[2];
        if (ubh[3] != null) useShot4 = ubh[3];
        if (ubh[4] != null) useShot5 = ubh[4];
        if (ubh[5] != null) useShot6 = ubh[5];
        if (ubh[6] != null) useShot7 = ubh[6];
        if (ubh[7] != null) useShot8 = ubh[7];
    }
    public void All_BossStopShooting()
    {
        //useShot1 = null;
        //useShot2 = null;
        //useShot3 = null;
        //useShot4 = null;
        //useShot5 = null;
        //useShot6 = null;
        //useShot7 = null;
        //useShot8 = null;
        if(useShot1 != null)
        {
            useShot1.StopShotRoutineAndPlayingShot();
            if (useShot1.Shooting.Value == true)
            {
                
            }
        }
        if (useShot2 != null)
        {
            useShot2.StopShotRoutineAndPlayingShot();
            if (useShot2.Shooting.Value == true)
            {
                
            }
        }
        if (useShot3 != null)
        {
            useShot3.StopShotRoutineAndPlayingShot();
            if (useShot3.Shooting.Value == true)
            {
                
            }
        }
        if (useShot4 != null)
        {
            useShot4.StopShotRoutineAndPlayingShot();
            if (useShot4.Shooting.Value == true)
            {
                
            }
        }
        if (useShot5 != null)
        {
            useShot5.StopShotRoutineAndPlayingShot();
            if (useShot5.Shooting.Value == true)
            {
                
            }
        }
        if (useShot6 != null)
        {
            useShot6.StopShotRoutineAndPlayingShot();
            if (useShot6.Shooting.Value == true)
            {
                
            }
        }
        if (useShot7 != null)
        {
            useShot7.StopShotRoutineAndPlayingShot();
            if (useShot7.Shooting.Value == true)
            {
                
            }
        }
        if (useShot8 != null)
        {
            useShot8.StopShotRoutineAndPlayingShot();
            if (useShot8.Shooting.Value == true)
            {
                
            }
        }
    }
    //---------
    public void Start1_BossShooting()
    {
        if (useShot1 != null) useShot1.StartShotRoutine();
    }
    public void Stop1_BossShooting()
    {
        if (useShot1 != null) useShot1.StopShotRoutine();
    }
    //----------
    public void Start2_BossShooting()
    {
        if (useShot2 != null) useShot2.StartShotRoutine();
    }
    public void Stop2_BossShooting()
    {
        if (useShot2 != null) useShot2.StopShotRoutine();
    }
    //----------
    public void Start3_BossShooting()
    {
        if (useShot3 != null) useShot3.StartShotRoutine();
    }
    public void Stop3_BossShooting()
    {
        if (useShot3 != null) useShot3.StopShotRoutine();
    }
    //----------
    public void Start4_BossShooting()
    {
        if (useShot4 != null) useShot4.StartShotRoutine();
    }
    public void Stop4_BossShooting()
    {
        if (useShot4 != null) useShot4.StopShotRoutine();
    }
    //----------
    public void Start5_BossShooting()
    {
        if (useShot5 != null) useShot5.StartShotRoutine();
    }
    public void Stop5_BossShooting()
    {
        if (useShot5 != null) useShot5.StopShotRoutine();
    }
    //----------
    public void Start6_BossShooting()
    {
        if (useShot6 != null) useShot6.StartShotRoutine();
    }
    public void Stop6_BossShooting()
    {
        if (useShot6 != null) useShot6.StopShotRoutine();
    }
    //----------
    public void Start7_BossShooting()
    {
        if (useShot7 != null) useShot7.StartShotRoutine();
    }
    public void Stop7_BossShooting()
    {
        if (useShot7 != null) useShot7.StopShotRoutine();
    }
    //----------
    public void Start8_BossShooting()
    {
        if (useShot8 != null) useShot8.StartShotRoutine();
    }
    public void Stop8_BossShooting()
    {
        if (useShot8 != null) useShot8.StopShotRoutine();
    }
}
