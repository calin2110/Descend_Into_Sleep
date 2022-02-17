﻿using System;
using System.Collections.Generic;
using ConsoleApp12.Characters;

namespace ConsoleApp12.Ability.HumanAbilities.NeutralAbilities
{
    public class Strengthen: Ability
    {
        public Strengthen() : base("Strengthen")
        {
            Description = "Your attack and defense are increased for 3 turns\n";
            ManaCost = 15;
            TurnsUntilDecast = 3;
            ScalingPerLevel = 2.5;
        }

        public override string Cast(Character caster, Character opponent, Dictionary<int, List<Func<Character, Character, string>>> listOfTurns, int turnCounter)
        {
            var toStr = GetCastingString(caster);
            var valueIncreased = Math.Pow(ScalingPerLevel, Level);
            caster.IncreaseAttackValue(valueIncreased);
            caster.IncreaseDefenseValue(valueIncreased);
            toStr += $"{caster.GetName()}'s attack and defense values were increased by {Math.Round(valueIncreased, 2)}!\n";
            toStr += $"{caster.GetName()} now has {Math.Round(caster.GetAttackValue(), 2)} attack and " +
                     $"{Math.Round(caster.GetDefenseValue(), 2)} defense!\n";
            AddToDecastingQueue(caster, opponent, listOfTurns, turnCounter);
            return toStr;
        }

        public override string Decast(Character caster, Character opponent)
        {
            var valueIncreased = Math.Pow(ScalingPerLevel, Level);
            caster.IncreaseAttackValue(-valueIncreased);
            caster.IncreaseDefenseValue(-valueIncreased);
            var toStr = $"{caster.GetName()}'s attack and defense values were decreased back by {Math.Round(valueIncreased, 2)}!\n";
            toStr += $"{caster.GetName()} now has {Math.Round(caster.GetAttackValue(), 2)} attack and " +
                     $"{Math.Round(caster.GetDefenseValue(), 2)} defense!\n";
            return toStr;
        }
    }
}