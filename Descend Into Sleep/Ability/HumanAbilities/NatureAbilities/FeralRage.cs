using System;
using System.Collections.Generic;
using System.Data;
using ConsoleApp12.Characters;
using ConsoleApp12.Exceptions;

namespace ConsoleApp12.Ability.HumanAbilities.NatureAbilities
{
    public class FeralRage: Ability
    {
        private Queue<double> GainedArmourQueue;

        public FeralRage() : base("Feral Rage")
        {
            ManaCost = 25;
            GainedArmourQueue = new Queue<double>();
            ScalingPerLevel = 0.2;
            TurnsUntilDecast = 3;
            Description = $"You gain {ScalingPerLevel * Level} * AttackValue armour\n";
        }

        public override void ResetDescription()
        {
            Description = $"You gain {ScalingPerLevel * Level} * AttackValue armour\n";
        }
        
        public override string Cast(Character caster, Character opponent, Dictionary<int, List<Func<Character, Character, string>>> listOfTurns, int turnCounter)
        {
            var toStr = GetCastingString(caster);
            var attackDamage = caster.GetAttackValue();
            var gainedArmour = ScalingPerLevel * Level * attackDamage;
            GainedArmourQueue.Enqueue(gainedArmour);
            caster.IncreaseDefenseValue(gainedArmour);
            toStr += $"{caster.GetName()} has gained {Math.Round(gainedArmour, 2)} armour for {TurnsUntilDecast} turns!\n";
            toStr += $"{caster.GetName()} now has {Math.Round(caster.GetDefenseValue(), 2)} defense!\n";
            AddToDecastingQueue(caster, opponent, listOfTurns, turnCounter);
            return toStr;
        }

        public override string Decast(Character caster, Character opponent)
        {
            if (GainedArmourQueue.Count == 0)
                throw new EmptyQueueException("Gained Armour");
            var gainedArmour = GainedArmourQueue.Dequeue();
            caster.IncreaseDefenseValue(-gainedArmour);
            var toStr = $"{caster.GetName()}'s armour was brought back to normal!\n";
            toStr += $"{caster.GetName()} now has {Math.Round(caster.GetDefenseValue(), 2)} defense!\n";
            return toStr;
        }
    }
}