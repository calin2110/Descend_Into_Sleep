using System;
using System.Collections.Generic;
using ConsoleApp12.Characters;
using ConsoleApp12.Exceptions;
using ConsoleApp12.Utils;

namespace ConsoleApp12.Ability.HumanAbilities.NeutralAbilities
{
    public class Focus: Ability
    {

        private readonly int MinimumSanityRestored;
        private readonly int MaximumSanityRestored;
        
        public Focus() : base("Focus")
        {
            ManaCost = 15;
            MinimumSanityRestored = 25;
            MaximumSanityRestored = 46;
            Description = $"You restore between {MinimumSanityRestored} and {MaximumSanityRestored} sanity back\n";
        }

        public override void ResetDescription()
        {
            Description = $"You restore between {MinimumSanityRestored} and {MaximumSanityRestored} sanity back\n";
        }
        
        public override string Cast(Character caster, Character opponent, Dictionary<int, List<Func<Character, Character, string>>> listOfTurns, int turnCounter)
        {
            var toStr = GetCastingString(caster);
            var sanityRestored = RandomHelper.GenerateRandomInInterval(MinimumSanityRestored, MaximumSanityRestored);
            caster.RestoreSanity(sanityRestored);
            toStr += $"{caster.GetName()} has restored {sanityRestored} sanity!\n";
            toStr += $"{caster.GetName()} now has {Math.Round(caster.GetSanity(), 2)} sanity!\n";
            return toStr;
        }

        public override string Decast(Character caster, Character opponent)
        {
            throw new InexistentDecastException(Name);
        }
    }
}