using System;
using System.Collections.Generic;

namespace RolGame
{
    public class SpellBook : ComposedItem
    {
        public SpellBook(string name, int attack, int defense) : base(name, attack, defense)
        {
        }
    }
}
