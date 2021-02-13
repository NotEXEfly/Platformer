using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool GameIsPlay { get; private set; } = false;

    public int Coins { get; private set; } = 0;
    public float PlayTimer { get; private set; } = 0f;
    
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
        if (GameIsPlay)
        {
            instance.PlayTimer += Time.deltaTime;
        }
    }

    public void CoinTake()
    {
        Coins++;
        AudioManager.instance.Play("Coin");
    }


    // Game states 
    public void Lose()
    {
        instance.GameIsPlay = false;
        AudioManager.instance.Play("Death");
        FindObjectOfType<Theme>().Stop();
        AudioManager.instance.Play("Loose");

        FindObjectOfType<UiBoards>().ShowLoseBoard(1f);
    }


    public void Win()
    {
        instance.GameIsPlay = false;

        FindObjectOfType<Theme>().Stop();
        AudioManager.instance.Play("Win");

        FindObjectOfType<UiBoards>().ShowWinBoard(0.5f);

        SaveStats();
    }


    //--- Buttons---
    public void Pause()
    {
        instance.GameIsPlay = false;
        FindObjectOfType<UiBoards>().ShowPauseBoard(0);
    }

    public void Restart()
    {
        AudioManager.instance.Stop("Loose");

        ClearStats();
        instance.GameIsPlay = false;

        FindObjectOfType<LevelLoader>().RestartScene();
    }

    public void ExitGame()
    {
        AudioManager.instance.Stop("Loose");
        instance.GameIsPlay = false;

        FindObjectOfType<LevelLoader>().LoadMenu();
    }

    public void Play()
    {
        instance.GameIsPlay = true;
    }

    // Main menu start button
    public void LoadGame()
    {
        ClearStats();
        instance.GameIsPlay = false;
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    private void SaveStats()
    {
        //Save best time
        if (PlayerPrefs.HasKey("bestTime"))
        {
            if (PlayerPrefs.GetFloat("bestTime") >= instance.PlayTimer)
            {
                PlayerPrefs.SetFloat("bestTime", instance.PlayTimer);
            }
        }
        else
            PlayerPrefs.SetFloat("bestTime", instance.PlayTimer);

        //Save best coins
        if (PlayerPrefs.HasKey("bestCoins"))
        {
            if (PlayerPrefs.GetInt("bestCoins") <= instance.Coins)
            {
                PlayerPrefs.SetInt("bestCoins", instance.Coins);
            }
        }
        else
            PlayerPrefs.SetInt("bestCoins", instance.Coins);

        // Save last time and last coins
        PlayerPrefs.SetFloat("lastTime", instance.PlayTimer);
        PlayerPrefs.SetInt("lastCoins", instance.Coins);
    }

    private void ClearStats()
    {
        instance.PlayTimer = 0;
        instance.Coins = 0;
    }
}
