using Godot;
using System;

public class Princess : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }
    public void OnBodyEntered(Node body)
    {
        if (body.Name == "Player")
        {
            GetNode<Label>("../WinText").Show();
        }
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
