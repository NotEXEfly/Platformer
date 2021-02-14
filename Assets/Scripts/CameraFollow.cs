using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _traget;

    private void LateUpdate()
    {
        float posX = _traget.position.x; 
        float posY = _traget.position.y;

        if (_traget.position.y < 0)
            posY = 0;

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}