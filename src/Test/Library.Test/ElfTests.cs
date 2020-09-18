using System;
using NUnit.Framework;
using RolGame;

namespace Test.Library
{


    public class ElfTests
    {
        private Elf testingElf = new Elf(100, "testingChar");
        private Elf testingElf2 = new Elf(100, "testingChar2");
        private Elf testingElf3 = new Elf(100, "testingChar3");
        private Item testingItem = new Item("testingItem", 20, 10);
        private Item testingItem2 = new Item("testingItem2", 30, 25);

        [Test]
        public void InvalidNameShouldThrowException()
        {
            Assert.Throws<Exception>(() => new Elf(100, ""));
            Assert.Throws<Exception>(() => new Elf(100, null));
        }

        [Test]
        public void InvalidHealthShouldThrowException()
        {
            Assert.Throws<Exception>(() => new Elf(-10, "Name1"));
        }

        [Test]
        public void AddItem()
        {
            testingElf.AddItem(testingItem);
            string expectedItemName = "testingItem";
            
            Assert.AreEqual(expectedItemName, testingElf.ItemsList[0].Name);
        }
        [Test]
        public void AddItemShouldModifyElfStats()
        {
            int expectedElfAttack = 30;
            int expectedElfDefense = 25;

            testingElf2.AddItem(testingItem2);

            Assert.AreEqual(expectedElfAttack, testingElf2.GetCharacterAttack());
            Assert.AreEqual(expectedElfDefense, testingElf2.GetCharacterDefense());
        }
        [Test]
        public void RemoveItem()
        {
            testingElf.RemoveItem(testingItem);            
            Assert.IsEmpty(testingElf.ItemsList);
        }
        [Test]
        public void RemoveItemShouldModifyElfStats()
        {
            int expectedElfAttack = 0;
            int expectedElfDefense = 0;

            testingElf2.RemoveItem(testingItem2);

            Assert.AreEqual(expectedElfAttack, testingElf2.GetCharacterAttack());
            Assert.AreEqual(expectedElfDefense, testingElf2.GetCharacterDefense());
        }

        [Test]
        public void GetElfStats()
        {
            testingElf3.AddItem(testingItem);
            testingElf3.AddItem(testingItem2);
            testingElf3.RemoveItem(testingItem);
            int expectedElfAttack = 30;
            int expectedElfDefense = 25;
            Assert.AreEqual(expectedElfAttack, testingElf3.GetCharacterAttack());
            Assert.AreEqual(expectedElfDefense, testingElf3.GetCharacterDefense());
        }
        [Test]
        public void HealShouldRestoreInitialHealth()
        {
            Elf damagedElf = new Elf(100, "damagedChar");
            damagedElf.RecieveAttack(testingElf.GetCharacterAttack());

            int expected = 100;
            damagedElf.Heal();
            
            Assert.AreEqual(expected, damagedElf.Health);
            Assert.False(damagedElf.IsDead);
        }
        [Test]
        public void RecieveAttackShouldNotDamageIfDefenseIsGreater()
        {
            testingElf2.RecieveAttack(testingElf.GetCharacterAttack());

            int expected = 100;
            
            Assert.AreEqual(expected, testingElf2.Health);
        }
        [Test]
        public void RecieveAttackShouldDamageIfEnemyDefenseIsNotGreater()
        {
            Elf attacker1 = new Elf(100, "attacker1");
            Elf attacker2 = new Elf(100, "attacker2");
            attacker1.AddItem(testingItem2);
            attacker2.AddItem(testingItem);

            attacker2.RecieveAttack(attacker1.GetCharacterAttack());

            int expected = 80;
            
            Assert.AreEqual(expected, attacker2.Health);
        }
        [Test]
        public void EnoughAttackShouldKill()
        {
            Elf attacker1 = new Elf(100, "attacker1");
            Elf attacker2 = new Elf(100, "attacker2");
            Item theAdminsSword = new Item("The admin sword", 1000, 1000);
            attacker1.AddItem(theAdminsSword);
            attacker2.AddItem(testingItem);

            attacker2.RecieveAttack(attacker1.GetCharacterAttack());

            int expected = 0;
            
            Assert.AreEqual(expected, attacker2.Health);
            Assert.True(attacker2.IsDead);
        }
    }


}