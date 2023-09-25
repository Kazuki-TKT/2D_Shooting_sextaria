using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using DG.Tweening;
public class STG_Story : MonoBehaviour
{
    [SerializeField]
    GameStateManager gameState;

    public Flowchart flowchart;
    public FadeCanvasMy fade;
    public GameObject sayDialog;
    public float waitTime = 1.0f;

    [SerializeField]
    DialogInput dialog;

    [SerializeField] private float moveDuration = 1f;

    GameObject[] _dropItem;
    [SerializeField]
    GameObject _player;
    public void SkipStory()
    {
        StartCoroutine(StopStory());
    }
    public void Update()
    {
        
    }
    IEnumerator StopStory()
    {
        if (flowchart != null && flowchart.HasExecutingBlocks())
        {
            flowchart.StopAllBlocks(); // 現在実行中のブロックを停止する
        }
        while (sayDialog.activeSelf)
        {
            yield return new WaitForSeconds(waitTime);
        }
        fade.FadeBToA();
    }

    public void NextCommands()
    {
            if (gameState._GameState.Value == GameState.GamingStory)
            {
                dialog.SetNextLineFlag();
            }
            else
            {
                Debug.Log(gameState._GameState.Value);
            }
    }

    public void BuleetOff()
    {
        UbhObjectPool.instance.ReleaseAllBullet();
    }

    public void MoveItemsToPlayer()
    {
    //    GameObject[] items = GameObject.FindGameObjectsWithTag("DropItem");
        _dropItem = GameObject.FindGameObjectsWithTag("DropItem");
        foreach (GameObject item in _dropItem)
        {
            item.GetComponentInChildren<GetItemIo>().MoveItem = true;

        }
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //foreach (GameObject item in items)
        //{
        //    item.transform.DOMove(_player.transform.position, moveDuration)
        //            .SetEase(Ease.Linear).OnKill(() => Debug.Log("OnKill実行"));;
        //}
    }
}
