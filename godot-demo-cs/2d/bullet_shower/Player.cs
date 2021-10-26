using Godot;
using System;

public class Player : Area2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	public int touching = 0;
	private AnimatedSprite sprite;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sprite = GetNode<AnimatedSprite>("AnimatedSprite");
		Input.SetMouseMode(Input.MouseMode.Hidden);
	}

	public override void _Input(InputEvent inputEvent)
	{
		if (inputEvent is InputEventMouseMotion mouseEvent)
		{
			Position = mouseEvent.Position - new Vector2(0, 16);
		}
	}

	public void OnBodyShapeEntered(int _body_id,Node _body, int _body_shape, int _local_shape)
	{
		touching++;
		if (touching >= 1)
		{
			sprite.Frame = 1;
		}
	}
	public void OnBodyShapeExited(int _body_id,Node _body, int _body_shape, int _local_shape)
	{
		touching--;
		if (touching == 0)
		{
			sprite.Frame = 0;
		}
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
