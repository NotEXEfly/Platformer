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

    private void Update()
    {
        
        if (!GameManager.instance.GameIsPlay && !_player.Actions.IsFreeze)
        {
            if (Mathf.Abs(_player.Components.RigitBody.velocity.x) > 0.2f)
            {
                GameManager.instance.Play();
            }
        }
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
                if (GameManager.instance.GameIsPlay)
                {
                    _player.Actions.Freeze(true);
                    _player.Components.Animator.TryPlayAnimation("Death");
                    GameManager.instance.Lose();
                }
                break;
            case "Win":
                _player.Actions.Freeze(true);
                GameManager.instance.Win();
                break;
            default:
                break;
        }
    }
}
