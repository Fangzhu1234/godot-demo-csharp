using Godot;
using System;

public class troll : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    const int MOTION_SPEED = 160;
    float TAN30DEG = Mathf.Tan(Mathf.Deg2Rad(30));

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public override void _PhysicsProcess(float delta)
    {
        Vector2 motion = new Vector2();
        motion.x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        motion.y = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");
        motion.y *= TAN30DEG;
        motion = motion.Normalized() * MOTION_SPEED;
        MoveAndSlide(motion);
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
