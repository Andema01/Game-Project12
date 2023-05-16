using Godot;
using System;

public class CollisionChecker : Node2D
{
	private Water _water = new Water();
	public override void _Ready()
	{
		Connect("body_entered", this, nameof(OnBodyEntered));
		Connect("body_exited", this, nameof(OnBodyExited));
	}

	public void OnBodyEntered(Node body)
	{
		GD.Print("Body entered: " + body.Name);
	}

	public void OnBodyExited(Node body)
	{
		GD.Print("Body exited: " + body.Name);
	}
}
