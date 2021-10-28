using Godot;
using System;

public class player : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    const int WALK_FORCE = 600;
    const int WALK_MAX_SPEED = 200;
    const int STOP_FORCE = 1300;
    const int JUMP_SPEED = 200;

    Vector2 velocity = Vector2.Zero;
    string gravity;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").ToString();
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        float walk = WALK_FORCE * (Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left"));
        if (Mathf.Abs(walk) < WALK_FORCE * 0.2)
        {
            velocity.x = Mathf.MoveToward(velocity.x, 0, STOP_FORCE * delta);
        }
        else
        {
            velocity.x = walk * delta;
        }
        velocity.x = Mathf.Clamp(velocity.x, -WALK_MAX_SPEED, WALK_MAX_SPEED);

        velocity.y += gravity.ToFloat() * delta;
        velocity = MoveAndSlideWithSnap(velocity, Vector2.Down, Vector2.Up);
        if (IsOnFloor() && Input.IsActionJustPressed("jump"))
        {
            velocity.y = -JUMP_SPEED;
        }
    }
    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
