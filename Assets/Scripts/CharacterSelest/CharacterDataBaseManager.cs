using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataBaseManager : MonoBehaviour
{
    public static CharacterDataBaseManager instance;    // シングルトン用の変数です

    [Header("CharacterDataBaseのスクリプタブル・オブジェクト")]
    public CharacterDataBase charaDataList;        // publicですので、インスペクターでアサインします
    void Awake()
    {
        // このゲームオブジェクトをシングルトンにし、かつ、シーン遷移しても破棄されないようにします
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public CharacterDataBase.CharaData GetCharaData(int charaNo)
    {

        CharacterDataBase.CharaData charaData = new CharacterDataBase.CharaData();
        charaData = charaDataList.charaDatas.Find((x) => x.no == charaNo);
        // 敵の情報をEnemyBaseに戻して使えるようにします
        return charaData;
    }
}
