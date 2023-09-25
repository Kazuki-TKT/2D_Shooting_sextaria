using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STG_BigShipShootchanger : MonoBehaviour
{
    [SerializeField]
    UbhShotCtrl[] ubhShot;

    //Set
    UbhShotCtrl useShot1,useShot2;
    STG_GameLevelManager gameLevel;
    void Start()
    {
        gameLevel = GameObject.Find("GameStateManager").GetComponent<STG_GameLevelManager>();
        switch (gameLevel._GameLevel.Value)
        {
            case GameLevel.Easy:
                if (ubhShot[0] != null&& ubhShot[1] != null)
                {
                    useShot1 = ubhShot[0];
                    useShot2 = ubhShot[1];
                }
                else
                {
                    Debug.Log("SETされていません");
                }
                break;
            case GameLevel.Normal:
                if (ubhShot[2] != null && ubhShot[3] != null)
                {
                    useShot1 = ubhShot[2];
                    useShot2 = ubhShot[3];
                }
                else
                {
                    Debug.Log("SETされていません");
                }
                break;
            case GameLevel.Hard:
                if (ubhShot[4] != null && ubhShot[5] != null)
                {
                    useShot1 = ubhShot[4];
                    useShot2 = ubhShot[5];
                }
                else
                {
                    Debug.Log("SETされていません");
                }
                break;
        }



    }

    public void Start_EnemyShooting()
    {
        if (useShot1 != null && useShot2 != null)
        {
            useShot1.StartShotRoutine();
            useShot2.StartShotRoutine();
        }
    }

    public void Stop_EnemyShooting_BG()
    {
        if (useShot1 != null && useShot2 != null)
        {
            useShot1.StopShotRoutine();
            useShot2.StopShotRoutine();
        }
    }

    /// <summary>
    /// INTの数字が難易度になっている
    /// </summary>
    /// <param name="Num">0=Easy,1=Normal,3=Hard,</param>
    public void Start_EnemyShooting_Level_BG(int Num)
    {
        switch (Num)
        {
            case 0://Easy
                if (useShot1 != null && useShot2 != null && gameLevel._GameLevel.Value == GameLevel.Easy) {
                    useShot1.StartShotRoutine();
                    useShot2.StartShotRoutine();
                } else { return; }
                break;
            case 1://Normal
                if (useShot1 != null && useShot2 != null && gameLevel._GameLevel.Value == GameLevel.Normal) {
                    useShot1.StartShotRoutine();
                    useShot2.StartShotRoutine();
                } else { return; }
                break;
            case 2://Hard
                if (useShot1 != null && useShot2 != null && gameLevel._GameLevel.Value == GameLevel.Easy) {
                    useShot1.StartShotRoutine();
                    useShot2.StartShotRoutine();
                } else { return; }
                break;
        }
    }
}
