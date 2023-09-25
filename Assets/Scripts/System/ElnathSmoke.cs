using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;
public class ElnathSmoke : MonoBehaviour
{
    [SerializeField]
    SEAssistant sEAssistant;
    public STG_Boss _Boss;
    public ParticleSystem Bats;
    public ParticleSystem Smoke;
    private Animator _animator;

    public float delayTime; // 遅延処理までの待機時間
    [SerializeField]
    private bool smokeFlag;
    private float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        smokeFlag = false;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (smokeFlag == true)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= delayTime)
            {
                _animator.SetBool("Smoke", false);
                smokeFlag = false;
                _Boss.colliderFlag = false;
                Bats.Stop();
                Smoke.Stop();
                elapsedTime = 0;
            }
        }
    }
    public void SmokeOn()
    {
        sEAssistant.Play();
        _Boss.colliderFlag = true;
        smokeFlag = true;
        Bats.Play();
        Smoke.Play();
        _animator.SetBool("Smoke", true);

    }

    private void OnDisable()
    {
        elapsedTime = 0;
        _animator.SetBool("Smoke", false);
        smokeFlag = false;
        _Boss.colliderFlag = false;
        Bats.Stop();
        Smoke.Stop();
    }
}
