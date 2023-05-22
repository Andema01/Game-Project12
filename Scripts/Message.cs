using Godot;
using System;

public class Message : Label
{
	private Label _message;
 
   public override void _Ready()
	{
		_message = GetNode<Label>("/root/Root/Node/Control/Message");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
