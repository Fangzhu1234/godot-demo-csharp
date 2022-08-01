using Godot;
using System;

public class Ball : Area2D
{
    private const int DefaultSpeed = 100;
    public Vector2 direction = Vector2.Left;

    private Vector2 _initialPos;
    private float _speed = DefaultSpeed;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _initialPos = Position;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        _speed += delta * 2;
        Position += _speed * delta * direction;
    }

    public void Reset()
    {
        direction = Vector2.Left;
        Position = _initialPos;
        _speed = DefaultSpeed;
    }

    public void OnAreaEntered(Area2D area)
    {
        if (area is LeftPaddle left)
        {
            direction.x = -direction.x;
            
        }
    }
}
