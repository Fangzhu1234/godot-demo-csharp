using Godot;
using System;

public class screen_shaders : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private OptionButton effect;
    private Control effects;
    private OptionButton picture;
    private Control pictures;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        effect = GetNode<OptionButton>("Effect");
        effects = GetNode<Control>("Effects");
        picture = GetNode<OptionButton>("Picture");
        pictures = GetNode<Control>("Pictures");

        foreach (TextureRect c in pictures.GetChildren())
        {
            picture.AddItem("PIC: " + c.Name.ToString());
        }
        foreach (Node c in effects.GetChildren())
        {
            effect.AddItem("FX: " + c.Name.ToString());
        }
    }

    public void _on_picture_item_selected(int ID)
    {
        foreach (int c in GD.Range(pictures.GetChildCount()))
        {
            if (ID == c)
            {
                pictures.GetChild<TextureRect>(c).Show();
            }
            else
            {
                pictures.GetChild<TextureRect>(c).Hide();
            }
        }
    }

    public void _on_effect_item_selected(int ID)
    {
        foreach (int c in GD.Range(effects.GetChildCount()))
        {
            // skip disable effect option
            if (c == 0)
                continue;
            if (ID == c)
            {
                effects.GetChild<TextureRect>(c).Show();
            }
            else
            {
                effects.GetChild<TextureRect>(c).Hide();
            }
        }
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
