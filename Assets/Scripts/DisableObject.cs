using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    public GameObject TargetObject;

    private void OnEnable()
    {
        TargetObject.SetActive(false);
    }
}
