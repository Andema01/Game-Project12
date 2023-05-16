using Godot;
using System;
using System.Collections.Generic;

public class Water : StaticBody2D
{
	private List<string> combination;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		combination = new List<string>();
	}
}

