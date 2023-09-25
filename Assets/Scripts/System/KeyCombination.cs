using UnityEngine;
using KanKikuchi.AudioManager;
public class KeyCombination : MonoBehaviour
{
    public KeyCode key1; // 特定のキー
    public KeyCode key2; // 別のキー

    private bool key1Pressed;
    private bool key2Pressed;

    [SerializeField]
    GameStateManager gameState;

    [SerializeField]
    StoryScrollbar story;

    [SerializeField]
    SEAssistant _se;
    
    private void Update()
    {
        if (gameState._GameState.Value != GameState.Title) return;
        if (Input.GetKeyDown(key1))
        {
            key1Pressed = true;
        }

        if (Input.GetKeyDown(key2) && key1Pressed)
        {
            // 処理を実行する
            ExecuteFunction();
        }

        if (Input.GetKeyUp(key1))
        {
            key1Pressed = false;
        }
    }

    private void ExecuteFunction()
    {
        // 実行する処理を書く
        _se.Play();
        story.TaikenStoryOpen();
        Debug.Log("キーの組み合わせが押されました！");
    }
}
