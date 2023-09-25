using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
public class StoryScrollbar : MonoBehaviour
{
    private string saveDataPath = "SaveData";
    public static StoryScrollbar Instance { get; private set; }

    [SerializeField] List<StoryState> storystate;

    [SerializeField]
    Image _storyImage,_Icon,_IconBack;

    [SerializeField]
    Text _title, _storyText;

    [SerializeField]
    Sprite _unlockImage,_HIconImage, _AtIconImage;
    void Start()
    {
        LoadClearStates();
    }

    void Update()
    {


    }

    public void StoryOpen(StoryState.StoryList storyList)
    {
        StoryState data = storystate.Find(data => data.storyList==storyList);
        //クリアフラグをON
        if (data.Clear == false)
        {
            data.Clear = true;
            SaveClearState(storyList, data.Clear);
        }
        //data.button.image.sprite = data.storySprite;
    }

    public void TaikenStoryOpen()
    {
        StoryOpen(StoryState.StoryList.Story01);
        StoryOpen(StoryState.StoryList.Story02);
        StoryOpen(StoryState.StoryList.Story03);
        StoryOpen(StoryState.StoryList.Story04);
        StoryOpen(StoryState.StoryList.Story05);
        StoryOpen(StoryState.StoryList.Story06);
        StoryOpen(StoryState.StoryList.Story07);
        StoryOpen(StoryState.StoryList.Story08);
    }

    public void AllStoryOpen()
    {
        foreach (StoryState data in storystate)
        {
            // Set the clear flag to true for each story
            data.Clear = true;
            SaveClearState(data.storyList, data.Clear);
        }
    }
    public void AllStoryFalse()
    {
        bool firstIteration = true;
        foreach (StoryState data in storystate)
        {
            if (firstIteration)
            {
                // Skip the first iteration
                firstIteration = false;
                continue;
            }
            // Set the clear flag to true for each story
            data.Clear = false;
        }
    }
    public bool StoryClearFlag(StoryState.StoryList storyList)
    {
        StoryState data = storystate.Find(data => data.storyList == storyList);
        //クリアフラグをON
        return data.Clear;
    }

    public void SelectStory(StoryState.StoryList storyList)
    {
        StoryState data = storystate.Find(data => data.storyList == storyList);
        if (data.Clear == true)
        {
            _storyImage.sprite = data.storySprite;
            _title.text = data.storyTitle;
            _storyText.text = "";
            if (data.HSecne==true)
            {
                _IconBack.color= new Color32(255,131,131,255);
                _Icon.color = new Color32(255, 255, 255, 255);
                _Icon.sprite = _HIconImage;
            }
            else if (data.Attack == true)
            {
                _IconBack.color = new Color32(152,0,10,255);
                _Icon.color = new Color32(255, 255, 255, 255);
                _Icon.sprite = _AtIconImage;
            }
            else
            {
                _IconBack.color = new Color32(0,0,0,0);
                _Icon.color = new Color32(0, 0, 0, 0);
                _Icon.sprite = null;
            }
        }
        else
        {
            _storyImage.sprite = _unlockImage;
            _title.text = "? ? ? ? ?";
            _storyText.text = data.storytext+"をクリアしてください";
            _IconBack.color = new Color32(0, 0, 0, 0);
            _Icon.color = new Color32(0, 0, 0, 0);
            _Icon.sprite = null;
        }
    }
    public void SaveClearState(StoryState.StoryList storyList, bool clear)
    {
        // Clearフラグを保存するファイルパスを作成
        string filePath = Application.persistentDataPath + "/ClearStates.json";

        // 既存のデータを読み込む
        Dictionary<string, bool> clearStates = new Dictionary<string, bool>();
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            clearStates = JsonConvert.DeserializeObject<Dictionary<string, bool>>(json);
        }

        // 既存のデータを保持しながら新しいデータを追加する
        if (clearStates.ContainsKey(storyList.ToString()))
        {
            clearStates[storyList.ToString()] = clear;
        }
        else
        {
            clearStates.Add(storyList.ToString(), clear);
        }

        // ClearフラグをJSON形式にシリアライズする
        string updatedJson = JsonConvert.SerializeObject(clearStates);

        // ファイルに書き出す
        File.WriteAllText(filePath, updatedJson);
    }
    //public void SaveClearState(StoryState.StoryList storyList, bool clear)
    //{
    //    // Clearフラグを保存するファイルパスを作成
    //    //string filePath = saveDataPath + "/ClearStates.json";
    //    string filePath = Application.persistentDataPath + "/ClearStates.json";

    //    // Clearフラグの辞書を作成
    //    Dictionary<string, bool> clearStates = new Dictionary<string, bool>();
    //    clearStates[storyList.ToString()] = clear;

    //    // ClearフラグをJSON形式にシリアライズする
    //    string json = JsonConvert.SerializeObject(clearStates);

    //    // ファイルに書き出す
    //    File.WriteAllText(filePath, json);
    //}
    public void LoadClearStates()
    {
        // Clearフラグを保存するファイルパスを作成
        //string filePath = saveDataPath + "/ClearStates.json";
        string filePath = Application.persistentDataPath + "/ClearStates.json";
        // ファイルが存在しなければ、何もしない
        if (!File.Exists(filePath))
        {
            return;
        }

        // ファイルからJSONデータを読み込む
        string json = File.ReadAllText(filePath);

        // JSONデータをデシリアライズする
        Dictionary<string, bool> clearStates = JsonConvert.DeserializeObject<Dictionary<string, bool>>(json);

        // StoryStateのClearフラグを更新する
        foreach (StoryState state in storystate)
        {
            if (clearStates.ContainsKey(state.storyList.ToString()))
            {
                state.Clear = clearStates[state.storyList.ToString()];
            }
        }
    }
}

[System.Serializable]
public class StoryState
{
    public enum StoryList
    {
        Story01,
        Story02,
        Story03,
        Story04,
        Story05,
        Story06,
        Story07,
        Story08,
        Story09,
        Story10,
        Story11,
        Story12,
        Story13,
        Story14,
        Story15,
        Story16,
        Story17,
        Story18,
        Story19,
        Story20,
        Story21,
        Story22,
        Story23,
        Story24,
        Story25,
        Story26,
    }

    public StoryList storyList;
    public Sprite storySprite;
    public Button button;
    public bool Clear;
    public string storyTitle;
    [Multiline(3)]
    public string storytext;
    public bool HSecne = false;
    public bool Attack = false;
}
