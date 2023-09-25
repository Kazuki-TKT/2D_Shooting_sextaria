using UnityEngine;
using DG.Tweening;

public class STG_Tutorial : MonoBehaviour
{
    [SerializeField]
    GameObject _player;
    [SerializeField]
    GameObject[] _obj;

    Rigidbody2D m_Rigidbody;
    public void OnGameObject(int objNo,bool active)
    {
        if (active == true)
        {
            _obj[objNo].SetActive(true);
            _obj[objNo].transform.DOMoveY(0, 0.5f);
        }
        else
        {  
            _obj[objNo].transform.DOLocalMoveY(400, 0.5f).OnComplete(() =>
            {
                _obj[objNo].SetActive(false);
            });
        }
        
    }

    public void OnEnemy(int objNo, float moveTime, bool active)
    {
        if (active == true)
        {
            _obj[objNo].SetActive(true);
            _obj[objNo].transform.DOMoveY(3, moveTime);
        }
        else
        {
            _obj[objNo].transform.DOLocalMoveY(6, 0.5f).OnComplete(() =>
            {
                _obj[objNo].SetActive(false);
            });
        }

    }

    public void StopItem()
    {
        m_Rigidbody = GameObject.Find("PowerUpItem_Tuto(Clone)").GetComponent<Rigidbody2D>();
        m_Rigidbody.gravityScale = 0;
    }
    public void FallItem()
    {
        if (m_Rigidbody == null) return;
        m_Rigidbody.gravityScale = 0.07f;
    }

    public void PlayerDefaultPosition()
    {
        _player.transform.DOMove(new Vector3(0, -1.5f, 0), 1.5f);
    }
}
