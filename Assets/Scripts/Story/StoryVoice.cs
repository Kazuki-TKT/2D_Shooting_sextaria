using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryVoice : MonoBehaviour
{
    [SerializeField]
    private AudioSource source; //スピーカー・CDプレイヤー

    [SerializeField]
    private AudioClip[] clipRucy;

    [SerializeField]
    private AudioClip[] clipLaura;

    [SerializeField]
    private AudioClip[] clipAtria;

    [SerializeField]
    private AudioClip[] clipIzal;

    [SerializeField]
    private AudioClip[] clipWes;

    [SerializeField]
    private AudioClip[] clipElnath;

    [SerializeField]
    private AudioClip[] clipOxia;
    void Start()
    {
        
    }

    public void VC_Start(int clipNo,int charaNum,bool loop=true)
    {
        source.loop = loop;
        switch (charaNum)
        {
            case 0://ルーシー
                source.clip = clipRucy[clipNo];
                break;
            case 1://ラウラ
                source.clip = clipLaura[clipNo];
                break;
            case 2://アトリア
                source.clip = clipAtria[clipNo];
                break;
            case 3://イザル
                source.clip = clipIzal[clipNo];
                break;
            case 4://ウェズ
                source.clip = clipWes[clipNo];
                break;
            case 5://エルナト
                source.clip = clipElnath[clipNo];
                break;
            case 6://オクシア
                source.clip = clipOxia[clipNo];
                break;
        }
        source.Play(); //再生
    }
    public void VcStop()
    {
        if(source.isPlaying==true)
        source.Stop();
    }
}
