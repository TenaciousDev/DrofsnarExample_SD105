using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrofsnarExample
{
    class Program
    {
        //Path to text file
        private static string _path = "C:/00_ElevenFifty/01_TeachingTools/DrofsnarExample/DrofsnarExample/game-sequence.txt";
        static void Main(string[] args)
        {
            //new up an instance of our game
            Game game = new Game();
            //call our set events method
            game.SetEvents(GetEventsFromFile(_path));
            //run the game
            game.Run();
            //freeze the console
            Console.ReadLine();
        }

        //Helper Method
        //Get events from file and split them into an array
        private static string[] GetEventsFromFile(string filePath)
        {
            string text = File.ReadAllText(filePath);
            string[] output = text.Split(',');
            return output;
        }
    }
}
