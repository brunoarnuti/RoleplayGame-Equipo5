using System;
using System.Collections.Generic;

namespace RolGame
{
    public class SpellBook : ComposedItem
    {

        public SpellBook(string name, int attack, int defense) : base(name, attack, defense)
        {
        }

        public override void AddComponent(Item spell)
        {
            //Verifica si el item a agregar es un hechizo, caso contrario no lo agregara.
            if(spell.GetType() == typeof(Spell))
            {
                this.components.Add(spell);
            }
        }
    }
}
