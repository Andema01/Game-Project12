using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class AddColba : Area2D
{
	private bool _isMousePressed = false;
	private int _priceWorld = 10;
	private Label _countCoin;
	private Sprite _light;
	private Sprite _addlight;
	private Label _message;

	private static readonly List<string> Employees = new List<string>
	{
		"Red", "Blue", "Yellow", "Green", "Orange", "Purple","White"
	};
	Queue<string> typeColba = new Queue<string>(Employees);
	
	public override void _Ready()
	{
		_countCoin = GetNode<Label>("/root/Root/Node/Control/Coin");
		_message = GetNode<Label>("/root/Root/Node/Control/Message");
		_light = GetNode<Sprite>("/root/Root/AddColba/Add/Light");
		_addlight = GetNode<Sprite>("/root/Root/AddColba/Add/AddLight");
		
		Connect("input_event", this, nameof(OnInputEvent));
		Connect("mouse_entered", this, nameof(OnMouseEntered));
		Connect("mouse_exited", this, nameof(OnMouseExited));
	}
	public override void _Process(float delta)
	{
		if (_isMousePressed)
			_countCoin.Text = CheckCoin();
	}
	
	private void OnInputEvent(object viewport, object @event, int shapeIdx)
	{
		_isMousePressed = Input.IsActionPressed("ui_press_left");
	}
	private string CheckCoin()
	{
		int coin = Int32.Parse(_countCoin.Text);
		int percent = 0;
		
		var ingd = new CheckIng();
		ingd._Ready();
		var a = ingd.jsonArray[0]["price"];
		foreach (JObject item in ingd.jsonArray)
		{
			var name = (string)item["Name"];
			var percentT = (double)item["Percent"];
			if (!string.Equals(name, typeColba.Peek(), StringComparison.CurrentCultureIgnoreCase)) continue;
			percent = (int)percentT;
			break;
		}

		if (typeColba.Count == 0) return _countCoin.Text;
		if (coin < _priceWorld)
		{
			_message.Text = "Недостаточно монет!";
			return _countCoin.Text;
		}

		AddFlask(typeColba.Dequeue());
		_isMousePressed = false;
			
		_countCoin.Text = (coin - _priceWorld).ToString();
		_priceWorld = CalculateNewPrice(_priceWorld, percent);
		return _countCoin.Text;
	}
	
	private static int CalculateNewPrice(int oldPrice, int percentIncrease)
	{
		int increaseAmount = oldPrice * percentIncrease / 100;
		int newPrice = oldPrice + increaseAmount;
		return newPrice;
	}
	
	private void AddFlask(string type)
	{
		var node = GetNode<KinematicBody2D>("/root/Root/Flask" + type);
		KinematicBody2D node2 = null;
		
		_message.Text = type + " колба добавлена!\n";
		if (typeColba.Count != 0)
			node2 = GetNode<KinematicBody2D>("/root/Root/Flask" + typeColba.Peek());
		else
		{
			Visible = false;
			_message.Text = "Все колбы куплены. Колб больше нет!\n";
		}

		if (node == null) return;
		node.Visible = true;
		if (node2 != null) Position = node2.Position;
	}
	private void OnMouseEntered()
	{
		_light.Visible = true;
		_addlight.Visible = true;
	}
	private void OnMouseExited()
	{
		_light.Visible = false;
		_addlight.Visible = false;
	}
}
