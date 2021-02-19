using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Range(-1,1)]
    public float Direction = 0;

    [SerializeField]
    private ButtonMovement _bm;

    private bool _isPresed = false;

    private void Update()
    {
        if(_isPresed)
            _bm.SetDirection(Direction);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPresed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPresed = false;
    }
}
