﻿using System;
using System.Collections.Generic;
using ConsoleApp12.Characters;
using ConsoleApp12.Utils;

namespace ConsoleApp12.CombatSystem
{
    public abstract class Combat
    {
        protected readonly ListOfTurns ListOfTurns;
        protected int TurnCounter;
        protected Character Player;

        protected Combat(Character player)
        {
            Player = player;
            ListOfTurns = new ListOfTurns();
            TurnCounter = 0;
        }

        public bool CheckStun()
        {
            if (Player.IsStunned())
            {
                var toStr = $"{Player.GetName()}'s turn was skipped because he was stunned!\n";
                Console.WriteLine(toStr);
                TurnCounter++;
                return true;
            }

            return false;
        }

        public bool CheckUndos(Character secondCharacter)
        {
            var listOfActions = ListOfTurns.Get(TurnCounter);
            foreach (var action in listOfActions)
            {
                var toStr = action(Player, secondCharacter);
                Console.WriteLine(toStr);
            }

            ListOfTurns.Remove(TurnCounter);
            if (Player.GetHealthPoints() <= 0)
                return false;
            return true;
        }

        public void FightEnd(Character secondCharacter)
        {
            var dotEffects = Player.GetDotEffects();
            if (dotEffects.Count != 0)
                Player.ClearDotEffects();
            var remainingActions = ListOfTurns.GetAll();
            foreach (var action in remainingActions)
            {
                var toStr = action(Player, secondCharacter);
                Console.WriteLine(toStr);
            }

            ListOfTurns.Clear();
        }

        public bool DotCheck(Character secondCharacter)
        {
            var dotEffects = Player.GetDotEffects();
            var toStr = "";
            if (dotEffects.Count != 0)
            {
                int index = 0;
                while (index < dotEffects.Count)
                {
                    Player.ReduceHealthPoints(dotEffects[index].DamagePerTurn);
                    toStr +=
                        $"{Player.GetName()} has taken {Math.Round(dotEffects[index].DamagePerTurn, 2)} damage over time!\n";
                    var leftTurns = dotEffects[index].NumberOfTurns;
                    Player.DecreaseDotEffect(index);
                    if (leftTurns != 1)
                        index++;
                }

                toStr += $"{Player.GetName()} is left with {Math.Round(Player.GetHealthPoints(), 2)} health points!\n";
            }

            Console.WriteLine(toStr);
            if (Player.GetHealthPoints() <= 0)
                return false;
            return true;
        }

        public abstract void CombatTurn(Character secondCharacter);
    }
}