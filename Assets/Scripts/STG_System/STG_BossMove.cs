
using UnityEngine;
using DG.Tweening;

public class STG_BossMove : MonoBehaviour
{
    [SerializeField]
    GameObject _player;
    [SerializeField]
    GameObject[] _obj;
    

    public void OnBoss(int objNo, float moveTime, bool active,float y)
    {
        if (active == true)
        {
            _obj[objNo].SetActive(true);
            _obj[objNo].transform.DOMove(new Vector3(0,y), moveTime).OnComplete(() =>Debug.Log("Move終了"));
        }
        else
        {
            _obj[objNo].transform.DOLocalMoveY(6, 0.5f).OnComplete(() =>
            {
                _obj[objNo].SetActive(false);
            });
        }

    }

    public void PlayerDefaultPosition()
    {
        _player.transform.DOMove(new Vector3(0, -1.5f, 0), 1.5f);
    }

    public void BossOff(int objNo)
    {
        _obj[objNo].SetActive(false);
    }
    public void BossOn(int objNo)
    {
        _obj[objNo].SetActive(true);
    }

    public void BossTalk(int objNo, float moveTime,float y)
    {
        Debug.Log("BossTalk");
        _obj[objNo].transform.DOMove(new Vector3(0, y, 0), moveTime);
    }

}
