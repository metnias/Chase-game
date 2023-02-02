using UnityEditor;
using UnityEngine;

/// <summary>
/// Singleton that controls game
/// </summary>
public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance() => _instance;

    public GameObject Player;
    public GameObject Gameover;
    public GameObject Gamewin;

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
                Destroy(gameObject);
        }
    }

    void Update()
    {
        if (gameoverTimer > 0)
        {
            gameoverTimer--;
            Time.timeScale = 0.6f * (gameoverTimer / (float)TIMER); // Slowdown effect
            if (gameoverTimer < 1)
            {
#if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
#else
                Application.Quit();
#endif
            }
        }
    }

    private int gameoverTimer = 0;
    private const int TIMER = 200;

    /// <summary>
    /// Triggers Game Over
    /// </summary>
    public static void GameOver()
    {
        if (Instance().gameoverTimer > 0) return; // Already won
        Instance().Player.SetActive(false);
        Instance().Gameover.SetActive(true);
        Instance().gameoverTimer = TIMER;
    }

    /// <summary>
    /// Triggers Game Win
    /// </summary>
    public static void GameWin()
    {
        Instance().Gamewin.SetActive(true);
        Instance().gameoverTimer = TIMER;
    }
}
