using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;
using UnityEngine;

public class STG_Manager : MonoBehaviour
{
    public const int BASE_SCREEN_WIDTH = 600;
    public const int BASE_SCREEN_HEIGHT = 450;

    [FormerlySerializedAs("_ScaleToFit")]
    public bool m_scaleToFit = false;

    [SerializeField, FormerlySerializedAs("_PlayerPrefab")]
    private GameObject m_playerPrefab = null;

    //タイトル画面
    [SerializeField, FormerlySerializedAs("_GoTitle")]
    private GameObject m_goTitle = null;
    //[SerializeField, FormerlySerializedAs("_GoLetterBox")]
    //private GameObject m_goLetterBox = null;

    //スコア
    [SerializeField, FormerlySerializedAs("_Score")]
    private STG_Score m_score = null;


    [SerializeField]
    public STG_Emiiter _emiiter = null;

    //[SerializeField]
    //public STG_EmiiterUni _emiiteruni = null;

    [SerializeField]
    public STG_TutorialEmiiter _tutoEmiiter= null;

    [SerializeField]
    public STG_Boss _boss = null;
    [SerializeField]
    public STG_TutorialEnemy _tutorialEnemy = null;
    private void Start()
    {
        //m_goLetterBox.SetActive(m_scaleToFit == false);
    }

    private void Update()
    {
        //if (IsPlaying())
        //{
        //    return;
        //}
        //else
        //{
        //    //if (Input.GetKeyDown(KeyCode.X))
        //    //{
        //    //    GameStart();
        //    //}
        //}
    }

    public void PlayerSet(bool set)
    {
        m_playerPrefab.SetActive(true);
    }

    private void GameStart()
    {
        if (m_score != null)
        {
            m_score.Initialize();
        }

        if (m_goTitle != null)
        {
            m_goTitle.SetActive(false);
        }

        CreatePlayer();
    }

    public void GameOver()
    {
        //if (m_score != null)
        //{
        //    m_score.Save();
        //}

        if (m_goTitle != null)
        {
            m_goTitle.SetActive(true);
        }
        else
        {
            // for UBH_ShotShowcase scene.
            CreatePlayer();
        }
    }

    private void CreatePlayer()
    {
        UbhPlayer player = FindObjectOfType<UbhPlayer>();
        if (player != null &&
            player.isDead == false)
        {
            return;
        }

        Instantiate(m_playerPrefab, m_playerPrefab.transform.position, m_playerPrefab.transform.rotation);
    }

    public bool IsPlaying()
    {
        if (m_goTitle != null)
        {
            return m_goTitle.activeSelf == false;
        }
        else
        {
            // for UBH_ShotShowcase scene.
            return true;
        }
    }

    public void STG_GameOver()
    {
        if (_tutoEmiiter!= null)
        {
            _tutoEmiiter.Stop_StoryEmiiter();
            GameObject objectsWithTag = GameObject.FindWithTag("Wave");
            Destroy(objectsWithTag);
            _tutorialEnemy = null;
        }
        if (_tutorialEnemy != null)
        {
            _tutorialEnemy.MobGameOver();
            UbhObjectPool.instance.ReleaseAllBullet();
            _tutorialEnemy = null;
        }
        if (_emiiter != null)
        {
            _emiiter.Stop_StoryEmiiter();
            DestroyObjectsWithName("DropItem");
            GameObject objectsWithTag = GameObject.FindWithTag("Wave");
            Destroy(objectsWithTag);
            UbhObjectPool.instance.ReleaseAllBullet();
            _emiiter = null;
        }
        if (_boss != null)
        {
            _boss.BossGameOver();
            UbhObjectPool.instance.ReleaseAllBullet();
            _boss = null;
        }
    }
    public void EmitterOff()
    {
        if (_emiiter != null)
        {
            _emiiter.Stop_StoryEmiiter();
        }
    }
    public void DestroyObjectsWithName(string targetTag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }
    public void BulletDelete()
    {
        UbhObjectPool.instance.ReleaseAllBullet();
        DestroyObjectsWithName("DropItem");
        GameObject objectsWithTag = GameObject.FindWithTag("Wave");
        Destroy(objectsWithTag);
        _emiiter = null;
    }
    public void StopButtle()
    {
        if (_emiiter != null)
        {
            _emiiter.Stop_StoryEmiiter();
            DestroyObjectsWithName("DropItem");
            GameObject objectsWithTag = GameObject.FindWithTag("Wave");
            Destroy(objectsWithTag);
            UbhObjectPool.instance.ReleaseAllBullet();
            _emiiter = null;
        }
        
    }
}
