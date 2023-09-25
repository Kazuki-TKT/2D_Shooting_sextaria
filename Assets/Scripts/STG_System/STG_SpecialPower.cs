using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;
public class STG_SpecialPower : MonoBehaviour, STG_SpecialIO
{
    [SerializeField]
    SEAssistant se;

    [SerializeField]
    ParticleSystem[] particle;

    [SerializeField]
    STG_PlayerShip _PlayerShip;

    public float waitTime1st;
    public void SpecialAttack()
    {
        StartCoroutine(SpecialHeal(waitTime1st));
    }

    public IEnumerator SpecialHeal(float waitTime1)
    {
        se.Play();
        if (_PlayerShip._PowerUp.m_power==200)
        {
            particle[1].Play();
            yield return new WaitForSeconds(waitTime1);
            _PlayerShip.ScoreAdds(2000);
        }
        else
        {
            particle[0].Play();
            yield return new WaitForSeconds(waitTime1);
            _PlayerShip.PowerMax();
        }
    }
}
