using System;
using System.Collections.Generic;

namespace RolGame
{
    public class ComposedItem : Item
    {
        private List<Item> components;
        private int baseAttack;
        private int baseDefense;

        public List<Item> Components
        {
            get
            {
                return this.components;
            }
        }
 

        public ComposedItem(string name, int attack, int defense) : base(name, attack, defense)
        {
            this.components = new List<Item>();
            this.baseAttack = attack;
            this.baseDefense = defense;
        }

        public override int GetItemAttack()
        {
            int result = baseAttack;
            foreach (Item component in components)
            {
                result = result + component.GetItemAttack();
            }
            return result;
        }

        public override int GetItemDefense()
        {
            int result = baseDefense;
            foreach (Item component in components)
            {
                result = result + component.GetItemDefense();
            }
            return result;
        }

        public void AddComponent(Item component)
        {
            this.components.Add(component);
            this.UpdateComposedItemStats();
        }
        public void RemoveComponent(Item component)
        {
            if(this.components.Contains(component))
            {
                this.components.Remove(component);
                this.UpdateComposedItemStats();
            }
        }

        private void UpdateComposedItemStats()
        {
            this.itemAttack = this.GetItemAttack();
            this.itemDefense = this.GetItemDefense();
        }
    }
}
