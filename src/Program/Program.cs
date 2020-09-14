using System;

namespace RolGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Elf hi = new Elf(100, "hon");
            Wizard his = new Wizard(100, "hon");
            SpellBook book = new SpellBook("book", 0, 0);
            Spell spell = new Spell("poderoso", 10, 5);
            Spell spell2 = new Spell("poderoso2", 10, 5);
            book.AddPiece(spell);
            book.AddPiece(spell2);
            hi.AddItem(book);
            his.AddItem(book);
            Console.WriteLine(hi.GetCharacterAttack());
            Console.WriteLine(hi.GetCharacterDefense());
            Console.WriteLine(his.GetCharacterAttack());
            Console.WriteLine(his.GetCharacterDefense());
            his.Attack(hi);
            Console.WriteLine(hi.Health);





        }
    }
}
