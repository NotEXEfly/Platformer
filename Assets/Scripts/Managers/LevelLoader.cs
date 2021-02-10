using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(LoadLevel(sceneIndex));

    }

    private IEnumerator LoadLevel(int sceneIndex)
    {
        if (sceneIndex < 0) yield break;

        if (SceneManager.sceneCountInBuildSettings < sceneIndex + 1)
        {
            sceneIndex = 0;
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        
        SceneManager.LoadScene(sceneIndex);
    }
}
