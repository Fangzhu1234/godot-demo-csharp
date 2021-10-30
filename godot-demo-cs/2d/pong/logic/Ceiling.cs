using Godot;
using System;

public class Ceiling : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export]
    private float _bounce_direction = 1;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    public void OnAreaEntered(Area2D area)
    {
        if (area is Ball ball)
        {
            GD.Print("before:" + ball.direction);
            ball.direction = (ball.direction + new Vector2(0, _bounce_direction)).Normalized();
            GD.Print("after:" + ball.direction);
        }
    }
}
