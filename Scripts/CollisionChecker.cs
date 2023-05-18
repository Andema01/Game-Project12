using Godot;
using System;
using Game.Scripts;

public class CollisionChecker : Node2D
{
	private Water _water;
	private Flask _flask;
	private Potions _potions;
	private bool _isMousePressed;
	var data = JSON.parse(json_str)

	public override void _Ready()
	{
		Connect("body_entered", this, nameof(OnBodyEntered));
		Connect("body_exited", this, nameof(OnBodyExited));
		Connect("input_event", this, nameof(OnInputEvent));

		_flask = new Flask();
		_potions = new Potions();
		_water = new Water();
	}
	public override void _Process(float delta)
	{
		if (_isMousePressed)
		{
			
		}
	}
	
	private void OnInputEvent(object viewport, object @event, int shapeIdx) =>
		_isMousePressed = Input.IsActionPressed("ui_press_left");
	public void OnBodyEntered(Node body)
	{
	}

	public void OnBodyExited(Node body)
	{
	}
	private void _on_Cook_pressed()
	{ 
		GD.Print("Cook");
		_potions._Ready();
	}
}



