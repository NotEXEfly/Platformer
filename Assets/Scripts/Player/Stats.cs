using UnityEngine;

[System.Serializable]
public class Stats
{
    public Vector2 Direction { get; set; }

    [SerializeField]
    private float _runSpeed;

    [SerializeField]
    private float _jumpForce;

    public float RunSpeed { get => _runSpeed; }
    public float JumpForce { get => _jumpForce; }
}
