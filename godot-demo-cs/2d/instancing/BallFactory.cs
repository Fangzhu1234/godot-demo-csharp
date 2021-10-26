using Godot;
using System;

public class BallFactory : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    PackedScene ball_scene;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ball_scene = (PackedScene)ResourceLoader.Load("res://ball.tscn");
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsEcho())
        {
            return;
        }
        if (@event is InputEventMouseButton mouseButton)
        {
            if (mouseButton.ButtonIndex == (int)ButtonList.Left)
            {
                spawn(GetGlobalMousePosition());
            }
        }
    }
    private void spawn(Vector2 global_position)
    {
        RigidBody2D instance = ball_scene.Instance() as RigidBody2D;
        instance.GlobalPosition = global_position;
        this.AddChild(instance);
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
