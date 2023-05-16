using Godot;
using System;
using System.Drawing;

public class KinematicBody2D : Godot.KinematicBody2D
{
	private const int Speed = 1000; //скорость перемещения объекта
	private bool _isMousePressed = false;
	private Vector2 sizeWindows;

	public override void _Ready()
	{
		sizeWindows = OS.WindowSize;
	}
	
	public override void _Process(float delta)
	{
		//изменение координат объекта
		if (!_isMousePressed) return;
		
		var vel = Speed * Dir() * delta;
		MoveAndSlide(vel);
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
}
