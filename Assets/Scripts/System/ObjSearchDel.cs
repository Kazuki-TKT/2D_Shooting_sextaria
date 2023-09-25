using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSearchDel : MonoBehaviour
{
    

    public void DeleteObjectsWithWord(string wordToDelete)
    {
        GameObject[] objects = FindObjectsOfType<GameObject>(); // シーン内の全てのゲームオブジェクトを取得

        foreach (GameObject obj in objects)
        {
            if (obj.name.Contains(wordToDelete))
            {
                Destroy(obj); // オブジェクトを削除
                Debug.Log("削除されました: " + obj.name);
            }
        }
    }
}
