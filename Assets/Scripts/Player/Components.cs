using UnityEngine;

[System.Serializable]
public class Components
{
    [SerializeField]
    private Rigidbody2D _rigitBody;

    [SerializeField]
    private AnyStateAnimator _animator;

    [SerializeField]
    private LayerMask _groundLayer;

    [SerializeField]
    private Collider2D _collider;

    public Rigidbody2D RigitBody { get => _rigitBody; }
    public AnyStateAnimator Animator { get => _animator; }
    public LayerMask GroundLayer { get => _groundLayer; }
    public Collider2D Collider { get => _collider; }
}
