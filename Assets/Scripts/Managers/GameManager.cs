using UnityEngine;

public enum GameState
{ 
    Play,
    Pause,
    Waiting,
    Menu
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState Game { get => _game; }
    private GameState _game;

    public int Coins { get; private set; } = 0;
    private float playTimer = 0f;
    
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

    private void OnEnable()
    {
        PlayerCollisions.OnCoinCollision += CoinTake;
    }

    private void OnDisable()
    {
        PlayerCollisions.OnCoinCollision -= CoinTake;
    }

    private void Update()
    {
        if (_game == GameState.Play)
        {
            playTimer += Time.deltaTime;
        }
    }

    public void CoinTake()
    {
        Coins++;
        AudioManager.instance.Play("Coin");
    }


    // Game states
    public void StartGame()
    {
        FindObjectOfType<LevelLoader>().LoadNextScene();
        _game = GameState.Play;

        
        // Start timers;
    }

    public void Lose()
    {
        AudioManager.instance.Play("Death");
        _game = GameState.Pause;
        
        // lose screen
    }

    public void Win()
    {
        _game = GameState.Pause;

        // win screen
    }


    //--- Buttons in pause---
    public void Restart()
    {
        _game = GameState.Waiting;
        FindObjectOfType<LevelLoader>().RestartScene();
    }

    public void ExitGame()
    {
        _game = GameState.Menu;

        FindObjectOfType<LevelLoader>().LoadMenu();
    }

    // Main menu start button
    public void LoadGame()
    {
        FindObjectOfType<LevelLoader>().LoadNextScene();
        _game = GameState.Waiting;
    }
}
