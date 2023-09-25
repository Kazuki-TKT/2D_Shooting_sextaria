using UnityEngine;
using DG.Tweening;
using KanKikuchi.AudioManager;

public class ScoreItem : MonoBehaviour,GetItemIo
{

    public Rigidbody2D m_Rigidbody;
    [SerializeField]
    private float m_Thrust;
    public float speed = 5f;

    private GameObject target;
    private bool targetbool;
    //------------------------------//
    STG_Score _score;

    [SerializeField]
    private int _scorepoint;

    [SerializeField]
    SEAssistant sEAssistant;

    public bool MoveItem { get; set; } = false;
    void Awake()
    {
        if(GameObject.FindWithTag("Player") != null)
        {
            target = GameObject.FindWithTag("Player");
        }
        _score = GameObject.Find("ScoreGroup").GetComponent<STG_Score>();
    }
    void Start()
    {
        
        //-------------------------
        targetbool = false;
        transform.DORotate(new Vector3(0, 0, -360), 0.3f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLink(gameObject);
        int rnd = Random.Range(5, 15);
        m_Rigidbody.AddForce(transform.up * (m_Thrust + rnd));
    }
    
    private void FixedUpdate()
    {
        if (targetbool == true)
        {
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(
              transform.position,
              target.transform.position,
              speed * Time.deltaTime);
            }
            else
            {
                targetbool = false;
            }
                
        }
        if (MoveItem == true)
        {
            transform.position = Vector3.MoveTowards(
              transform.position,
              target.transform.position,
              speed * Time.deltaTime);
        }
            
    }

    public void GetUseAbility()
    {
        sEAssistant.Play();
        //Debug.Log("スコアアップ");
        _score.AddPoint(_scorepoint);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("ItemDestroy"))
        {
            //Debug.Log("ItemDes");
            Destroy(this.gameObject);
        }
        if (c.gameObject.CompareTag("CircleVacuume"))
        {
            if (targetbool == true) return;
            if (target != null)
            {
                target = GameObject.FindWithTag("Player");
                m_Rigidbody.gravityScale = 0;
                targetbool = true;
            }
        }
    }
}
