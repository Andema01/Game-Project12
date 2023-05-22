using Godot;
using System;

public class RecipeBut : Button
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Connect("_on_pressed", this, nameof(OnPressed));
	}

	private void OnPressed()
	{
		var file = new File();
		if (!file.FileExists("res://Temp/recipes.png")) return;
		file.Open("res://Temp/recipes.png", File.ModeFlags.Read);
		
	}

}

