using System.Collections.Generic;
using ConsoleApp12.Items;
using ConsoleApp12.Items.Armours.LevelThree;

namespace ConsoleApp12.Characters.SideCharacters.LevelThree
{
    public class VoidPossessedAmalgamation: VoidSideEnemy
    {
        public VoidPossessedAmalgamation() : base("Void Possessed Amalgamation", 15, 50, AllItems.NoWeapon,
            AllItems.BootsOfDodge, 50, new List<string>{"feed", "caress", "purify"},
            0.75, 3)
        {
        }
    }
}