using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _traget;

    void LateUpdate()
    {
        transform.position = new Vector3(_traget.position.x, transform.position.y, transform.position.z);
    }
}
