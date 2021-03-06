using System;
using System.Collections.Generic;
using ConsoleApp12.Characters;

namespace ConsoleApp12.Ability.HumanAbilities.NatureAbilities
{
    public class LivingRoots: Ability
    {

        private readonly int MinimumNumberOfImmuneTurns;
        
        public LivingRoots() : base("Living Roots")
        {
            ManaCost = 25;
            TurnsUntilDecast = 3;
            MinimumNumberOfImmuneTurns = 11;
            Description = $"You stun your opponent for {TurnsUntilDecast} Turns, but they become immune to stuns " +
                          $"for {MinimumNumberOfImmuneTurns - Level} Turns\n";

        }

        public override void ResetDescription()
        {
            Description = $"You stun your opponent for {TurnsUntilDecast} Turns, but they become immune to stuns " +
                          $"for {MinimumNumberOfImmuneTurns - Level} Turns\n";
        }
        
        public override string Cast(Character caster, Character opponent, Dictionary<int, List<Func<Character, Character, string>>> listOfTurns, int turnCounter)
        {
            var toStr = GetCastingString(caster);
            var numbersOfTurnsImmune = MinimumNumberOfImmuneTurns - Level;
            toStr += $"{opponent.GetName()} was stunned for {TurnsUntilDecast} turns!\n";
            opponent.Stun();
            AddToDecastingQueue(caster, opponent, listOfTurns, turnCounter);

            Func<Character, Character, string> secondDecastFunction = delegate(Character caster, Character opponent){
                return SecondDecast(caster, opponent);
            };
            if (listOfTurns.ContainsKey(turnCounter + numbersOfTurnsImmune))
                listOfTurns[turnCounter + numbersOfTurnsImmune].Add(secondDecastFunction);
            else {
                listOfTurns[turnCounter + numbersOfTurnsImmune] = new List<Func<Character, Character, string>>();
                listOfTurns[turnCounter + numbersOfTurnsImmune].Add(secondDecastFunction);
            }

            return toStr;
        }

        public override string Decast(Character caster, Character opponent)
        {
            var opponentName = opponent.GetName();
            opponent.Unstun();
            opponent.SetStunResistant(true);
            var toStr = $"{opponentName} is no longer stunned!\n";
            toStr += $"{opponentName} is now stun resistant!\n";
            return toStr;
        }

        public string SecondDecast(Character caster, Character opponent)
        {
            var opponentName = opponent.GetName();
            opponent.SetStunResistant(false);
            var toStr = $"{opponentName} is no longer stun resistant!\n";
            return toStr;
        }
    }
}