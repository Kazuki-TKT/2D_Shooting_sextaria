using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STG_shootChanger : MonoBehaviour
{
    [SerializeField]
    UbhShotCtrl[] ubhShot;

    //Set
    UbhShotCtrl useShot;
    STG_GameLevelManager gameLevel;

    public bool Attack;
    void Start()
    {
        gameLevel = GameObject.Find("GameStateManager").GetComponent<STG_GameLevelManager>();
        switch (gameLevel._GameLevel.Value)
        {
            case GameLevel.Easy:
                if (ubhShot[0] != null)
                {
                    useShot = ubhShot[0];
                }
                else
                {
                    Debug.Log("SETされていません");
                }
                break;
            case GameLevel.Normal:
                if (ubhShot[1] != null)
                {
                    useShot = ubhShot[1];
                }
                else
                {
                    Debug.Log("SETされていません");
                }
                break;
            case GameLevel.Hard:
                if (ubhShot[2] != null)
                {
                    useShot = ubhShot[2];
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
        if (useShot != null) useShot.StartShotRoutine();
    }

    public void Stop_EnemyShooting()
    {
        if (useShot != null) useShot.StopShotRoutine();
    }

    /// <summary>
    /// INTの数字が難易度になっている
    /// </summary>
    /// <param name="Num">0=Easy,1=Normal,3=Hard,</param>
    public void Start_EnemyShooting_Level(int Num)
    {
        if (Attack == false) return;
        switch (Num)
        {
            case 0://Easy
                if (useShot != null && gameLevel._GameLevel.Value == GameLevel.Easy) { useShot.StartShotRoutine(); }else { return; }
                break;
            case 1://Normal
                if (useShot != null && gameLevel._GameLevel.Value == GameLevel.Normal) { useShot.StartShotRoutine(); }else { return; }
                break;
            case 2://Hard
                if (useShot != null && gameLevel._GameLevel.Value == GameLevel.Hard) { useShot.StartShotRoutine(); }else { return; }
                break;
        }
    }
}
