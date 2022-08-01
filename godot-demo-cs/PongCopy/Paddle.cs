using Godot;
using System;

public class Paddle : Area2D
{
    private const int MoveSpeed = 200;
    private int _ballDir;
    private string _up;
    private string _down;
    public override void _Ready()
    {
        string name = Name.ToLower();
        _up = name + "_up";
        _down = name + "_down";
        _ballDir = name == "leftpaddle" ? 1 : -1;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        // move by input
        float input = Input.GetActionStrength(_down) - Input.GetActionStrength(_up);
        Vector2 position = Position;
        position += new Vector2(0, input * MoveSpeed * delta);
        position.y = Mathf.Clamp(position.y, 60, GetViewportRect().Size.y - 60);
        Position = position;
    }

}
