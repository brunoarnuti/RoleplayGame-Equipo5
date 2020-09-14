using System;

namespace RolGame
{
    public class Item
    {
        private int itemAttack;
        private int itemDefense;
        private string name;

        public Item(string name, int attack, int defense)
        {
          
            if(!string.IsNullOrEmpty(name))
            {
                this.name = name;
            }
            else
            {
                throw new Exception("Invalid name");
            }

            if(attack >= 0)
            {
                this.itemAttack = attack;
            }
            else
            {
                this.itemAttack = 0;
            }

            if(defense >= 0)
            {
                this.itemDefense = defense;
            }
            else
            {
                this.itemDefense = 0;
            }    
        }

        public virtual int GetItemAttack()
        {
            return this.itemAttack;
        }

        public virtual int GetItemDefense()
        {
            return this.itemDefense;
        }

    }
}
