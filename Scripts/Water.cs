using System.Collections.Generic;
using Godot;

namespace Game.Scripts
{
	public class Water
	{
		private static string _combination = "";
	
		public static void AddList(string name)
		{
			_combination += ConvertColor(name);
		}

		public static void Return()
		{
			GD.Print(_combination);
		}

		private static string ConvertColor(string name)
		{
			switch (name)
			{
				case "FlaskRed": return "R";
				case "FlaskBlue": return "B";
				case "FlaskYellow": return "Y";
				case "FlaskGreen": return "G";
				case "FlaskOrange": return "O";
				case "FlaskPurple": return "P";
				case "FlaskWhite": return "W";
				case "FlaskBlack": return "Z";
				default: return "";
			}
		}
	}
}