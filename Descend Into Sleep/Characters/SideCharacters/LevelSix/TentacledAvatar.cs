﻿using ConsoleApp12.Items;
using ConsoleApp12.Items.Weapons.LevelThree;

namespace ConsoleApp12.Characters.SideCharacters.LevelSix
{
    public class TentacledAvatar: PhysicalVoidSideEnemy
    {
        public TentacledAvatar() : base("Tentacled Avatar", 30, 40, new Xalatath(), new NoArmour(), 100)
        {
            
        }
    }
}