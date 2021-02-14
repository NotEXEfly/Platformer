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
        _coins.text = GameManager.instance.Coins.ToString();
        _currentTime.text = GameManager.instance.PlayTimer.ToString("F2"); 
        _bestTime.text = PlayerPrefs.GetFloat("bestTime").ToString("F2");
    }
}
