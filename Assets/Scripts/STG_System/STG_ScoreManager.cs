using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class ScoreDataWrapper
{
    public ScoreDataCollection scores;
}

[System.Serializable]
public class ScoreData
{
    public int score;
    public int stage;
    public string difficulty;
    public string stageDifficulty;
}

[System.Serializable]
public class ScoreDataCollection
{
    public Dictionary<string, List<ScoreData>> scores = new Dictionary<string, List<ScoreData>>();
}

public class STG_ScoreManager : MonoBehaviour
{
    private string saveDataPath;
    public STG_GameLevelManager gameLevelManager;
    public ScoreDataCollection highScores;

    private void Start()
    {
        //---
        //saveDataPath = Path.Combine(Application.persistentDataPath, "SaveData");
        //if (!Directory.Exists(saveDataPath))
        //{
        //    Directory.CreateDirectory(saveDataPath);
        //}
        //--
        highScores = LoadScores();
    }

    public void AddScore(int score, int stage, string difficulty)
    {
        ScoreData newScore = new ScoreData();
        newScore.score = score;
        newScore.stage = stage;
        newScore.difficulty = difficulty;
        newScore.stageDifficulty = stage + "-" + difficulty;

        if (!highScores.scores.ContainsKey(newScore.stageDifficulty))
        {
            highScores.scores[newScore.stageDifficulty] = new List<ScoreData>();
        }

        highScores.scores[newScore.stageDifficulty].Add(newScore);
        highScores.scores[newScore.stageDifficulty] = highScores.scores[newScore.stageDifficulty]
            .OrderByDescending(s => s.score)
            .Take(5)
            .ToList();

        SaveScores();
    }

    public void ResetScores()
    {
        highScores.scores.Clear();
        SaveScores();
    }

    private ScoreDataCollection LoadScores()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "scores.json");
        //string filePath = Path.Combine(saveDataPath, "scores.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            ScoreDataWrapper wrapper = JsonConvert.DeserializeObject<ScoreDataWrapper>(json);
            if (wrapper != null)
            {
                return wrapper.scores;
            }
        }

        return new ScoreDataCollection();
    }

    private void SaveScores()
    {
        ScoreDataWrapper wrapper = new ScoreDataWrapper();
        wrapper.scores = highScores;
        string json = JsonConvert.SerializeObject(wrapper);

        string filePath = Path.Combine(Application.persistentDataPath, "scores.json");
        //string filePath = Path.Combine(saveDataPath, "scores.json");
        File.WriteAllText(filePath, json);
    }

    public void OnClick(int stageNum)
    {
        string difficulty = gameLevelManager._GameLevel.Value.ToString();
        int score = 900 * stageNum;
        int stage = stageNum;
        AddScore(score, stage, difficulty);
    }

    public void Test()
    {
        foreach (var kvp in highScores.scores)
        {
            string stageDifficulty = kvp.Key;
            List<ScoreData> scores = kvp.Value;
            foreach (ScoreData score in scores)
            {
                Debug.Log("Score: " + score.score + " Stage: " + score.stage + " Difficulty: " + score.difficulty);
            }
        }
    }

    // ステージと難易度に対して一番高いスコアを取得する関数
    public int GetHighestScore(int stage, string difficulty)
    {
        if (highScores != null && highScores.scores.ContainsKey(stage + "-" + difficulty))
        {
            List<ScoreData> gamescores = highScores.scores[stage + "-" + difficulty].Take(5).ToList();
            ScoreData highestScores = gamescores.OrderByDescending(s => s.score).First();
            return highestScores.score;
        }
        else
        {
            Debug.LogWarning("Difficulty " + difficulty + " not found.");
            return 0;
        }


        //    // 指定した難易度が存在しない場合は0を返す
        //    if (!highScores.scores.ContainsKey(difficulty))
        //{
        //    Debug.LogWarning("Difficulty " + difficulty + " not found.");
        //    return 0;
        //}

        //// 指定したステージと難易度のスコアリストを取得
        //List<ScoreData> scores = highScores.scores[difficulty].Where(s => s.stage == stage).ToList();

        //// スコアリストが空の場合は0を返す
        //if (scores.Count == 0)
        //{
        //    return 0;
        //}

        //// スコアリストをスコアの降順にソートし、一番高いスコアを取得して返す
        //ScoreData highestScore = scores.OrderByDescending(s => s.score).First();
        //return highestScore.score;
    }

    public void GameScoreSave(int stagescore,int stageNum)
    {
        string difficulty = gameLevelManager._GameLevel.Value.ToString();
        int score = stagescore;
        int stage = stageNum;
        AddScore(score, stage, difficulty);
    }
}
