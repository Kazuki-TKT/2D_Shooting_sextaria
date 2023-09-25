using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyDataBaseManager : MonoBehaviour
{
    public static EnemyDataBaseManager instance;    // シングルトン用の変数です

    [Header("EnemyDataListのスクリプタブル・オブジェクト")]
    public EnemyDataList enemyDataList;        // publicですので、インスペクターでアサインします

    [Header("生成するアイテムのプレファブ")]
    public GameObject[] dropItemPrefabs;       // EnemyBaseに個別で持たせていたアイテムのプレファブ情報をこちらで集約して扱うようにします(登録や処理が楽になります) 

    //[Header("生成する弾幕のプレファブ")]
    //public GameObject[] useEnemyBullet;
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

    /// <summary>
    /// 敵のデータベースを敵の番号で検索し、敵の情報(EnemyData)を戻す
    /// </summary>
    /// <param name="enemyNo">敵の番号</param>
    /// <returns></returns>
    public EnemyDataList.EnemyData GetEnemyData(int enemyNo)
    {

        //////////////////* ①か②のいずれかの処理で検索できます。どちらかを記載してください。  */////////////////////

        // ①Findで検索する場合(using Systemが必要になります)

        // EnemyDataを初期化してインスンタンスする(使用できる状態にする)
        EnemyDataList.EnemyData enemyData = new EnemyDataList.EnemyData();

        // enemyNoを使ってenemyDatas(List)を検索し、対象となった敵の情報をenemyDataへ代入する
        enemyData = enemyDataList.enemyDatas.Find((x) => x.no == enemyNo);

        // 敵の情報をEnemyBaseに戻して使えるようにします
        return enemyData;

        ///////////////////////////////////////////////////

        // ②foreachで検索する場合
        // enemyDatasの情報を1つずつdata変数に取り出し、順番にenemyNoと照合します
        //foreach (EnemyDataList.EnemyData data in enemyDataList.enemyDatas)
        //{
        //    // リストに登録されている敵の番号と照合している敵の番号とが合致したら、それが今回使う敵の情報になります
        //    if (data.no == enemyNo)
        //    {
        //        // 敵の情報をEnemyBaseに戻して使えるようにします
        //        return data;
        //    }
        //}
        //return null;
    }

    /// <summary>
    /// ドロップするアイテムの番号で配列のindexを特定し、アイテムプレファブの情報(GameObject)を取得して戻す
    /// </summary>
    /// <param name="itemNo">ドロップするアイテムの番号</param>
    /// <returns></returns>
    public GameObject GetDropItemPrefabDate(int itemNo)
    {
        return dropItemPrefabs[itemNo];
    }

    //public GameObject UseEnemyBulletPrefabData(int bulletNo)
    //{
    //    return useEnemyBullet[bulletNo];
    //}
}
