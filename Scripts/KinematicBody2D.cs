using Godot;
using System;
using System.Drawing;
using System.Threading;
using Mutex = Godot.Mutex;

public class KinematicBody2D : Godot.KinematicBody2D
{
	private const int Speed = 1000; //скорость перемещения объекта
	private bool _isMousePressed = false;
	private Vector2 sizeWindows;
	private Sprite _light;
	private float xPosition;
	private float yPosition;

	public override void _Ready()
	{
		sizeWindows = OS.WindowSize;
		_light = GetNode<Sprite>("/root/Root/ColbaRed/Red/Light");
		xPosition = GlobalPosition.x;
		yPosition = GlobalPosition.y;
	}
	
	public override void _Process(float delta)
	{
		//изменение координат объекта
		if (!_isMousePressed)
		{
			RestorePosition();
			return;
		}
		_light.Visible = true;
		var vel = Speed * Dir() * delta;
		MoveAndSlide(vel);
	}
	
	private void RestorePosition()
	{
		// Восстановить позицию объекта
		GlobalPosition = new Vector2(xPosition, yPosition);
	}
	
	//Узел, на проверку нажатия левой клавиши мыши
	private void _on_KinematicBody2D_input_event(object viewport, object @event, int shape_idx) =>
		_isMousePressed = Input.IsActionPressed("ui_press_left");

	// Получение координат с округлением вниз (в сторону отрицательной бесконечности)
	private Vector2 Dir()
	{
		var dir = (GetGlobalMousePosition() - GlobalPosition).Floor();
		return dir;
	}
	
	private void _on_ColbaRed_mouse_entered()
	{
		_light.Visible = true;
	}
	
	private void _on_ColbaRed_mouse_exited()
	{
		_light.Visible = false;
	}

}

