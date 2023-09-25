using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustRotate : MonoBehaviour {

public bool canRotate;
public float speed=10;
	void Update ()
	{
		if(canRotate)
		  transform.Rotate(speed*Vector3.forward*Time.deltaTime);
	}

    public void CanRotate()
    {
        canRotate = !canRotate;
    }
}
