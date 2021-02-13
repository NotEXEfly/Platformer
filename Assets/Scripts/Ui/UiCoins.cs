using UnityEngine;
using UnityEngine.UI;

public class UiCoins : MonoBehaviour
{
    private Text _text;
    private int _coins;
    
    private void Start()
    {
        _text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        PlayerCollisions.OnCoinCollision += UpdateCoinsCount;
    }

    private void OnDisable()
    {
        PlayerCollisions.OnCoinCollision -= UpdateCoinsCount;
    }

    private void UpdateCoinsCount()
    {
        _coins++;
        _text.text = _coins.ToString();
    }
}
