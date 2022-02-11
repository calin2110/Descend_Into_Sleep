﻿using System;
using ConsoleApp12.Characters;
using ConsoleApp12.Utils;

namespace ConsoleApp12.Items.Weapons.LevelThree
{
    public class Xalatath: Weapon
    {
        public Xalatath() : base(10, 0,0)
        {
            SetLifeSteal(0.75);
            Description = "Strong life stealer which helps you not go insane";
            Name = "Xalatath";
            SetEffect();
        }

        public override string Effect(double damageDealt, Character caster, Character opponent)
        {
            var minimumSanityRestored = Convert.ToInt32(Math.Floor(damageDealt / 2));
            var maximumSanityRestored = Convert.ToInt32(Math.Floor(damageDealt));
            var sanityRestored = RandomHelper.GenerateRandomInInterval(minimumSanityRestored, maximumSanityRestored);
            caster.RestoreSanity(sanityRestored);
            var toStr = caster.GetName() + " has restored " + sanityRestored.ToString() + " of his sanity!\n";
            toStr += caster.GetName() + " is left with " + caster.GetSanity().ToString() + " sanity!\n";
            return toStr;
        }
    }
}