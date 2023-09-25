
using UnityEngine;
using Fungus;

public class STG_EndWave : MonoBehaviour
{
    [SerializeField]
    Flowchart flowchart;

    [SerializeField]
    string sendMessage;

    [SerializeField]
    GameStateManager gameState;
    // Start is called before the first frame update
    void Start()
    {
        flowchart = GameObject.Find("Gaming").GetComponent<Flowchart>();
        gameState = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
    }

    private void OnDestroy()
    {
        if(gameState._GameState.Value==GameState.Gaming)
            if (flowchart != null)
            {
                flowchart.SendFungusMessage(sendMessage);
                //flowchart.SendFungusMessage("messageName");
            }
            else
            {
                Debug.Log("<color=yellow>Object name: " + gameObject.name + "</color>");
            }

    }
}
