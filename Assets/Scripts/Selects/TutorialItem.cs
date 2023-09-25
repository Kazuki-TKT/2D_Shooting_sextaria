using UnityEngine;
using DG.Tweening;

public class TutorialItem : MonoBehaviour, GetItemIo
{
    public Rigidbody2D m_Rigidbody;
    [SerializeField]
    private float m_Thrust;
    public float speed = 5f;

    private GameObject target;
    private bool targetbool;
    //------------------------------//
    STG_PowerUp _power;

    [SerializeField]
    private int _powerpoint;

    public bool MoveItem { get; set; } = false;
    void Start()
    {
        _power = GameObject.Find("StatusCanvas").GetComponent<STG_PowerUp>();
        //-------------------------
        targetbool = false;
        transform.DORotate(new Vector3(0, 0, -360), 0.3f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLink(gameObject);
        m_Rigidbody.AddForce(transform.up * (m_Thrust));
    }

    private void FixedUpdate()
    {
        if (targetbool == true)
            transform.position = Vector3.MoveTowards(
              transform.position,
              target.transform.position,
              speed*2f * Time.deltaTime);
    }

    public void GetUseAbility()
    {
        _power.AddPoint(_powerpoint);
        Destroy(this.gameObject);
    }

   

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("ItemDestroy"))
        {
            Debug.Log("ItemDes");
            Destroy(this.gameObject);
        }
        if (c.gameObject.CompareTag("CircleVacuume"))
        {
            target = GameObject.FindWithTag("Player");
            m_Rigidbody.gravityScale = 0;
            targetbool = true;
        }
    }
}
