using Godot;
using System;

public class Ball : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private const int DEFAULT_SPEED = 100;

    private float _speed = DEFAULT_SPEED;
    public Vector2 direction = Vector2.Left;
    private Vector2 _initial_pos;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _initial_pos = Position;
    }

    public override void _Process(float delta)
    {
        _speed += delta * 2;
        Position += _speed * delta * direction;
    }

    public void reset()
    {
        direction = Vector2.Left;
        Position = _initial_pos;
        _speed = DEFAULT_SPEED;
    }
}
