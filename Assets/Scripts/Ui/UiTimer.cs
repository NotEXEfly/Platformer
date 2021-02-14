using UnityEngine;
using UnityEngine.UI;

public class UiTimer : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _text.text = GameManager.instance.PlayTimer.ToString("F2");
    }
}
