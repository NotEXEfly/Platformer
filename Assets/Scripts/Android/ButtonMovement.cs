using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    private Player _player;

    private float _directionX = 0;

    private void Start()
    {
        _player = GetComponent<Player>();
    }
#if UNITY_ANDROID
    private void Update()
    {
        _player.Stats.Direction = new Vector2(_directionX, _player.Components.RigitBody.velocity.y);

        _directionX = 0;
    }
#endif
    public void SetDirection(float value)
    {
        if (value == -1f || value == 1f)
            _directionX = value;
    }

    public void Jump()
    {
        _player.Actions.Jump();
    }
}
