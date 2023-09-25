using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MotherShip
{

    public class Ship7ChildController : MonoBehaviour {
        const float PADDING = 0.3f;

        public float lifeTime;
        [Tooltip("Distance from start position where child ship will begin move randomly")]
        public float takeOffDistance;
        public float speed;
        public SpriteRenderer flameSpriteRenderer;

        Vector2 leftBottom;
        Vector2 rightTop;
        Vector3 targetPoint;
        bool takeOff = true;
        BaseBulletStarter bs;

        // Use this for initialization
        void Start () {
            leftBottom = Camera.main.ScreenToWorldPoint(Vector3.zero);
            leftBottom += new Vector2(PADDING, PADDING);
            rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, (float)Screen.height));
            rightTop -= new Vector2(PADDING, PADDING);

            targetPoint = new Vector3(transform.position.x, transform.position.y - takeOffDistance, 0.0f);

            Invoke("StartExplosion", lifeTime);
            bs = GetComponent<BaseBulletStarter>();
        }

        private void StartExplosion()
        {
            GetComponent<ExplosionController>().StartExplosion();
            bs.StopRepeatFire();
        }

        // Update is called once per frame
        void Update () {
            if (transform.position != targetPoint)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPoint, Time.deltaTime * speed);
            } else
            {
                if (takeOff)
                {
                    takeOff = false;
                    bs.StartRepeateFire();
                    GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
                    flameSpriteRenderer.maskInteraction = SpriteMaskInteraction.None;
                }
                targetPoint = new Vector3(Random.Range(leftBottom.x, rightTop.x), Random.Range(leftBottom.y, rightTop.y), 0.0f);
            }
	    }
    }
}
