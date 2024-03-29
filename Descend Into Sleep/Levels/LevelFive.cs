﻿using System;
using System.Collections.Generic;
using ConsoleApp12.Characters;
using ConsoleApp12.Characters.MainCharacters;
using ConsoleApp12.Characters.SideCharacters.LevelFive;

namespace ConsoleApp12.Levels
{
    public class LevelFive : Level
    {
        public LevelFive(HumanPlayer humanPlayer) : base(5, humanPlayer, new Dictionary<Type, int>()
        {
            {typeof(BurningCitizen), 4}, {typeof(ExtinguishedFlame), 4}, {typeof(FlameOfTheSun), 4},
            {typeof(WorshipperOfTheSun), 4}
        }, new Queue<Character>(new[] {Icarus.ICARUS}))
        {
        }
    }
}