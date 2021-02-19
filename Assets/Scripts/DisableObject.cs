using UnityEngine;

public class DisableObject : MonoBehaviour
{
    public GameObject[] TargetObject;

    private void OnEnable()
    {
        foreach (var obj in TargetObject)
        {
            obj.SetActive(false);
        }
    }
}
