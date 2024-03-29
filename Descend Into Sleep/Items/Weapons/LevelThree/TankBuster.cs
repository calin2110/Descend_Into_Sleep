﻿using System;
using ConsoleApp12.Characters;
using ConsoleApp12.Items.ItemTypes;

namespace ConsoleApp12.Items.Weapons.LevelThree
{
    public class TankBuster : IWeapon, IActive, IObtainable
    {
        public static readonly TankBuster TANK_BUSTER = new TankBuster();

        public double GetAttackValue()
        {
            return 4;
        }

        public string GetName()
        {
            return "Tank Buster";
        }

        public string GetDescription()
        {
            return "Each attack strikes twice";
        }

        public string Active(double damageDealt, Character caster, Character opponent)
        {
            caster.DealDirectDamage(opponent, damageDealt);
            var toStr = $"{caster.GetName()} did a double hit and dealt {Math.Round(damageDealt, 2)} damage!\n";
            toStr += $"{opponent.GetName()} is left with {Math.Round(opponent.GetHealthPoints(), 2)} health!\n";
            return toStr;
        }

        public double GetPrice()
        {
            return 1500;
        }

        public int AvailabilityLevel()
        {
            return 4;
        }

        private TankBuster()
        {
        }
    }
}