﻿using ConsoleApp12.Characters;
using ConsoleApp12.Characters.MainCharacters;
using ConsoleApp12.Exceptions;
using ConsoleApp12.Items.ItemTypes;
using ConsoleApp12.Items.Potions;

namespace ConsoleApp12.Items.Weapons.LevelThree
{
    public class LanguageHacker : IWeapon, IActive, IObtainable
    {
        public static readonly LanguageHacker LANGUAGE_HACKER = new LanguageHacker();

        public double GetAttackValue()
        {
            return 10;
        }

        public string GetName()
        {
            return "Language Hacker";
        }

        public string GetDescription()
        {
            return "After each attack, you gain a Grain of Salt potion";
        }

        public string Active(double damageDealt, Character caster, Character opponent)
        {
            var toStr = "";
            try
            {
                if (caster is HumanPlayer humanPlayer)
                    humanPlayer.PickUp(GrainOfSalt.GRAIN_OF_SALT);
                toStr = "Grain of Salt was added to your inventory!\n";
            }
            catch (FullInventoryException)
            {
                toStr = "Grain of Salt was not added to your inventory because inventory was full!\n";
            }

            return toStr;
        }

        public double GetPrice()
        {
            return 1800;
        }

        public int AvailabilityLevel()
        {
            return 4;
        }

        private LanguageHacker()
        {
        }
    }
}