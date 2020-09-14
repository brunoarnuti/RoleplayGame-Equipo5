using System;
using System.Collections.Generic;

namespace RolGame
{
    /*
    Esta clase se creo con el objetivo de representar items que pueden agregar a otros items, de esta forma modificando su poder.
    La clase solo colabora con su clase padre (Item) ya que le delega muchas de sus funciones.
    A su vez, por ahora, es la clase padre de SpellBook, ya que los objetos SpellBook son objetos compuestos.
    Esta clase cumple con el SRP, ya que solo cambiara si se quiere cambiar la forma en la que se representan los items compuestos.

    No tenia sentido agregar una lista de componentes a la clase (Item), ya que en seria obsoleta en caso de que se trate de un item simple.
    Esta clase sobre-escribe un par de metodos, es un ejemplo del patron GRASP de Polimorfismo.
    La manera en la que se lleva a cabo el metodo (GetItemAttack y GetItemDefense) es diferente dependiendo de si es un item compuesto o no
    por ese mismo motivo es conveniente usar una operacion polimorfica.
    

    Tambien es importante descatar que el modelo que involucra a la clase Item, ComposedItem, SpellBook y Spell fue influenciado por el patron Composite.
    La imagen de el modelado de este mismo patron esta en una imagen en la carpeta Program.
    */
    public class ComposedItem : Item
    {
        //Lista de items componentes
        protected List<Item> components;
        //Variable auxiliar
        private int baseAttack;
        //Variable auxiliar
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

        public virtual void AddComponent(Item component)
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
