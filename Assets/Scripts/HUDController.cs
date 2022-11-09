using UnityEngine;
using UnityEngine.UI;
public class HUDController : MonoBehaviour
{
    public Text scoreText;
    public Text pauseButtonText;
    protected private GameSceneController gameSceneController;

    private void Start()
    {
        gameSceneController = FindObjectOfType<GameSceneController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PauseButtonClicked();
        }
    }
    public void PauseButtonClicked()
    {
        // todo: connect this to gameSceneController.gameState
        if (gameSceneController.gameState != GameState.Paused)
        {
            gameSceneController.gameState = GameState.Paused;
            pauseButtonText.text = "Resume";
        }
        else
        {
            gameSceneController.gameState = GameState.Running;
            pauseButtonText.text = "Pause";
        }
    }
}
