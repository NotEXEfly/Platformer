using UnityEngine;

public enum GameState
{ 
    Play,
    Pause,
    Dead,
    Menu
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

    public void Lose()
    {
        AudioManager.instance.Play("Death");
        _game = GameState.Dead;
        Restart();
        // lose screen
    }

    public void Win()
    {
        _game = GameState.Pause;
        Debug.Log("Win");
    }

    public void Restart()
    {
        Debug.Log("Restart");

        FindObjectOfType<LevelLoader>().RestartScene();
    }

    public void ExitGame()
    {
        _game = GameState.Dead;
        
        Debug.Log("Menu");

        FindObjectOfType<LevelLoader>().LoadMenu();
    }
}
