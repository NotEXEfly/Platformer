using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{ 
    Play,
    Pause,
    Dead,
}

public class GameManager : MonoBehaviour
{
    public GameState Game { get => _game; }

    public static GameManager instance;


    float playTimer = 0f;
    private GameState _game;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        FindObjectOfType<LevelLoader>().LoadNextScene();
        _game = GameState.Play;
         
        Debug.Log("StartGame");
        // Start timers;
    }

    public void OnPlayerDeath()
    {
        FindObjectOfType<LevelLoader>().LoadMenu();
        _game = GameState.Dead;
    }

    public void OnPlayerWin()
    {
        _game = GameState.Pause;
        Debug.Log("Finish");
    }

    public void Restart()
    {
        
        Debug.Log("Restart");
    }
}
