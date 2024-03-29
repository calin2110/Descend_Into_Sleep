﻿using ConsoleApp12.Items.ItemTypes;

namespace ConsoleApp12.Items.Armours.LevelFive
{
    public class EyeOfSauron : IArmour, IObtainable
    {
        public static readonly EyeOfSauron EYE_OF_SAURON = new EyeOfSauron();

        public string GetName()
        {
            return "Eye Of Sauron";
        }

        public string GetDescription()
        {
            return "Strong armour with no drawbacks";
        }

        public double GetDefenseValue()
        {
            return 200;
        }

        public double GetPrice()
        {
            return 5000;
        }

        public int AvailabilityLevel()
        {
            return 6;
        }

        private EyeOfSauron()
        {
        }
    }
}