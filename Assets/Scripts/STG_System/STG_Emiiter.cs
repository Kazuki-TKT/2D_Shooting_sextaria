using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
public class STG_Emiiter : MonoBehaviour
{
    [SerializeField]
    GameStateManager _gameState;

    [SerializeField, FormerlySerializedAs("_Waves")]
    private GameObject[] m_waves = null;

    [SerializeField]
    private int m_currentWave;

    [SerializeField]
    private STG_Manager stg_manager;

    Coroutine _someCoroutine;

    public bool test;

    GameObject nowwave;

    IEnumerator enumerator;
    private void Start()
    {
        if(test==true) _someCoroutine=StartCoroutine(StoryEmiiter());
    }

    private IEnumerator StoryEmiiter()
    {
        stg_manager._emiiter = this;
        if (m_waves.Length == 0)
        {
            yield break;
        }
        Debug.Log($"<color=#db7093><b>WaveLength :{m_waves.Length}</b></color>");
        while (m_currentWave<m_waves.Length-1)
        {
            if (_gameState._GameState.Value == GameState.GameOver)
            {
                if(nowwave != null) Destroy(nowwave);
                Debug.Log($"<color=#ff6347><b>緊急戦闘終了♡</b></color>");
                break;
            }
            yield return new WaitForSeconds(1.0f);
            GameObject wave = (GameObject)Instantiate(m_waves[m_currentWave], transform);
            nowwave = wave;
            Transform waveTrans = wave.transform;
            waveTrans.position = transform.position;
            //-------------------------------
            while (waveTrans != null && 0 < waveTrans.childCount)
            {
                yield return null;
            }
            //-------------------------------
            Destroy(wave);
            //Debug.Log(wave.name);
            m_currentWave = (int)Mathf.Repeat(m_currentWave + 1f, m_waves.Length);
            Debug.Log($"<color=#4169e1><b>{m_currentWave}</b></color>");
        }
        stg_manager._emiiter = null;
        m_currentWave = 0;
        Debug.Log($"<color=#ff6347><b>戦闘終了♡</b></color>");
    }

    private void Update()
    {
        if (_gameState._GameState.Value == GameState.GameOver)
        {
            //stg_manager.GameOver();
            m_currentWave = 0;
            //Debug.Log("StopEmiiter");
            //if (nowwave != null) Destroy(nowwave);
            //Stop_StoryEmiiter();
            //StopCoroutine(StoryEmiiter());
        }
    }

    public void Start_StoryEmiiter()
    {
        enumerator = StoryEmiiter();
        StartCoroutine(enumerator);
    }

    public void Stop_StoryEmiiter()
    {
        StopCoroutine(enumerator);
        enumerator = null;
    }
}
