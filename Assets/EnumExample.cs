using UnityEngine;

public enum ExampleGameState { Running, Paused, Ended }
public class EnumExample : MonoBehaviour
{
    private ExampleGameState gameState;

    void Start()
    {
        gameState = ExampleGameState.Running;
    }

    void Update()
    {
        switch (gameState)
        {
            case ExampleGameState.Running:
                Debug.Log("The game is running");
                break;
            case ExampleGameState.Paused:
                Debug.Log("The game is paused");
                break;
            case ExampleGameState.Ended:
                Debug.Log("The game is ended");
                break;
        }
    }
}
