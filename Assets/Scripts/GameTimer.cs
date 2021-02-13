using System;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private GameManager _gameManager;
    private Text _text;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _text.text = _gameManager.PlayTimer.ToString("F2");
    }
}
