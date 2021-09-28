using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DrofsnarExample
{
    //Bird Hunters, Birds, and Values
    public enum EntitiesAndValues
    {

        InvincibleBirdHunter,
        VulnerableBirdHunter,
        Bird = 10,
        CrestedIbis = 100,
        GreatKiskudee = 300,
        RedCrossbill = 500,
        Red_neckedPhalarope = 700,
        EveningGrosbeak = 1000,
        GreaterPrairieChicken = 2000,
        IcelandicGull = 3000,
        Orange_belliedParrot = 5000
    }

    class Game
    {
        private static readonly int _extraLifeThreshold = 10000;
        private string[] _events;

        //Translate between our text file and the scoring system we've set up
        private static readonly Dictionary<string, int> _entityScoreDictionary = new Dictionary<string, int>
        {
            {"Bird", (int)EntitiesAndValues.Bird },
            {"CrestedIbis", (int)EntitiesAndValues.CrestedIbis },
            { "GreatKiskudee", (int)EntitiesAndValues.GreatKiskudee },
            { "RedCrossbill", (int)EntitiesAndValues.RedCrossbill },
            { "Red-neckedPhalarope", (int)EntitiesAndValues.Red_neckedPhalarope },
            { "EveningGrosbeak", (int)EntitiesAndValues.EveningGrosbeak },
            { "GreaterPrairieChicken", (int)EntitiesAndValues.GreaterPrairieChicken },
            { "IcelandGull", (int)EntitiesAndValues.IcelandicGull },
            { "Orange-belliedParrot", (int)EntitiesAndValues.Orange_belliedParrot },
            { "InvincibleBirdHunter", (int)EntitiesAndValues.InvincibleBirdHunter },
            { "VulnerableBirdHunter", (int)EntitiesAndValues.VulnerableBirdHunter}
        };

        //Helper method to set up our events from the text file
        public void SetEvents(string[] events)
        {
            _events = events;
        }

        public void Run()
        {
            Console.Clear();

            //Initialize key variables
            int score = 5000;
            int lives = 3;
            int hunters = 0;
            //int spentScore = 0;
            string lifeEvent;
            bool isDead = false;
            bool earnedExtraLife = false;

            //Make sure there are events in our array (error handling)
            if (_events.Length == 0)
            {
                Console.WriteLine("No events given.");
                return;
            }

            Console.WriteLine($"{"Event",-30} {"Score",-15} {"Lives",-15} {"Life Event",-15}");
            Console.WriteLine(new String('-', 75));

            //Go through each event in our array
            foreach (string gameEvent in _events)
            {
                lifeEvent = "";

                //HUNTER OR BIRD?
                if (gameEvent == "InvincibleBirdHunter")
                {
                    lives--;
                    lifeEvent = "-1 Life";
                    hunters = 0;

                }
                else if (gameEvent == "VulnerableBirdHunter")
                {
                    double power = Math.Pow(2d, (double)hunters);
                    score += 200 * Convert.ToInt32(power);
                    hunters++;

                    //score += Convert.ToInt32(200 * Math.Pow((double) 2, (double) hunters++));
                }
                else
                {
                    score += _entityScoreDictionary[gameEvent];
                }

                //EARN A LIFE?
                if (score > _extraLifeThreshold && !earnedExtraLife)
                {
                    lives++;
                    lifeEvent = "+1 Life";
                    earnedExtraLife = true;
                }

                //DEAD?
                if (lives == 0)
                {
                    isDead = true;
                }

                //OUTPUT STATUS
                Console.WriteLine($"{_entityScoreDictionary.FirstOrDefault(x => x.Key == gameEvent).Key,-30} {score,-15} {lives,-15} {lifeEvent,-15}");


                //message to console if Drofsnar dies
                if (isDead)
                {
                    Console.WriteLine($"\n~~~ YOU DIED! ~~~\n");
                    break;
                }
                else
                {
                    Thread.Sleep(50);
                }
            }

            // OUTPUT FINAL SCORE
            Console.WriteLine();
            Console.WriteLine(new String('*', 55));
            Console.WriteLine($"\n{"Final Score:",-30} {score,-15} {lives,-15}\n");
            Console.WriteLine(new String('*', 55));
        }
    }
}
