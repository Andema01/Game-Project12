using Godot;

public class MoveFlask : KinematicBody2D
{
	private const int Speed = 1200; //скорость перемещения объекта
	private bool _isMousePressed;
	private Sprite _light;
	private float _xPosition;
	private float _yPosition;

	public override void _Ready()
	{
		_light = GetNode<Sprite>(GetPath() + "/Flask/Light");
		_xPosition = GlobalPosition.x;
		_yPosition = GlobalPosition.y;
		
		//подключения узлов
		Connect("input_event", this, nameof(OnInputEvent));
		Connect("mouse_entered", this, nameof(OnMouseEntered));
		Connect("mouse_exited", this, nameof(OnMouseExited));
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
		GlobalPosition = new Vector2(_xPosition, _yPosition);
	}
	
	//Узел, на проверку нажатия левой клавиши мыши
	private void OnInputEvent(object viewport, object @event, int shapeIdx) =>
		_isMousePressed = Input.IsActionPressed("ui_press_left");

	// Получение координат с округлением вниз (в сторону отрицательной бесконечности)
	private Vector2 Dir()
	{
		var dir = (GetGlobalMousePosition() - GlobalPosition).Floor();
		return dir;
	}
	
	private void OnMouseEntered()
	{
		_light.Visible = true;
		ZIndex = 1;
		CollisionLayer = 2;
		CollisionMask = 2;
	}
	
	private void OnMouseExited()
	{
		_light.Visible = false;
		if (!_isMousePressed)
		{
			ZIndex = 0;
			CollisionLayer = 1;
			CollisionMask = 1;
		}
	}
}

