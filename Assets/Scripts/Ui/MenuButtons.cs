using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public void ShowSettings()
    {
        Debug.Log("Window Settings");
    }

    public void ShowScoreTable()
    {
        Debug.Log("Window Score");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
