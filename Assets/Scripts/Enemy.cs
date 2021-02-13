using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;

    public float Speed = 100;
    private float _direction = -1;

    private void FixedUpdate()
    {
        float x = Speed * Time.fixedDeltaTime * _direction * 10;
        _rb.velocity = new Vector2(x, _rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RotatePoint")
        {
            _direction = -_direction;
        }
    }
}
