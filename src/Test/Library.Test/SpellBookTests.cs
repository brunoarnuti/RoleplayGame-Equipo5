using System;
using NUnit.Framework;
using RolGame;

namespace Test.Library
{


    public class SpellBookTests
    {
        [Test]
        public void OnlySpellsShouldBeAdded()
        {
            SpellBook book1 = new SpellBook("THEBOOK", 10, 10);
            SpellBook book2 = new SpellBook("THEBOOK", 10, 10);
            Spell spell1 = new Spell("thespell", 10, 10);
            Item notASpell = new Item("ImNotASpell", 1, 1);

            book1.AddComponent(spell1);
            book2.AddComponent(notASpell);

            Assert.AreEqual(spell1, book1.Components[0]);
            Assert.IsEmpty(book2.Components);
        }
    
    }
}