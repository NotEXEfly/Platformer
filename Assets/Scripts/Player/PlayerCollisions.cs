using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public delegate void CoinsHandler();
    public static event CoinsHandler OnCoinCollision;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Coin":
                OnCoinCollision?.Invoke();
                Destroy(collision.gameObject);
                break;
            case "Death":
                _player.Actions.Freeze();
                _player.Components.Animator.TryPlayAnimation("Death");
                AudioManager.instance.Play("Death");
                GameManager.instance.Lose();
                break;
            default:
                break;
        }
    }
}
