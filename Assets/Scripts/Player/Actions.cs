using UnityEngine;

public enum PlayerState
{
    OnGround,
    InAir,
    InFall
}

public class Actions
{
    private Player _player;
    private PlayerState _playerMovementState;

    public Actions(Player player)
    {
        _player = player;
    }

    public void Move()
    {
        _player.Components.RigitBody.velocity = new Vector2(_player.Stats.Direction.x * _player.Stats.RunSpeed * Time.deltaTime, _player.Components.RigitBody.velocity.y);

        if (_player.Stats.Direction.x != 0)
        {
            //flip
            _player.transform.localScale = new Vector2(_player.Stats.Direction.x < 0 ? -1 : 1, 1);
        }
    }

    public void Jump()
    {
        if (_playerMovementState == PlayerState.OnGround)
        {
            _player.Components.RigitBody.velocity = new Vector2(_player.Components.RigitBody.velocity.x, 0);
            _player.Components.RigitBody.AddForce(new Vector2(0, _player.Stats.JumpForce), ForceMode2D.Impulse);
            _player.Components.Animator.TryPlayAnimation("Jump");

            AudioManager.instance.Play("Jump");
        }
    }

    public void Attack()
    {
        AudioManager.instance.Play("test");
        _player.Components.Animator.TryPlayAnimation("Attack");
    }

    public void CheckMovementState()
    {
        bool playerOnGround = _player.Components.Collider.IsTouchingLayers(_player.Components.GroundLayer);
        if (playerOnGround)
            _playerMovementState = PlayerState.OnGround;
        else if (_player.Components.RigitBody.velocity.y < 0 && !playerOnGround)
            _playerMovementState = PlayerState.InFall;
        else
            _playerMovementState = PlayerState.InAir;
    }

    public void PlayMovementAnimations()
    {
        switch (_playerMovementState)
        {
            case PlayerState.OnGround:
                if (_player.Components.RigitBody.velocity == Vector2.zero)
                    _player.Components.Animator.TryPlayAnimation("Idle");
                else if (_player.Stats.Direction.x != 0)
                    _player.Components.Animator.TryPlayAnimation("Run");
                break;
            case PlayerState.InFall:
                _player.Components.Animator.TryPlayAnimation("Fall");
                break;
            default:
                break;
        }
    }
}