using Godot;
using System;

public class AddColba : Area2D
{
	private bool _isMousePressed = false;
	private Label coin = new Label();
	
	public override void _Ready()
	{

	}
	
	public override void _Process(float delta)
	{		

	}
	private void _on_AddColba_input_event(object viewport, object @event, int shape_idx) =>
		_isMousePressed = Input.IsActionPressed("ui_press_left");
	
}

