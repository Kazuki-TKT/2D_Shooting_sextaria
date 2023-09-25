using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using MoreMountains.Feedbacks;


public class STG_Start : MonoBehaviour
{
    [SerializeField]
    Flowchart flowchart;

    
    [SerializeField]
    MMFeedbacks _mmFeedback;

    public string message;
    private void OnEnable()
    {
        _mmFeedback.PlayFeedbacks();
    }

    public void FlowChartMessage()
    {
        flowchart.SendFungusMessage(message);
    }
}
