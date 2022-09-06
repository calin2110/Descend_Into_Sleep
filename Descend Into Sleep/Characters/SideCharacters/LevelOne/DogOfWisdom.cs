﻿using System.Collections.Generic;
using ConsoleApp12.Items.Armours.LevelOne;
using ConsoleApp12.Items.Weapons.LevelOne;

namespace ConsoleApp12.Characters.SideCharacters.LevelOne
{
    public class DogOfWisdom : SideEnemy
    {
        public DogOfWisdom() : base("Dog of Wisdom", 3, 3, ToyKnife.TOY_KNIFE, Bandage.BANDAGE,
            25, new List<string> {"pet", "run at", "love"}, 0.99, 1)
        {
        }
    }
}