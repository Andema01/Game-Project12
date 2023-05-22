using Godot;
using System;

public class CoinCount : Label
{
	private Label _countCoin;

	public override void _Ready()
	{
		_countCoin = GetNode<Label>("/root/Root/Node/Control/Coin");
		_countCoin.Text = "45";
	}

	// public override void _Process(float delta)
	// {
	// }
}
