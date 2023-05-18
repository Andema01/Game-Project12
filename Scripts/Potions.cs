using System;
using System.Collections.Generic;
using Godot;
using Newtonsoft.Json;

namespace Game.Scripts
{
    public class Potions
    {
        public  void _Ready()
        {
            var flasks = new List<Flask>
            {
                //Базовые
                new Flask
                {
                    Name = "Red",
                    Color = "R",
                    Price = 2d,
                    Percent = 0d
                },

                new Flask
                {
                    Name = "Yellow",
                    Color = "Y",
                    Price = 2d,
                    Percent = 0d
                },
                new Flask
                {
                    Name = "Blue",
                    Color = "B",
                    Price = 2d,
                    Percent = 0d
                },
                new Flask
                {
                    Name = "Orange",
                    Color = "O",
                    Price = 2d,
                    Percent = 5d
                },
                new Flask
                {
                    Name = "Purple",
                    Color = "P",
                    Price = 2d,
                    Percent = 5d
                },
                new Flask
                {
                    Name = "Green",
                    Color = "G",
                    Price = 2d,
                    Percent = 5d
                },
                new Flask
                {
                    Name = "White",
                    Color = "W",
                    Price = 10d,
                    Percent = 10d
                },
                new Flask
                {
                    Name = "Black",
                    Color = "Z",
                    Price = 10d,
                    Percent = 10d
                },

                //Сложные
                new Flask
                {
                    Name = "Health",
                    Color = "RR",
                    Price = 12d,
                    Percent = 15d
                },
                new Flask
                {
                    Name = "Mana",
                    Color = "MM",
                    Price = 2d,
                    Percent = 1d
                },
                new Flask
                {
                    Name = "Sleep",
                    Color = "MP",
                    Price = 2d,
                    Percent = 1d
                },
                new Flask
                {
                    Name = "Strong",
                    Color = "BY",
                    Price = 2d,
                    Percent = 1d
                }
            };
            var str = JsonConvert.SerializeObject(flasks); 
            WriteToFile("res://Temp/potions.json", str);
        }

        private static void WriteToFile(string path, string text)
        {
            var file = new File();
        
            file.Open(path, File.ModeFlags.Write);
            file.StoreLine(text);
            file.Close();
        
        }
    }

    class Flask
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public double Percent { get; set; }
    }
}