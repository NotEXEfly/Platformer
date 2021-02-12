using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Stats _stats;
    [SerializeField]
    private Components _components;

    private Utilities _utilities;
    private Actions _actions;
    public Components Components { get => _components; }
    public Stats Stats { get => _stats; }
    public Actions Actions { get => _actions; }
    public Utilities Utilities { get => _utilities; }


    private void Start()
    {
        _utilities = new Utilities(this);
        _actions = new Actions(this);

        AnyStateAnimation[] animations = new AnyStateAnimation[]
        {
            new AnyStateAnimation(RIG.BODY, "Idle", "Attack"),
            new AnyStateAnimation(RIG.BODY, "Run", "Attack", "Jump"),
            new AnyStateAnimation(RIG.BODY, "Jump"),
            new AnyStateAnimation(RIG.BODY, "Fall"),
            new AnyStateAnimation(RIG.BODY, "Attack"),
            new AnyStateAnimation(RIG.BODY, "Death"),
        };
        _components.Animator.AddAnimations(animations);
    }

    private void Update()
    {
        if (_actions.IsFreeze) return;
        _utilities.HandleInput();
        _actions.CheckMovementState();
        _actions.PlayMovementAnimations();
    }

    private void FixedUpdate()
    {
        if (_actions.IsFreeze) return;
        _actions.Move();
    }
}
