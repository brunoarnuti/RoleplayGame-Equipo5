using System;

namespace RolGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard mago1 = new Wizard(100, "pedro");
            Elf elfomagico = new Elf(100, "juan");

            Item espada1 = new Item("espada1", 50, 10);
            Item hechizo1 = new Item("hechizo1", 25, 0);

            mago1.AddSpell(hechizo1);
            elfomagico.AddItem(espada1);

            elfomagico.RecieveAttack(mago1.GetCharacterAttack());
            Console.WriteLine(elfomagico.Health.ToString());
        }
    }
}
