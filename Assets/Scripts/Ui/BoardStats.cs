using UnityEngine;
using UnityEngine.UI;

public class BoardStats : MonoBehaviour
{
    [SerializeField]
    private Text _coins;
    [SerializeField]
    private Text _currentTime;
    [SerializeField]
    private Text _bestTime;

    private void OnEnable()
    {
        _coins.text = "Coins: " + GameManager.instance.Coins;
        _currentTime.text = "Time: " + GameManager.instance.PlayTimer.ToString("F2");
        _bestTime.text = "Best time: " + PlayerPrefs.GetFloat("bestTime").ToString("F2");
    }
}
