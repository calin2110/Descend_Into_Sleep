﻿using System.Collections.Generic;
using ConsoleApp12.Items.Armours.LevelOne;
using ConsoleApp12.Items.Weapons.LevelSix;

namespace ConsoleApp12.Characters.SideCharacters.LevelSeven
{
    public class RemnantOfIcarus : FireSideEnemy
    {
        public RemnantOfIcarus() : base("Remnant of Icarus", 75, 50, Dreams.DREAMS, Bandage.BANDAGE, 100,
            new List<string> {"extinguish", "heal", "explain yourself", "enlighten"}, 0.5, 7)
        {
        }
    }
}