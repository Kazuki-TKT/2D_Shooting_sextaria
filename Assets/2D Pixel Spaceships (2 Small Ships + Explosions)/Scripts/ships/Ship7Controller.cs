using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

namespace MotherShip
{

    public class Ship7Controller : MonoBehaviour {

        public Transform turretLeft;
        public Transform turretRight;
        public int deltaAngle;

        [Space(20)]
        public GameObject[] childShipPrefab;
        public int childCount;
        public float delayInLaunch;

        public float delay_L;
        public float delay_R;
        public Transform childLeftStart;
        public Transform childRightStart;

        Camera mainCamera;
        Animator animator;

        GameObject _playerObj;
	    // Use this for initialization
	    void Start () {
            _playerObj = GetTaggedObject("Player");
            //mainCamera = Camera.main;
            animator = GetComponent<Animator>();
            

        }
        public void Exp()
        {
            SEManager.Instance.Play(SEPath.EXPLOSION1, volumeRate: 0.5f);
        }
        public void GateOpened()
        {
            StartCoroutine(LaunchChildShips());
        }

        public void STG_GateOpened()
        {
            StartCoroutine(LaunchChildShips_Left());
            StartCoroutine(LaunchChildShips_Right());
        }
        IEnumerator LaunchChildShips()
        {
            for (int index = 0; index < childCount; index++)
            {
                Instantiate(childShipPrefab[0], 
                    ((index % 2 == 0) ? childLeftStart.position : childRightStart.position), 
                    Quaternion.identity);
                yield return new WaitForSeconds(delayInLaunch);
            }
            
            animator.SetBool("open", false);
        }

        IEnumerator LaunchChildShips_Left()
        {
            animator.SetBool("open", true);
            for (int index = 0; index < childCount; index++)
            {
                Instantiate(childShipPrefab[0], childLeftStart.position,
                    Quaternion.identity);
                yield return new WaitForSeconds(delay_L);
            }
            Debug.Log("左終了");
            animator.SetBool("open", false);
        }
        IEnumerator LaunchChildShips_Right()
        {
            animator.SetBool("open", true);
            for (int index = 0; index < childCount; index++)
            {
                Instantiate(childShipPrefab[1], childRightStart.position,
                    Quaternion.identity);
                yield return new WaitForSeconds(delay_R);
            }
            animator.SetBool("open", false);
        }
        // Update is called once per frame
        void Update () {
            
            if (_playerObj == null)
            {
                //Debug.LogError("Object with tag " + tag + " not found");
                return;
            }
            else
            {
                Vector3 player = _playerObj.transform.position;
                Tools.TraceTarget(turretLeft, player, deltaAngle);
                Tools.TraceTarget(turretRight, player, deltaAngle);
            }
            //Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            //Tools.TraceTarget(turretLeft, mousePos, deltaAngle);
            //Tools.TraceTarget(turretRight, mousePos, deltaAngle);
        }

        public GameObject GetTaggedObject(string tag)
        {
            GameObject taggedObject = GameObject.FindGameObjectWithTag(tag);

            if (taggedObject == null)
            {
                Debug.Log("Object with tag " + tag + " not found");
                return null;
            }

            return taggedObject;
        }
    }
}
