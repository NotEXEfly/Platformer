using UnityEngine;

public class GameManager : MonoBehaviour
{
    // todo
    public static GameManager instance;

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
        Debug.Log("StartGame");
        // Start timers;
    }

    public void EndGame()
    {
        Debug.Log("GameOver");
    }

    public void Finish()
    {
        Debug.Log("Finish");
    }

    public void Restart()
    {
        Debug.Log("Restart");
    }
}
