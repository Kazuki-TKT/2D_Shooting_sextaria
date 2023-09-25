using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;
public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    SEAssistant se;

    public GameObject prefab,prefab2,prefab3; // 生成するオブジェクトのプレファブ
    public int objectEasyCount; // 生成するオブジェクトの数
    public int objectNormalCount; // 生成するオブジェクトの数
    public int objectHardCount; // 生成するオブジェクトの数

    [SerializeField]
    STG_GameLevelManager gameLevel;
    private void Start()
    {
        //SpawnObjects();
    }
    
    public void SpawnObjects()
    {
        se.Play();
        switch (gameLevel._GameLevel.Value)
        {
            case GameLevel.Easy:
                for (int i = 0; i < objectEasyCount; i++)
                {
                    Instantiate(prefab, transform.position, Quaternion.identity);
                }
                break;
            case GameLevel.Normal:
                for (int i = 0; i < objectNormalCount; i++)
                {
                    Instantiate(prefab2, transform.position, Quaternion.identity);
                }
                break;
            case GameLevel.Hard:
                for (int i = 0; i < objectHardCount; i++)
                {
                    Instantiate(prefab3, transform.position, Quaternion.identity);
                }
                break;
        }
    }
    
}
