using UnityEngine;
using UnityEngine.UI;
public class STG_GetScoreGroup : MonoBehaviour
{
    public STG_Score score;

    public Image image;

    public Slider slider;

    public  Sprite defaultIMG;
    void Awake()
    {
        defaultIMG = Resources.Load<Sprite>("hatena");
        score = GameObject.Find("ScoreGroup").GetComponent<STG_Score>();
        image= GameObject.Find("EnemyThumbnail").GetComponent<Image>();
        slider = GameObject.Find("EnemyHP_bar").GetComponent<Slider>();
    }
}
