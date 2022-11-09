using System.Collections;
using UnityEngine;

public delegate void TextOutputHandler(string text);
public class GameSceneController : MonoBehaviour
{
    [Space, Header("Player Settings")]
    [Range(2, 10)] public float playerSpeed;
    [Range(2, 10)] public float projectileSpeed;
    public ProjectileController projectilePrefab;
    private PlayerController player;

    [Space, Header("Screen Settings")]
    public Vector3 screenBounds;
    public GameState gameState;

    [Space, Header("Enemy Settings")]
    [SerializeField] private EnemyController enemyPrefab;
    [SerializeField, Range(0.25f, 1f)] private float enemyScale;
    [Range(2, 10)] public float enemySpeed;

    private HUDController hudController;
    private int totalPoints;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        hudController = FindObjectOfType<HUDController>();
        gameState = GameState.Running;
        screenBounds = GetScreenBounds();
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.SetColor(Color.red);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            player.SetColor(Color.yellow);
        }

        if (gameState == GameState.Paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (gameState == GameState.Running)
        {
            float horizontalPosition = Random.Range(-screenBounds.x, screenBounds.x);
            Vector2 spawnPosition = new Vector2(horizontalPosition, screenBounds.y);

            EnemyController enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.transform.localScale = new Vector2(enemyScale, enemyScale);
            enemy.EnemyEscaped += EnemyAtBottom;
            enemy.EnemyKilled += EnemyKilled;

            yield return new WaitForSeconds(2);
        }
    }

    private void EnemyKilled(int pointsEarned)
    {
        totalPoints += pointsEarned;
        hudController.scoreText.text = totalPoints.ToString();
    }

    private void EnemyAtBottom(EnemyController enemy)
    {
        Destroy(enemy.gameObject);
        Debug.Log("Enemy Escaped!");
    }
    private Vector3 GetScreenBounds()
    {
        Camera mainCamera = Camera.main;
        Vector3 screenVector = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);

        return mainCamera.ScreenToWorldPoint(screenVector);
    }

    public void KillObject(IKillable killable)
    {
        //Debug.LogWarningFormat("{0} killed by Game Scene Controller", killable.GetName());
        killable.Kill();
    }

    public void OutputText(string output)
    {
        Debug.LogFormat("{0} output by GameSceneController", output);
    }
}

public enum GameState { Running, Paused, Ended }