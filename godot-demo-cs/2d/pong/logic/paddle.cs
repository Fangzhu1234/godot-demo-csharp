using Godot;
using System;

public class paddle : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    const float MOVE_SPEED = 100;

    float _ball_dir;
    string _up;
    string _down;
    float _screen_size_y;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _screen_size_y = GetViewportRect().Size.y;

        string n = Name.ToLower();
        _up = n + "_move_up";
        _down = n + "_move_down";
        if (n == "left")
        {
            _ball_dir = 1;
        }
        else
        {
            _ball_dir = -1;
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        float input = Input.GetActionStrength(_down) - Input.GetActionStrength(_up);
        Vector2 pos = Position;
        pos += new Vector2(0, input * MOVE_SPEED * delta);
        pos.y = Mathf.Clamp(pos.y, 16, _screen_size_y - 16);
        Position = pos;
    }

    public void OnAreaEntered(Area2D area)
    {
        if ( area is Ball ball)
        {
            ball.direction = new Vector2(_ball_dir, GD.Randf() * 2 - 1);
            // ball.direction = new Vector2(_ball_dir, ((float)new Random().NextDouble()) * 2 - 1).Normalized();
        }
    }
}
