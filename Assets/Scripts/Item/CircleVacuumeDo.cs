using UnityEngine;
using DG.Tweening;

public class CircleVacuumeDo : MonoBehaviour
{
    public GameObject player;
    Tweener tweener;

    public Vector3 offset;
    // Update is called once per frame
    //void Update()
    //{
    //   tweener = this.gameObject.transform.DOMove(player.transform.position, 0.3f).SetLink(gameObject);
    //}

	void Start()
	{
		updatePostion();
	}

	void LateUpdate()
	{
		updatePostion();
	}

	void updatePostion()
	{
		Vector3 pos = player.transform.localPosition;

		transform.localPosition = pos + offset;
	}
}
