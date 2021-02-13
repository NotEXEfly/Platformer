using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _traget;

    void LateUpdate()
    {
        float x = _traget.position.x; //Mathf.Lerp(transform.position.x, _traget.position.x, 0.01f);
        float y = _traget.position.y;

        if (_traget.position.y < 0) 
            y = 0;

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
