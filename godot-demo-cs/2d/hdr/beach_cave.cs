using Godot;
using System;

public class beach_cave : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private int CAVE_LIMIT = 1000;
    private Sprite cave;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        cave = GetNode<Sprite>("Cave");
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseMotion motion && motion.ButtonMask > 0)
        {
            float rel_x = motion.Relative.x;
            Vector2 cavepos = cave.Position;
            cavepos.x += rel_x;
            if (cavepos.x < -CAVE_LIMIT)
            {
                cavepos.x = -CAVE_LIMIT;
            } else if (cavepos.x > 0)
            {
                cavepos.x = 0;
            }
            cave.Position = cavepos;
        }
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
