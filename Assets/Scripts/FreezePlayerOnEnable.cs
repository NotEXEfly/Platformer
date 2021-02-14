using UnityEngine;

public class FreezePlayerOnEnable : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.instance.PauseIsOpen = true;

        var player = FindObjectOfType<Player>();

        if (player != null)
            player.Components.RigitBody.simulated = false;
    }
    private void OnDisable()
    {
        GameManager.instance.PauseIsOpen = false;

        var player = FindObjectOfType<Player>();

        if(player != null)
            player.Components.RigitBody.simulated = true;
    }
}
