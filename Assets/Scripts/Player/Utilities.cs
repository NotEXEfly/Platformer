using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    private Player _player;

    private List<Command> _commands = new List<Command>();

    public Utilities(Player player)
    {
        _player = player;
        _commands.Add(new JumpCommand(_player, KeyCode.Space));
        _commands.Add(new AttackCommand(_player, KeyCode.E));
    }

    public void HandleInput()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        _player.Stats.Direction = new Vector2(Input.GetAxisRaw("Horizontal"), _player.Components.RigitBody.velocity.y);
#endif


        foreach (Command command in _commands)
        {
            if (Input.GetKeyDown(command.Key))
            {
                command.GetKeyDown();
            }

            if (Input.GetKeyUp(command.Key))
            {
                command.GetKeyUp();
            }

            if (Input.GetKey(command.Key))
            {
                command.GetKey();
            }
        }
    }
}
