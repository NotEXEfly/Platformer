using UnityEngine;

public class PauseBoard : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.instance.PauseIsOpen = true;
        FindObjectOfType<Player>().Components.RigitBody.simulated = false;
    }
    private void OnDisable()
    {
        GameManager.instance.PauseIsOpen = false;
        FindObjectOfType<Player>().Components.RigitBody.simulated = true;
    }
}
