using UnityEngine;
using Newtonsoft.Json;
using System.IO;
public class DleateSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeleteJsonFile(string fileName)
    {
        // ファイルパスを作成
        string filePath = Application.persistentDataPath + "/" + fileName + ".json";

        // ファイルが存在すれば削除する
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

}
