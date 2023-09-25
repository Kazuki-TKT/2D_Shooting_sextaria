using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class STG_EmiiterUni : MonoBehaviour
{
    [SerializeField]
    private GameStateManager _gameState;

    [SerializeField]
    private GameObject[] m_waves = null;

    [SerializeField]
    private int m_currentWave;

    [SerializeField]
    private STG_Manager stg_manager;

    private GameObject nowwave;

    private UniTaskCompletionSource completionSource;

    private async UniTaskVoid StoryEmiiter()
    {
        //stg_manager._emiiter = this;

        if (m_waves.Length == 0)
        {
            return;
        }

        Debug.Log($"<color=#db7093><b>WaveLength :{m_waves.Length}</b></color>");

        while (m_currentWave < m_waves.Length - 1)
        {
            if (_gameState._GameState.Value == GameState.GameOver)
            {
                if (nowwave != null)
                {
                    Destroy(nowwave);
                }

                Debug.Log($"<color=#ff6347><b>緊急戦闘終了♡</b></color>");
                break;
            }

            await UniTask.Delay(1000);

            GameObject wave = Instantiate(m_waves[m_currentWave], transform);
            nowwave = wave;

            Transform waveTrans = wave.transform;
            waveTrans.position = transform.position;

            while (waveTrans.childCount > 0)
            {
                await UniTask.Yield();
            }

            Destroy(wave);
            Debug.Log(wave.name);

            m_currentWave = (int)Mathf.Repeat(m_currentWave + 1f, m_waves.Length);
            Debug.Log($"<color=#4169e1><b>{m_currentWave}</b></color>");
        }

        stg_manager._emiiter = null;
        Debug.Log($"<color=#ff6347><b>戦闘終了♡</b></color>");
    }

    private void Update()
    {
        if (_gameState._GameState.Value == GameState.GameOver)
        {
            Debug.Log("StopEmiiter");

            if (nowwave != null)
            {
                Destroy(nowwave);
            }

            StopStoryEmiiter();
        }
    }

    public void StartStoryEmiiter()
    {
        if (completionSource != null && completionSource.TrySetCanceled())
        {
            completionSource = null;
        }

        completionSource = new UniTaskCompletionSource();
        //_ = StoryEmiiter().Forget();
    }

    public void StopStoryEmiiter()
    {
        if (completionSource != null && completionSource.TrySetCanceled())
        {
            completionSource = null;
        }
    }
}
