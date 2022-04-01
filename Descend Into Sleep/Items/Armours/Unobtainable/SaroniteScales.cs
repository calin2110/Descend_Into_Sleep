﻿using System;

namespace ConsoleApp12.Items.Armours.Unobtainable
{
    public class SaroniteScales: IArmour, IReflector, IHealth
    {
        private bool Broken;
        private double HealthPoints;
        private double DefenseValue;
        private string Name;
        
        public SaroniteScales()
        {
            HealthPoints = 100;
            Name = "Saronite Scales";
            Broken = false;
            DefenseValue = 100;
        }

        public string TakeHit(double attackValue)
        {
            HealthPoints -= attackValue;
            if (HealthPoints <= 0)
            {
                DefenseValue = 0;
                Name = "Broken Saronite Scales";
                Broken = true;
            }

            var toStr = $"{Name} have taken {attackValue} damage!\n";
            toStr += $"{Name} are left with {Math.Round(HealthPoints, 2)} health!\n";
            return toStr;
        }

        public bool IsBroken()
        {
            return Broken;
        }
        
        public double GetDefenseValue()
        {
            return DefenseValue;
        }

        public double GetHealth()
        {
            return HealthPoints;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetDescription()
        {
            return "Scales of Saron";
        }
    }
}