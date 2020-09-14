using System;
using System.Collections.Generic;

namespace RolGame
{
    public class Character
    {
        private int initialHealth;
        private int health;
        private int attack;
        private int defense;
        private string name;
        private List<Item> items;
        private bool isDead;

        public int Health 
        {
            get
            {
                return this.health;
            }
        }


        public Character(int health, string name)
        {
            if(health > 0)
            {
                this.health = health;
                this.initialHealth = health;
            }
            else
            {
                throw new Exception("Invalid health");
            }

            if(!string.IsNullOrEmpty(name))
            {
                this.name = name;
            }
            else
            {
                throw new Exception("Invalid name");
            }

            this.items = new List<Item>();
            this.isDead = false;
        }


        public int GetCharacterAttack()
        {
            int result = 0;
            foreach (Item item in this.items)
            {
                result = result + item.GetItemAttack();
            }
            return result;
        }

        public int GetCharacterDefense()
        {
            int result = 0;
            foreach (Item item in this.items)
            {
                result = result + item.GetItemDefense();
            }
            return result;
        }

        public void AddItem(Item item)
        {
            this.items.Add(item);
            this.UpdateCharacterStats();
        }
        public void RemoveItem(Item item)
        {
            if(this.items.Contains(item))
            {
                this.items.Remove(item);
                this.UpdateCharacterStats();
            }
        }

        public void Heal()
        {
            this.health = initialHealth;
            this.isDead = false;
        }

        public void Attack(Character enemy)
        {
            if(enemy.isDead != true)
            {
                if((enemy.GetCharacterDefense() + enemy.Health) - this.GetCharacterAttack() > 0)
                {
                    enemy.health = (enemy.Health + enemy.GetCharacterDefense()) - this.GetCharacterAttack();
                }
                else
                {
                    enemy.health = 0;
                    enemy.isDead = true;
                }
            }     
        }

         private void UpdateCharacterStats()
        {
            this.attack = this.GetCharacterAttack();
            this.defense = this.GetCharacterDefense();
        }
    }
}
