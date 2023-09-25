using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using KanKikuchi.AudioManager;

public class RecoveryItem : MonoBehaviour,GetItemIo
{
    public Rigidbody2D m_Rigidbody;

    [SerializeField]
    private int _recoverPoint;

    [SerializeField]
    private float m_Thrust;

    private bool targetbool;
    private GameObject target;
    public float speed = 5f;

    STG_PlayerShip playerShip;

    [SerializeField]
    SEAssistant sEAssistant;

    public bool MoveItem { get; set; } = false;
    void Awake()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            target = GameObject.FindWithTag("Player");
            playerShip = target.GetComponent<STG_PlayerShip>();
        }
        //if (GameObject.FindWithTag("Player").GetComponent<STG_PlayerShip>() != null)
        //{
        //    playerShip = GameObject.FindWithTag("Player").GetComponent<STG_PlayerShip>();
        //}
        //else
        //{
        //    playerShip = GameObject.Find("Player").GetComponent<STG_PlayerShip>(); ;
        //}
    }
    void Start()
    {
        targetbool = false;
        transform.DORotate(new Vector3(0, 0, -360), 0.3f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLink(gameObject);
        int rnd = Random.Range(5, 15);
        m_Rigidbody.AddForce(transform.up * (m_Thrust+rnd));

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
              speed * 2f * Time.deltaTime);
        }
    }
    public void GetUseAbility()
    {
        sEAssistant.Play();
        //Debug.Log("回復");
        playerShip.pHP.Value += _recoverPoint;
        playerShip.pHP.Value = System.Math.Min(playerShip.pHP.Value, playerShip.hp_MAX);
        playerShip._hpSlider.value = playerShip.pHP.Value;
        playerShip._hpText.text = playerShip.pHP.Value.ToString();
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
