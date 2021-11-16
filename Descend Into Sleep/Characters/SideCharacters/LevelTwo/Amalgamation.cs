﻿using ConsoleApp12.Items;
using ConsoleApp12.Items.Armours.LevelOne;

namespace ConsoleApp12.Characters.SideCharacters.LevelTwo
{
    public class Amalgamation: SideEnemy
    {
        public Amalgamation() : base("Amalgamation", 1, 50, new NoWeapon(), new Cloth(), 50)
        {
            
        }        
    }
}