using System;
using NUnit.Framework;
using RolGame;

namespace Test.Library
{


    public class CharacterTests
    {
        private Character testingCharacter = new Character(100, "testingChar");
        private Character testingCharacter2 = new Character(100, "testingChar2");
        private Character testingCharacter3 = new Character(100, "testingChar3");
        private Item testingItem = new Item("testingItem", 20, 10);
        private Item testingItem2 = new Item("testingItem2", 30, 25);

        [Test]
        public void InvalidNameShouldThrowException()
        {
            Assert.Throws<Exception>(() => new Character(100, ""));
            Assert.Throws<Exception>(() => new Character(100, null));
        }

        [Test]
        public void InvalidHealthShouldThrowException()
        {
            Assert.Throws<Exception>(() => new Character(-10, "Name1"));
        }

        [Test]
        public void AddItem()
        {
            testingCharacter.AddItem(testingItem);
            string expectedItemName = "testingItem";
            
            Assert.AreEqual(expectedItemName, testingCharacter.ItemsList[0].Name);
        }
        [Test]
        public void AddItemShouldModifyCharacterStats()
        {
            int expectedCharacterAttack = 30;
            int expectedCharacterDefense = 25;

            testingCharacter2.AddItem(testingItem2);

            Assert.AreEqual(expectedCharacterAttack, testingCharacter2.GetCharacterAttack());
            Assert.AreEqual(expectedCharacterDefense, testingCharacter2.GetCharacterDefense());
        }
        [Test]
        public void RemoveItem()
        {
            testingCharacter.RemoveItem(testingItem);            
            Assert.IsEmpty(testingCharacter.ItemsList);
        }
        [Test]
        public void RemoveItemShouldModifyCharacterStats()
        {
            int expectedCharacterAttack = 0;
            int expectedCharacterDefense = 0;

            testingCharacter2.RemoveItem(testingItem2);

            Assert.AreEqual(expectedCharacterAttack, testingCharacter2.GetCharacterAttack());
            Assert.AreEqual(expectedCharacterDefense, testingCharacter2.GetCharacterDefense());
        }

        [Test]
        public void GetCharacterStats()
        {
            testingCharacter3.AddItem(testingItem);
            testingCharacter3.AddItem(testingItem2);
            testingCharacter3.RemoveItem(testingItem);
            int expectedCharacterAttack = 30;
            int expectedCharacterDefense = 25;
            Assert.AreEqual(expectedCharacterAttack, testingCharacter3.GetCharacterAttack());
            Assert.AreEqual(expectedCharacterDefense, testingCharacter3.GetCharacterDefense());
        }
        [Test]
        public void HealShouldRestoreInitialHealth()
        {
            Character damagedCharacter = new Character(100, "damagedChar");
            testingCharacter.Attack(damagedCharacter);

            int expected = 100;
            damagedCharacter.Heal();
            
            Assert.AreEqual(expected, damagedCharacter.Health);
            Assert.False(damagedCharacter.IsDead);
        }
        [Test]
        public void AttackShouldNotDamageIfEnemyDefenseIsGreater()
        {
            testingCharacter.Attack(testingCharacter2);

            int expected = 100;
            
            Assert.AreEqual(expected, testingCharacter2.Health);
        }
        [Test]
        public void AttackShouldDamageIfEnemyDefenseIsNotGreater()
        {
            Character attacker1 = new Character(100, "attacker1");
            Character attacker2 = new Character(100, "attacker2");
            attacker1.AddItem(testingItem2);
            attacker2.AddItem(testingItem);

            attacker1.Attack(attacker2);

            int expected = 80;
            
            Assert.AreEqual(expected, attacker2.Health);
        }
        [Test]
        public void EnoughAttackShouldKill()
        {
            Character attacker1 = new Character(100, "attacker1");
            Character attacker2 = new Character(100, "attacker2");
            Item theAdminsSword = new Item("The admin sword", 1000, 1000);
            attacker1.AddItem(theAdminsSword);
            attacker2.AddItem(testingItem);

            attacker1.Attack(attacker2);

            int expected = 0;
            
            Assert.AreEqual(expected, attacker2.Health);
            Assert.True(attacker2.IsDead);
        }
    }


}