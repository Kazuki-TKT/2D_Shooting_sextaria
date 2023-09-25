using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;
public class STG_PowerUp : MonoBehaviour
{
    [SerializeField]
    STG_PlayerShip player;

    [SerializeField]
    MMFeedbacks _mmFeedback;
    [SerializeField]
    ParticleSystem maxPowerParticle;

    [SerializeField]
    STG_PowerUPBulletManager _powerupMana;

    //パワーのキテスト
    [SerializeField]
    private Text m_powerText = null;
    //スコア
    public int m_power;
    private bool sub1 = false, sub2 = false,max=false;

    const int MAX_POWER = 200;
    const int MIN_POWER = 0;

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private GameObject[] _powerIcon;

    [SerializeField]
    private GameObject[] _shotPoint;

    public int selectSubNum;
    public int selectSubNumFree;
    [Space(30)]
    [SerializeField]
    GameObject[] specialObj;

    public int specialNum;
    public int specialNumFree;

    public bool testMax;

    public bool _storyFlag, _freeFlag;
    void Start()
    {
        m_power = MIN_POWER;
        if(testMax) m_power = MAX_POWER;
    }
    private void OnEnable()
    {
        DeadPower();
        m_powerText.text = m_power.ToString();
        slider.value = m_power;
        max = false;
    }
    public void SelectSubNum(int x)
    {
        selectSubNum = x;
    }
    public void SelectSpecialNum(int x)
    {
        specialNum = x;
    }
    public void SelectSubNumFree(int x)
    {
        selectSubNumFree = x;
    }
    public void SelectSpecialNumFree(int x)
    {
        specialNumFree = x;
    }
    public void PowerStoryFlag()
    {
        _storyFlag = true;
        _freeFlag = false;
    }
    public void PowerFreeFlag()
    {
        _storyFlag = false;
        _freeFlag = true;
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = m_power;

        if (m_power >= 80 && sub1 == false)
        {
            if (_storyFlag == true)
            {
                switch (selectSubNum)
                {
                    case 1:
                        _powerupMana.ChangeSub1Bullet(PowerUpBulletsSub1.BulletsSub1.SubBullet1_1);
                        break;
                    case 2:
                        _powerupMana.ChangeSub1Bullet(PowerUpBulletsSub1.BulletsSub1.SubBullet1_2);
                        break;
                    case 3:
                        _powerupMana.ChangeSub1Bullet(PowerUpBulletsSub1.BulletsSub1.SubBullet1_3);
                        break;
                    case 4:
                        _powerupMana.ChangeSub1Bullet(PowerUpBulletsSub1.BulletsSub1.SubBullet1_4);
                        break;
                    case 5:
                        _powerupMana.ChangeSub1Bullet(PowerUpBulletsSub1.BulletsSub1.SubBullet1_5);
                        break;
                }
            }
            if (_freeFlag == true)
            {
                switch (selectSubNumFree)
                {
                    case 1:
                        _powerupMana.ChangeSub1Bullet(PowerUpBulletsSub1.BulletsSub1.SubBullet1_1);
                        break;
                    case 2:
                        _powerupMana.ChangeSub1Bullet(PowerUpBulletsSub1.BulletsSub1.SubBullet1_2);
                        break;
                    case 3:
                        _powerupMana.ChangeSub1Bullet(PowerUpBulletsSub1.BulletsSub1.SubBullet1_3);
                        break;
                    case 4:
                        _powerupMana.ChangeSub1Bullet(PowerUpBulletsSub1.BulletsSub1.SubBullet1_4);
                        break;
                    case 5:
                        _powerupMana.ChangeSub1Bullet(PowerUpBulletsSub1.BulletsSub1.SubBullet1_5);
                        break;
                }
            }

            _powerIcon[0].SetActive(true);
            sub1 = true;
        }
        else if (m_power >=160 && sub2 == false)
        {
            if (_storyFlag == true)
            {
                switch (selectSubNum)
                {
                    case 1:
                        _powerupMana.ChangeSub2Bullet(PowerUpBulletsSub2.BulletsSub2.SubBullet2_1);
                        break;
                    case 2:
                        _powerupMana.ChangeSub2Bullet(PowerUpBulletsSub2.BulletsSub2.SubBullet2_2);
                        break;
                    case 3:
                        _powerupMana.ChangeSub2Bullet(PowerUpBulletsSub2.BulletsSub2.SubBullet2_3);
                        break;
                    case 4:
                        _powerupMana.ChangeSub2Bullet(PowerUpBulletsSub2.BulletsSub2.SubBullet2_4);
                        break;
                    case 5:
                        _powerupMana.ChangeSub2Bullet(PowerUpBulletsSub2.BulletsSub2.SubBullet2_5);
                        break;
                }
            }
            if (_freeFlag == true)
            {
                switch (selectSubNumFree)
                {
                    case 1:
                        _powerupMana.ChangeSub2Bullet(PowerUpBulletsSub2.BulletsSub2.SubBullet2_1);
                        break;
                    case 2:
                        _powerupMana.ChangeSub2Bullet(PowerUpBulletsSub2.BulletsSub2.SubBullet2_2);
                        break;
                    case 3:
                        _powerupMana.ChangeSub2Bullet(PowerUpBulletsSub2.BulletsSub2.SubBullet2_3);
                        break;
                    case 4:
                        _powerupMana.ChangeSub2Bullet(PowerUpBulletsSub2.BulletsSub2.SubBullet2_4);
                        break;
                    case 5:
                        _powerupMana.ChangeSub2Bullet(PowerUpBulletsSub2.BulletsSub2.SubBullet2_5);
                        break;
                }
            }
            _powerIcon[1].SetActive(true);
            sub2 = true;
        }
        else if (m_power >= 200&&max==false)
        {
            maxPowerParticle.Play();
            max = true;
            _powerIcon[2].SetActive(true);
            m_powerText.text = "MAX";
            GetUseAbility();
        }

        if (m_power < 200)
        {
            m_powerText.text = m_power.ToString();
            if (max == true) {
                maxPowerParticle.Stop();
                max = false;
            } 
        }
    }
    public void AddPoint(int point)
    {
        _mmFeedback.PlayFeedbacks();
        m_power += point;
        m_power = System.Math.Min(m_power, MAX_POWER);
        m_power = System.Math.Max(m_power, MIN_POWER);
        //if (m_score < MIN_SCORE) m_score = MIN_SCORE;
    }

    public void DeadPower()
    {
        m_power = MIN_POWER;
        if (sub1 == true)
        {
            sub1 = false;
            _powerIcon[0].SetActive(false);
            _powerupMana.OffSub1Bullet();
        }
        if (sub2 == true)
        {
            sub2 = false;
            _powerIcon[1].SetActive(false);
            _powerupMana.OffSub2Bullet();
        }
        
            _powerIcon[2].SetActive(false);
       
        
    }

    public GameObject Special()
    {
        GameObject special=null;
        if (_storyFlag==true)
        {
            switch (specialNum)
            {
                case 1:
                    special = specialObj[0];
                    break;
                case 2:
                    special = specialObj[1];
                    break;
                case 3:
                    special = specialObj[2];
                    break;
                case 4:
                    special = specialObj[3];
                    break;
                case 5:
                    special = specialObj[4];
                    break;
                case 6:
                    special = specialObj[5];
                    break;
                default:
                    special = null; // 他のケースに対するデフォルトの値を設定
                    break;
            }
        }
        if (_freeFlag == true)
        {
            switch (specialNumFree)
            {
                case 1:
                    special = specialObj[0];
                    break;
                case 2:
                    special = specialObj[1];
                    break;
                case 3:
                    special = specialObj[2];
                    break;
                case 4:
                    special = specialObj[3];
                    break;
                case 5:
                    special = specialObj[4];
                    break;
                case 6:
                    special = specialObj[5];
                    break;
                default:
                    special = null; // 他のケースに対するデフォルトの値を設定
                    break;
            }
        }
        return special;
    }
    public void GetUseAbility()
    {
        
        //Debug.Log("スペシャルアップ");
        switch (player._specialPoint)
        {
            case 0://〇
                player._specialObj[0].SetActive(true);
                player._specialPoint += 1;
                break;
            case 1://〇〇
                player._specialObj[1].SetActive(true);
                player._specialPoint += 1;
                break;
            case 2://〇〇〇
                player._specialObj[2].SetActive(true);
                player._specialPoint += 1;
                break;
            case 3://〇〇〇MAX
                STG_Score _score = GameObject.Find("ScoreGroup").GetComponent<STG_Score>();
                _score.AddPoint(800);
                break;
        }

    }
}
