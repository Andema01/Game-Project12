using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class CheckIng : Node
{
	private string[] _ingredient;
	private string[] _name;
	private int _index;
	public JArray jsonArray;
	private JToken[] tokens;

	public override void _Ready()
	{
		var file = new File();
		if (file.FileExists("res://Temp/potions.json"))
		{
			file.Open("res://Temp/potions.json", File.ModeFlags.Read);
			string fileContent = file.GetAsText();
			file.Close();

			jsonArray = JArray.Parse(fileContent);

			_ingredient = new string[jsonArray.Count];
			tokens = new JToken[jsonArray.Count];
			for (int i = 0; i < jsonArray.Count; i++)
			{
				_ingredient[i] = (string)jsonArray[i]["Color"];
				tokens[i] = jsonArray[i]["Name"];
			}

			GD.Print("Список загружен");
		}
		else
		{
			GD.Print("Файл не найден");
		}
	}

	public Flask Check(string ingredientColor)
	{
		foreach (var arrayElem in jsonArray)
		{
			var flask = (Flask)arrayElem.ToObject(typeof(Flask));
			if (flask.Color.Equals(ingredientColor))
			{
				return flask;
			}
		}
		return null;
		// var a = jsonArray.SelectToken("Red");
		// if (_ingredient.Contains(ingredient))
		// {
		// 
		// }
	}
}
