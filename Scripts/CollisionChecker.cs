using Godot;
using System;
using Game.Scripts;

public class CollisionChecker : Node2D
{
	private Water _water;
	private Potions _potions;
	private Flask _flask;
	private bool _isMousePressed;
	private Label _message;
	private Label _countCoin;
	private Label _list;

	public override void _Ready()
	{
		Connect("body_entered", this, nameof(OnBodyEntered));
		Connect("body_exited", this, nameof(OnBodyExited));
		Connect("input_event", this, nameof(OnInputEvent));
		
		_message = GetNode<Label>("/root/Root/Node/Control/Message");
		_countCoin = GetNode<Label>("/root/Root/Node/Control/Coin");
		_list = GetNode<Label>("/root/Root/Node/Control/List");

		_flask = new Flask();
		_water = new Water();
		_potions = new Potions();
		
		_potions._Ready();
	}
	public override void _Process(float delta)
	{
	}
	
	private void OnInputEvent(object viewport, object @event, int shapeIdx) =>
		_isMousePressed = Input.IsActionPressed("ui_press_left");
	public void OnBodyEntered(Node body)
	{
		_water.AddList(body.Name);
		_list.Text += body.Name + "\n";
	}

	public void OnBodyExited(Node body) { }
	
	private void _on_Cook_pressed()
	{
		var ingd = new CheckIng();
		ingd ._Ready();
		var name = ingd.Check(_water.Return());
		if (name != null)
		{
			_message.Text = $"Вы изготовили зелье: {name.Name}!\n" +
			                $"Вы получете {name.Price} монет";
			_countCoin.Text = (Int32.Parse(_countCoin.Text) + name.Price).ToString();
		}
		else
		{
			_message.Text = "Неудача. Попробуйте еще раз";
		}
		_water.Remove();
		_list.Text = "";
	}
}



