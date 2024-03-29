﻿using System.Collections.Generic;
using ConsoleApp12.Items.Armours.LevelFive;
using ConsoleApp12.Items.Weapons.LevelFive;

namespace ConsoleApp12.Characters.SideCharacters.LevelFive
{
    public class ExtinguishedFlame : FireSideEnemy
    {
        public ExtinguishedFlame() : base("Extinguished Flame", 15, 50, InfinityEdge.INFINITY_EDGE,
            NinjaYoroi.NINJA_YOROI, 100,
            new List<string> {"gather wood", "gather coal", "make a firepit", "set ablaze"}, 0.6, 5)
        {
        }
    }
}