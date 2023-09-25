using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class STG_ScoreDisplay : MonoBehaviour
{
    public Text[] scoreTexts;
    public int stage;
    public string difficulty;
    [SerializeField]
    private STG_ScoreManager scoreManager;

    private void Start()
    {
        //scoreManager = FindObjectOfType<ScoreManager>();
        //UpdateScoreText();
        UpdateScoreText(1);
    }

    public void UpdateScoreText(int x)
    {
        stage = x;
        if (scoreManager.highScores != null && scoreManager.highScores.scores.ContainsKey(stage + "-" + difficulty))
        {
            List<ScoreData> scores = scoreManager.highScores.scores[stage + "-" + difficulty].Take(5).ToList();

            for (int i = 0; i < scoreTexts.Length; i++)
            {
                if (i < scores.Count)
                {
                    scoreTexts[i].text = scores[i].score + "pt";
                }
                else
                {
                    scoreTexts[i].text = "-";
                }
            }
        }
        else
        {
            for (int i = 0; i < scoreTexts.Length; i++)
            {
                scoreTexts[i].text = "-";
            }
        }
    }

    public void ResetScoreText()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
                scoreTexts[i].text = "-";
        }
    }
}
