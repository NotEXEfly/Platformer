using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator Transition;

    public void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings < sceneIndex)
        {
            sceneIndex = 0;
        }

        StartCoroutine(LoadLevel(sceneIndex));
    }

    public void LoadMenu() => StartCoroutine(LoadLevel(0));
    public void RestartScene() => StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));


    private IEnumerator LoadLevel(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        Transition.SetTrigger("Start");

        while (!operation.isDone)
        {
            yield return null;
        }
    }
    
}
