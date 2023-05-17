using Godot;
using System;

public class CoinCount : Label
{
	private Label countCoin;
	public CoinCount()
	{ 
	}

	public override void _Ready()
	{
		countCoin = GetNode<Label>("/root/Root/Node/UI/Control/Coin");
		countCoin.Text = "100";
	}

	public override void _Process(float delta)
	{
	}
	

}
