﻿using System;
using System.Collections.Generic;
using ConsoleApp12.Characters;
using ConsoleApp12.Exceptions;

namespace ConsoleApp12.Ability.SauronAbilities
{
    public class PowerOfTheEye: Ability
    {
        private readonly double SanityReduced;
        
        public PowerOfTheEye() : base("Power Of The Eye")
        {
            SanityReduced = 50;
        }

        public override string Cast(Character caster, Character opponent, Dictionary<int, List<Func<Character, Character, string>>> listOfTurns, int turnCounter)
        {
            opponent.ReduceSanity(SanityReduced);
            var opponentName = opponent.GetName();
            var toStr = opponentName + " has looked into the Eye of Sauron!\n";
            toStr += opponentName + "'s sanity is reduced by " + SanityReduced + "!\n";
            return toStr;
        }

        public override string Decast(Character caster, Character opponent)
        {
            throw new InexistentDecastException(Name);
        }
    }
}