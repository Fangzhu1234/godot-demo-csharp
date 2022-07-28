using Godot;
using System;

public class BallFactory : Node2D
{
	[Export]
	public PackedScene BallScene;

	public override void _Ready()
	{
		BallScene = ResourceLoader.Load<PackedScene>("res://Ball.tscn");
	}
	public override void _UnhandledInput(InputEvent @event)
	{
		base._UnhandledInput(@event);
		if (@event.IsEcho()) {
			return;
		}
		if (@event is InputEventMouseButton && @event.IsPressed()) {
			if (true) {
				spawn(GetGlobalMousePosition());
			}
		}
	}

	private void spawn(Vector2 SpawnGlobalPosition) {
		var instance = BallScene.Instance() as RigidBody2D;
		instance.GlobalPosition = SpawnGlobalPosition;
		AddChild(instance);
	}
}
