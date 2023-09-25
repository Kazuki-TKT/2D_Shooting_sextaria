using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class STG_Music : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VictoryMusic()
    {
        BGMManager.Instance.Play(BGMPath.ROCKLOGOSTINGER25, volumeRate: 0.6f, allowsDuplicate: false);

        BGMManager.Instance.FadeOut(BGMPath.ROCKLOGOSTINGER25, 5f, () => {
            BGMManager.Instance.Play(BGMPath.THEAFTERPARTYSHORTLOOP1, volumeRate: 0.4f, allowsDuplicate: true);
        });
    }
}
