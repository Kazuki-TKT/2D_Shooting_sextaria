using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class STG_FunsugSend : MonoBehaviour
{
    [SerializeField]
    Flowchart flowchart;

    public string fungusText;
    public void FungusMessage()
    {
        flowchart.SendFungusMessage(fungusText);
    }

    public void TextSet(string message)
    {
        fungusText = message;
    }
}
