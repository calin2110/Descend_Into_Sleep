using System.Collections.Generic;
using ConsoleApp12.Items;
using ConsoleApp12.Items.Armours.LevelFive;

namespace ConsoleApp12.Characters.SideCharacters.LevelSix
{
    public class PossessedGoblin: PhysicalVoidSideEnemy
    {
        public PossessedGoblin() : base("Possessed Goblin", 10, 100, AllItems.NoWeapon, AllItems.NinjaYoroi, 300,
            new List<string>{"defend", "understand", "free", "purify"}, 0.5, 6)
        {
        }
    }
}