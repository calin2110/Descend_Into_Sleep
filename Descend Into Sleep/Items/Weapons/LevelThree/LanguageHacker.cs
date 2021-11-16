﻿using System;
using ConsoleApp12.Characters;
using ConsoleApp12.Characters.MainCharacters;
using ConsoleApp12.Exceptions;
using ConsoleApp12.Items.Potions;

namespace ConsoleApp12.Items.Weapons.LevelThree
{
    public class LanguageHacker: Weapon
    {
        public LanguageHacker() : base(10, 0)
        {
            SetEffect();
            Name = "Language Hacker";
            Description = "After each attack, you gain a Grain of Salt potion";
        }

        public override string Effect(double damageDealt, Character caster, Character opponent)
        {
            var toStr = "";
            try
            {
                if (caster is HumanPlayer humanPlayer)
                    humanPlayer.PickUp(new GrainOfSalt());
                toStr = "Grain of Salt was added to your inventory!\n";
            }
            catch(FullInventoryException)
            {
                toStr = "Grain of Salt was not added to your inventory because inventory was full!\n";
            }
            return toStr;
        }
    }
}