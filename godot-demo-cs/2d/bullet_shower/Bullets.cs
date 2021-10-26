using Godot;
using System;

public class Bullets : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	const int BULLET_COUNT = 500;
	const double SPEED_MIN = 20.0;
	const double SPEED_MAX = 80.0;
	Texture bullet_image = null;
	RID shape = null;
	private class Bullet
	{
		public Vector2 position = new Vector2();
		public double speed = 1.0;
		public RID body = null;
	}
	Bullet[] bullets = new Bullet[BULLET_COUNT];

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Randomize();

		bullet_image = GD.Load<Texture>("res://bullet.png");
		shape = Physics2DServer.CircleShapeCreate();
		Physics2DServer.ShapeSetData(shape, 8);

		for (int i = 0; i < BULLET_COUNT; i++)
		{
			Bullet bullet = new Bullet();
			bullet.speed = GD.RandRange(SPEED_MIN, SPEED_MAX);
			bullet.body = Physics2DServer.BodyCreate();

			Physics2DServer.BodySetSpace(bullet.body, GetWorld2d().Space);
			Physics2DServer.BodyAddShape(bullet.body, shape);

			bullet.position = new Vector2(
				(float)GD.RandRange(0, GetViewportRect().Size.x) + GetViewportRect().Size.x,
				(float)GD.RandRange(0, GetViewportRect().Size.y)
			);
			Transform2D transform2d = new Transform2D();
			transform2d.origin = bullet.position;
			Physics2DServer.BodySetState(bullet.body, Physics2DServer.BodyState.Transform, transform2d);
			bullets[i] = bullet;
		}
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		Update();
	}

	public override void _PhysicsProcess(float delta)
	{
		base._PhysicsProcess(delta);
		Transform2D transform2d = new Transform2D();
		double offset = GetViewportRect().Size.x + 16;
		foreach(Bullet bullet in bullets)
		{
			bullet.position.x -= (float)bullet.speed * delta;
			if (bullet.position.x < -16)
			{
				bullet.position.x = (float)offset;
			}
			transform2d.origin = bullet.position;
			Physics2DServer.BodySetState(bullet.body, Physics2DServer.BodyState.Transform, transform2d);
		}
	}

	public override void _Draw()
	{
		base._Draw();
		Vector2 offset = new Vector2(-(float)bullet_image.GetSize().x * 0.5f, -(float)bullet_image.GetSize().y * 0.5f);
		foreach (Bullet bullet in bullets)
		{
			DrawTexture(bullet_image, bullet.position + offset);
		}
	}

	public override void _ExitTree()
	{
		base._ExitTree();
		foreach (Bullet bullet in bullets)
		{
			Physics2DServer.FreeRid(bullet.body);
		}
		Physics2DServer.FreeRid(shape);
		
	}
}
