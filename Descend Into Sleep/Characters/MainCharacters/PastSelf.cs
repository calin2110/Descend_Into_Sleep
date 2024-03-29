﻿using System.Collections.Generic;
using ConsoleApp12.Ability.PastSelfAbilities;
using ConsoleApp12.Items.ItemTypes;

namespace ConsoleApp12.Characters.MainCharacters
{
    public class PastSelf : Character
    {
        public PastSelf(string name, double innateAttack, double innateDefense, IWeapon weapon, IArmour armour,
            double health,
            string description, int level) : base(name, innateAttack, innateDefense, weapon, armour, health,
            new List<string>(), 0, 7, description)
        {
            AddAbility(new Condemn(level));
            AddAbility(new Judge(level));
        }

        public override double GetOddsOfAttacking()
        {
            return 0.60;
        }
    }
}