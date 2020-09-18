using System;
using System.Collections.Generic;

namespace RolGame
{
    public class Elf
    {
        /*
        Esta clase fue creada para agrupar toda la funcionalidad comun que poseen los distintos tipos de personajes del juego, promoviendo la reusabilidad y
        evitando la repeticion innecesaria de codigo.

        Esta clase cumple con el SRP, ya que tiene una unica razon de cambio. (La de cambiar si cambia la forma en la que se desea modelar los objetos personaje)
        Tambien hay que agregar que la clase es experta en todas las tareas que realiza, porque ella es la que tiene toda la informacion necesaria para llevarlas a cabo.

        Colabora unicamente con la clase Item, ya que posee una lista de objetos Item.
        */
        private int initialHealth;
        //Salud
        private int health;
        //Ataque
        private int attack;
        //Defensa
        private int defense;
        private string name;
        //Lista de items del personaje
        private List<Item> items;
        private bool isDead;

        public int Health 
        {
            get
            {
                return this.health;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public bool IsDead
        {
            get
            {
                return this.isDead;
            }
        }

        public List<Item> ItemsList
        {
            get
            {
                return this.items;
            }
        }


        public Elf(int health, string name)
        {   
            //Compruebo que los parametros dados son validos
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
            //Recorro la lista de items para conseguir el ataque total 
            int result = 0;
            foreach (Item item in this.items)
            {
                result = result + item.GetItemAttack();
            }
            return result;
        }

        public int GetCharacterDefense()
        {
            //Recorro la lista de items para conseguir la defensa total del personaje
            int result = 0;
            foreach (Item item in this.items)
            {
                result = result + item.GetItemDefense();
            }
            return result;
        }

        public void AddItem(Item item)
        {
            //Agrego un item dado y actualizo los stats del personaje
            this.items.Add(item);
            this.UpdateCharacterStats();
        }
        public void RemoveItem(Item item)
        {
            //Retiro un item dado y actualizo los stats del personaje
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

        public void RecieveAttack(int dmg)
        {
            //Si el enemigo no esta muerto lo ataca
            if(this.isDead != true)
            {
                //Si el ataque no matara al enemigo, se realiza el calculo de cuanta vida le queda   
                if((this.GetCharacterDefense() + this.Health) - dmg > 0)
                {
                    //Si la defensa del enemigo es menor que el ataque, le quita la cantidad correspondiente. Caso contrario, lo "esquiva".
                    if(this.GetCharacterDefense() < dmg)
                    {
                        this.health = (this.Health + this.GetCharacterDefense()) - dmg;
                    }
                }
                //El ataque efectivamente mata al enemigo
                else
                {
                    this.health = 0;
                    this.isDead = true;
                }
            }     
        }

        //Metodo Auxiliar
         private void UpdateCharacterStats()
        {
            this.attack = this.GetCharacterAttack();
            this.defense = this.GetCharacterDefense();
        }
    }
}
