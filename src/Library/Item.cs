using System;

namespace RolGame
{
    /*
    Esta clase representa a los items del juego. Fue creada para agrupar todo el estado y el comportamiento comun a todos los objetos Item.
    Es la clase padre de todos los diferentes tipos de items del juego.
    Gracias a esta clase se pueden ejecutar operaciones polimorficas en las claes hijas. Como ocurre en los metodos (GetItemAttack) y (GetItemDefense)

    Tiene solo una razon de cambio, por lo que cumple con el SRP. 
    Si se quiere modificar o crear un tipo de Item diferente, lo unico que se tiene que hacer es heredar de esta clase, por lo que no es necesario modificarla directamente.
    */
    public class Item
    {
        protected int itemAttack;
        protected int itemDefense;
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }
        }

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