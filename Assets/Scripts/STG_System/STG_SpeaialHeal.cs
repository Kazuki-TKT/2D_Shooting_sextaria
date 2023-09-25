using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class STG_SpeaialHeal : MonoBehaviour, STG_SpecialIO
{

    [SerializeField]
    SEAssistant se;

    [SerializeField]
    ParticleSystem[] particle = new ParticleSystem[2];

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
        if (_PlayerShip._lifePoint == 3)
        {
            particle[1].Play();
            yield return new WaitForSeconds(waitTime1);
            _PlayerShip.ScoreAdds(2000);
        }
        else
        {
            particle[0].Play();
            yield return new WaitForSeconds(waitTime1);
            _PlayerShip._lifeObj[_PlayerShip._lifePoint].SetActive(true);
            _PlayerShip._lifePoint++;
            
        }
    }
}
