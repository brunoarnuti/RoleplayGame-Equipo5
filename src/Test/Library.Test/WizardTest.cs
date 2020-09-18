using System;
using NUnit.Framework;
using RolGame;

namespace Test.Library
{


    public class WizardTests
    {
        private Wizard testingWizard = new Wizard(100, "testingChar");
        private Wizard testingWizard2 = new Wizard(100, "testingChar2");
        private Wizard testingWizard3 = new Wizard(100, "testingChar3");
        private Item testingItem = new Item("testingItem", 20, 10);
        private Item testingItem2 = new Item("testingItem2", 30, 25);

        [Test]
        public void InvalidNameShouldThrowException()
        {
            Assert.Throws<Exception>(() => new Wizard(100, ""));
            Assert.Throws<Exception>(() => new Wizard(100, null));
        }

        [Test]
        public void InvalidHealthShouldThrowException()
        {
            Assert.Throws<Exception>(() => new Wizard(-10, "Name1"));
        }

        [Test]
        public void AddItem()
        {
            testingWizard.AddItem(testingItem);
            string expectedItemName = "testingItem";
            
            Assert.AreEqual(expectedItemName, testingWizard.ItemsList[0].Name);
        }
        [Test]
        public void AddItemShouldModifyWizardStats()
        {
            int expectedWizardAttack = 30;
            int expectedWizardDefense = 25;

            testingWizard2.AddItem(testingItem2);

            Assert.AreEqual(expectedWizardAttack, testingWizard2.GetCharacterAttack());
            Assert.AreEqual(expectedWizardDefense, testingWizard2.GetCharacterDefense());
        }
        [Test]
        public void RemoveItem()
        {
            testingWizard.RemoveItem(testingItem);            
            Assert.IsEmpty(testingWizard.ItemsList);
        }
        [Test]
        public void RemoveItemShouldModifyWizardStats()
        {
            int expectedWizardAttack = 0;
            int expectedWizardDefense = 0;

            testingWizard2.RemoveItem(testingItem2);

            Assert.AreEqual(expectedWizardAttack, testingWizard2.GetCharacterAttack());
            Assert.AreEqual(expectedWizardDefense, testingWizard2.GetCharacterDefense());
        }

        [Test]
        public void GetWizardStats()
        {
            testingWizard3.AddItem(testingItem);
            testingWizard3.AddItem(testingItem2);
            testingWizard3.RemoveItem(testingItem);
            int expectedWizardAttack = 30;
            int expectedWizardDefense = 25;
            Assert.AreEqual(expectedWizardAttack, testingWizard3.GetCharacterAttack());
            Assert.AreEqual(expectedWizardDefense, testingWizard3.GetCharacterDefense());
        }
        [Test]
        public void HealShouldRestoreInitialHealth()
        {
            Wizard damagedWizard = new Wizard(100, "damagedChar");
            damagedWizard.RecieveAttack(testingWizard.GetCharacterAttack());

            int expected = 100;
            damagedWizard.Heal();
            
            Assert.AreEqual(expected, damagedWizard.Health);
            Assert.False(damagedWizard.IsDead);
        }
        [Test]
        public void RecieveAttackShouldNotDamageIfDefenseIsGreater()
        {
            testingWizard2.RecieveAttack(testingWizard.GetCharacterAttack());

            int expected = 100;
            
            Assert.AreEqual(expected, testingWizard2.Health);
        }
        [Test]
        public void RecieveAttackShouldDamageIfEnemyDefenseIsNotGreater()
        {
            Wizard attacker1 = new Wizard(100, "attacker1");
            Wizard attacker2 = new Wizard(100, "attacker2");
            attacker1.AddItem(testingItem2);
            attacker2.AddItem(testingItem);

            attacker2.RecieveAttack(attacker1.GetCharacterAttack());

            int expected = 80;
            
            Assert.AreEqual(expected, attacker2.Health);
        }
        [Test]
        public void EnoughAttackShouldKill()
        {
            Wizard attacker1 = new Wizard(100, "attacker1");
            Wizard attacker2 = new Wizard(100, "attacker2");
            Item theAdminsSword = new Item("The admin sword", 1000, 1000);
            attacker1.AddItem(theAdminsSword);
            attacker2.AddItem(testingItem);

            attacker2.RecieveAttack(attacker1.GetCharacterAttack());

            int expected = 0;
            
            Assert.AreEqual(expected, attacker2.Health);
            Assert.True(attacker2.IsDead);
        }
        public void AddSpell(Item Spell)
        {
            int expectedWizardAttack = 20;
            int expectedWizardDefense = 5;
            Wizard wizardWithBook = new Wizard(100, "TheBook'sWizard");
            Item spell1 = new Item("spell1", 20, 5);
            wizardWithBook.AddSpell(spell1);
            Assert.AreEqual(expectedWizardAttack, wizardWithBook.GetCharacterAttack());
            Assert.AreEqual(expectedWizardDefense, wizardWithBook.GetCharacterDefense());
        }
    }


}