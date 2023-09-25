using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class STG_TutorialEmiiter : MonoBehaviour
{
    [SerializeField]
    GameStateManager _gameState;

    [SerializeField, FormerlySerializedAs("_Waves")]
    private GameObject[] m_waves = null;

    [SerializeField]
    private int m_currentWave;

    [SerializeField]
    private STG_Manager stg_manager;

    public bool _flag;

    Coroutine _someCoroutine;
    private void Start()
    {
        _flag = true;
    }
    public void Start_Tutorial_01()
    {
        _flag = true;
        _someCoroutine = StartCoroutine(Tutorial_01());
    }
    IEnumerator Tutorial_01()
    {
        stg_manager._tutoEmiiter = this;
        if (m_waves.Length == 0)
        {
            yield break;
        }

        while (_flag==true)
        {
            GameObject wave = (GameObject)Instantiate(m_waves[m_currentWave], transform);
            Transform waveTrans = wave.transform;
            waveTrans.position = transform.position;
            //-------------------------------
            //--親オブジェクト(waveTrans)
            //----子オブジェクト(waveTrans.childCount)
            //親と子がないとスタックする
            while (0 < waveTrans.childCount)
            {
                yield return null;
            }
            //-------------------------------
            Destroy(wave);
            Debug.Log(wave.name);
            m_currentWave = (int)Mathf.Repeat(m_currentWave + 1f, m_waves.Length);
            Debug.Log(m_currentWave);
        }
        stg_manager._tutoEmiiter = null;
        Debug.Log($"<color=#ff6347><b>戦闘終了♡</b></color>");
    }

    public void Stop_StoryEmiiter()
    {
        StopCoroutine(_someCoroutine);
        //_flag = false;
    }
}
