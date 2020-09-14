using System;

namespace RolGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creo los items normales
            Item elfStone = new Item("Elf Stone", 10, 0);
            Item armorOfErebor = new Item("Armor of Erebor", 0, 20);
            Item aGreyCloak = new Item("A Grey Cloak", 0, 2);
        
            //Creo algunos items compuestos
            SpellBook bookOfEldacar = new SpellBook("Book of Eldacar", 3, 1);
            ComposedItem bladeOfGondolin = new ComposedItem("Blade of Gondolin", 30, 3);
            
            //Creo algunos hechizos
            Spell darkKnowledge = new Spell("Dark Knowledge", 45, 30);
            Spell gondorianFire = new Spell("Gondorian Fire", 5, 0);

            //Agrego los hechizos a los objetos
            bookOfEldacar.AddComponent(darkKnowledge);
            bladeOfGondolin.AddComponent(gondorianFire);

            //Personajes
            Elf Toel_the_elf = new Elf(100, "Toel");
            Wizard Gondor_the_warlock = new Wizard(100, "Gondor");

            //Le agrego los items a los personajes
            Toel_the_elf.AddItem(bladeOfGondolin);
            Toel_the_elf.AddItem(armorOfErebor);
            Toel_the_elf.AddItem(elfStone);
            Gondor_the_warlock.AddItem(bookOfEldacar);
            Gondor_the_warlock.AddItem(aGreyCloak);

            //Los personajes se atacan
            /*
            No pareceria correcto representar las acciones que se quieran hacer en el juego con una clase (el contenido especifico de los Console.WriteLine).
            Ya que estos escenarios de batalla se generaran a partir de lo que el usuario desee, y de lo que el usuario quiera dramatizar o decir
            Por eso, si es correcto representar las funciones que modelan los comportamientos como (attack), pero no los distintos (Console.WriteLine) que se quieran usar o su contenido
            */


            //Ejemplo de juego
            Gondor_the_warlock.Attack(Toel_the_elf);
            Console.WriteLine($"El personaje {Gondor_the_warlock.Name} ha atacado a {Toel_the_elf.Name} con su {bookOfEldacar.Name} y le ha infinjido {Gondor_the_warlock.GetCharacterAttack()-Toel_the_elf.GetCharacterDefense()}");
            Console.WriteLine($"Como resultado {Toel_the_elf.Name} quedo con {Toel_the_elf.Health.ToString()}");
            Toel_the_elf.Heal();
            Console.WriteLine($"{Toel_the_elf.Name} se curo, y ahora tiene {Toel_the_elf.Health.ToString()}");
            Toel_the_elf.Attack(Gondor_the_warlock);
            Console.WriteLine($"{Toel_the_elf.Name} devolvio el ataque a {Gondor_the_warlock.Name} y lo dejo con {Gondor_the_warlock.Health}");
            Gondor_the_warlock.RemoveItem(bookOfEldacar);
            Console.WriteLine($"{Gondor_the_warlock.Name} perdio su libro {bookOfEldacar.Name} y paso de tener {Gondor_the_warlock.GetCharacterAttack()+bookOfEldacar.GetItemAttack()} de ataque a tener {Gondor_the_warlock.GetCharacterAttack()}");
            while(!Gondor_the_warlock.IsDead)
            {
                Toel_the_elf.Attack(Gondor_the_warlock);
                Console.WriteLine($"{Toel_the_elf.Name} vuelve a atacar ahora indefenso {Gondor_the_warlock.Name} y lo deja con {Gondor_the_warlock.Health} puntos de vida");
            }
            Console.WriteLine($"{Gondor_the_warlock.Name} ha muerto");
        }
    }
}
