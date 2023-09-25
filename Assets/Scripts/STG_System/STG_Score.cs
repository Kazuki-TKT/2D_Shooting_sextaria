using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using MoreMountains.Feedbacks;
using System.IO;

public class STG_Score : MonoBehaviour
{
    [SerializeField]
    MMFeedbacks _mmFeedback;


    public int stageNum;
    public STG_ScoreManager scoreManager;

    //スコアを保存する鍵
    private const string HIGH_SCORE_KEY = "highScoreKey";
    private const string HIGH_SCORE_TITLE = "HighScore : ";

    //スコアを消去するかどうか
    [SerializeField, FormerlySerializedAs("_DeleteScore")]
    private bool m_deleteScore = false;

    //スコアのキテスト
    [SerializeField]
    private Text m_scoreText = null;

    //ハイスコアのテキスト
    [SerializeField]
    private Text m_highScoreText = null;

    [SerializeField]
    Text GameClearText = null;
    [SerializeField]
    Text GameClearTextFree = null;
    //スコア
    public int m_score;

    //ハイスコア
    public int m_highScore;

    const int MIN_SCORE= 0;

    private void Start()
    {
        //Initialize();
    }

    private void Update()
    {
        if (m_highScore < m_score)
        {
            m_highScore = m_score;
        }

        m_scoreText.text = m_score.ToString();
        m_highScoreText.text = m_highScore.ToString();
    }
    private void OnEnable()
    {
        m_score = 0;
        m_scoreText.text = m_score.ToString();
    }
    public int ScoreReturn()
    {
        return m_score;
    }
    public void GameClearTexts()
    {
        GameClearText.text = m_score.ToString();
        GameClearTextFree.text = m_score.ToString();
    }
    public void Initialize()
    {
        if (m_deleteScore)
        {
            PlayerPrefs.DeleteAll();
        }
        m_score = 0;
        m_highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
    }

    public void AddPoint(int point)
    {
        _mmFeedback.PlayFeedbacks();
        m_score = m_score + point;
        m_score = System.Math.Max(m_score, MIN_SCORE);
    }

    public void Save()
    {
        scoreManager.GameScoreSave(m_score,stageNum);
        //PlayerPrefs.SetInt(HIGH_SCORE_KEY, m_highScore);
        //PlayerPrefs.Save();

        //Initialize();
    }

    public void StageNumSet(int x)
    {
        stageNum = x;
    }

    public void HighScore()
    {
        m_highScore = scoreManager.GetHighestScore(stageNum, scoreManager.gameLevelManager._GameLevel.Value.ToString());
        Debug.Log("StageNum :"+stageNum+ "Dificulty :"+scoreManager.gameLevelManager._GameLevel.Value.ToString()+ "HighScore :"+m_highScore);
        m_highScoreText.text=m_highScore.ToString();
    }

    public void ScoreReset()
    {
        m_score = 0;
        m_scoreText.text = m_score.ToString();
        m_highScore = 0;
        m_highScoreText.text = m_highScore.ToString();
    }
}

