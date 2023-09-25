using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;
public class STG_SpecialShoot : MonoBehaviour, STG_SpecialIO
{
    [SerializeField]
    SEAssistant SE;

    [SerializeField]
    UbhShotCtrl shotCtrl;

    [SerializeField]
    ParticleSystem particle;

    public float waitTime1st, waitTime2nd;

    public void SpecialAttack()
    {
        StartCoroutine(SpecialFire(waitTime1st, waitTime2nd));
    }

    public IEnumerator SpecialFire(float waitTime1,float waitTime2)
    {
        particle.Play();
        SE.Play();
        yield return new WaitForSeconds(waitTime1);
        shotCtrl.StartShotRoutine();
        yield return new WaitForSeconds(waitTime2);
        shotCtrl.StopShotRoutine();
    }

 }
