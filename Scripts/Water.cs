using System.Collections.Generic;
using Godot;

namespace Game.Scripts
{
	public class Water
	{
		private static string _combination;
	
		public void AddList(string name)
		{
			_combination += ConvertColor(name);
		}

		public string Return()
		{
			return _combination;
		}

		public void Remove()
		{
			_combination = "";
		}

			private static string ConvertColor(string name)
			{
				return name switch
				{
					"FlaskRed" => "R",
					"FlaskBlue" => "B",
					"FlaskYellow" => "Y",
					"FlaskGreen" => "G",
					"FlaskOrange" => "O",
					"FlaskPurple" => "P",
					"FlaskWhite" => "W",
					"FlaskBlack" => "Z",
					_ => ""
				};
			}
	}
}