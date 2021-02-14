using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]
    private Text _bestTime;
    [SerializeField]
    private Text _bestCoins;
    [SerializeField]
    private Text _lastTime;
    [SerializeField]
    private Text _lastCoins;

    private void OnEnable()
    {
        float bTime =  PlayerPrefs.GetFloat("bestTime");
        float lTime = PlayerPrefs.GetFloat("lastTime");

        float bCoins =  PlayerPrefs.GetInt("bestCoins");
        int lCoins = PlayerPrefs.GetInt("lastCoins");


        _bestTime.text = bTime > 0 ? bTime.ToString("F2") : "-";
        _lastTime.text = lTime > 0 ? lTime.ToString("F2") : "-";

        _bestCoins.text = bCoins > 0 ? bCoins.ToString() : "-";
        _lastCoins.text = lCoins > 0 ? lCoins.ToString() : "-";
    }
}
