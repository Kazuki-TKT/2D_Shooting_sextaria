using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField]
    GameObject pausePanel;

    [SerializeField]
    GameStateManager gameState;

    public KeyCode PauseGames = KeyCode.C;

    [SerializeField]
    UISelectAction selectAction;

    [SerializeField]
    UISelectAction flowchart_UISelection;
    private void Start()
    {
        //pausePanel.SetActive(false);
    }
    void Update()
    {
        if (gameState._GameState.Value == GameState.Gaming|| gameState._GameState.Value == GameState.GamingStory)
        {
            if (Input.GetKeyDown(PauseGames))
            {
                Pause();
            }
        }
        
    }

    public  void Pause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            //selectAction.FirstSelect();
            
        }
        else 
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            if (gameState._GameState.Value == GameState.GamingStory)
            {
                flowchart_UISelection.FirstSelect();
            }
        }
    }

    public void PauseGameOver()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            if (gameState._GameState.Value == GameState.GamingStory)
            {
                flowchart_UISelection.FirstSelect();
            }
        }
    }
}
