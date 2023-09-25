using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using KanKikuchi.AudioManager;

public class STG_Barire : MonoBehaviour,STG_SpecialIO
{
	public GameObject player;
	Tweener tweener;

	public Vector3 offset;

	bool barireFlag=false;

    //[SerializeField]
    //Animator animator;

    [SerializeField]
    GameObject barire;

    [SerializeField]
    SEAssistant se;
	void Start()
	{
		barireFlag = false;
        barire.SetActive(false);
		updatePostion();
		//StartCoroutine(Barire(8));
	}

	void LateUpdate()
	{
		if (barireFlag == false)
		{
            barire.SetActive(false);
            return;
		}
		updatePostion();
	}

	void updatePostion()
	{
		Vector3 pos = player.transform.localPosition;

		transform.localPosition = pos + offset;
	}

	private void OnTriggerEnter2D(Collider2D c)
	{
		if (barireFlag == false)
		{
			return;
		}
		if (c.gameObject.CompareTag("EBullet"))
		{
			UbhBullet bullet = c.GetComponentInParent<UbhBullet>();// 弾を戻す
			if (bullet != null && bullet.isActive)
			{
				UbhObjectPool.instance.ReleaseBullet(bullet);
			}
		}
	}

	public IEnumerator Barire(float time)
	{
        se.Play();
		barireFlag = true;
        barire.SetActive(true);
        //animator.SetBool("barire", true);
		yield return new WaitForSeconds(time);
        //animator.SetBool("barire", false);
        barire.SetActive(false);
        barireFlag = false;
		//ここに再開後の処理を書く
	}

    public void SpecialAttack()
    {
        //Debug.Log("Barire");
        StartCoroutine(Barire(3));
    }
}
