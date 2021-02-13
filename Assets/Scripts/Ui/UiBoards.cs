using System.Collections;
using UnityEngine;

public class UiBoards : MonoBehaviour
{
    [SerializeField]
    private GameObject _loseBoard;

    [SerializeField]
    private GameObject _winBoard;

    [SerializeField]
    private GameObject _pauseBoard;

    public void ShowLoseBoard(float delay)
    {
        StartCoroutine(LoseBoard(delay));
    }

    public void ShowWinBoard(float delay)
    {
        StartCoroutine(WinBoard(delay));
    }

    public void ShowPauseBoard(float delay)
    {
        StartCoroutine(PauseBoard(delay));
    }

    private IEnumerator LoseBoard(float delay)
    {
        yield return new WaitForSeconds(delay);
        _loseBoard.SetActive(true);
    }

    private IEnumerator WinBoard(float delay)
    {
        yield return new WaitForSeconds(delay);
        _winBoard.SetActive(true);
    }

    private IEnumerator PauseBoard(float delay)
    {
        yield return new WaitForSeconds(delay);
        _pauseBoard.SetActive(true);
    }
}
