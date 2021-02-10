using UnityEngine;

public class JumpCommand : Command
{
    private Player _player;

    public JumpCommand(Player player, KeyCode key) : base(key)
    {
        _player = player;
    }

    public override void GetKeyDown()
    {
        //FindObjectOfType<AudioManager>().Play("JumpSound");
        _player.Actions.Jump();
    }
}
