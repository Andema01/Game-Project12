using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

public class AddColba : Area2D
{
	private bool _isMousePressed = false;
	private Label _countCoin;
	private Sprite _light;
	private PopupDialog _popup;
	private Label _text;
	private bool isProcessing = false;
	private int i = 0;
	
	static List<string> employees = new List<string> { "red", "blue", "yellow" };
	Queue<string> typeColba = new Queue<string>(employees);
	
	public override void _Ready()
	{
		_countCoin = GetNode<Label>("/root/Root/Node/UI/Control/Coin");
		_light = GetNode<Sprite>("/root/Root/AddColba/Add/Light");
		_popup = GetNode<PopupDialog>("/root/Root/Node/UI/Control/PopupDialog");
		_text = GetNode<Label>("/root/Root/Node/UI/Control/PopupDialog/Label");
	}
	
	public override void _Process(float delta)
	{
		if (_isMousePressed && isProcessing)
		{ 
			_countCoin.Text = CheckCoin();
			isProcessing = false;
		}
	}
	
	private void _on_AddColba_input_event(object viewport, object @event, int shape_idx)
	{
		_isMousePressed = Input.IsActionPressed("ui_press_left");
		if(i == 0) isProcessing = true;
	}
	private string CheckCoin()
	{
		i = 1;
		int coin = Int32.Parse(_countCoin.Text);
		const int baseCount = 40;
		int count = baseCount, procent = 50;
		if (typeColba.Count == 0)
		{
			_popup.Visible = true;
			_text.Text = "Все колбы куплены. Больше колб нет!";

		}
		if (typeColba.Count != 0)
		{
			if (coin < count)
			{
				_popup.Visible = true;
				_text.Text = "Недостаточно монет";
				return _countCoin.Text;
			}
			else
			{
				CreateColba(typeColba.Dequeue());
				_countCoin.Text = (coin - count).ToString();
			}
			count = count * (procent / 100);
		}
		return _countCoin.Text;
	}
	
	private void _on_AddColba_mouse_entered()
	{
		_light.Visible = true;
		i = 0;
	}
	private void _on_AddColba_mouse_exited() 
	{
		_light.Visible = false;
		i = 0;
	}

	private void CreateColba(string type)
	{
		GD.Print("Create " + type);
		var colba = new KinematicBody2D();	
		
	}
}
