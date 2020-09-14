using System;
using NUnit.Framework;
using RolGame;

namespace Test.Library
{


    public class ComposedItemTests
    {

  
        ComposedItem crown = new ComposedItem("the silver crown", 2, 1);
        ComposedItem crown2 = new ComposedItem("the golden crown", 2, 1);
        ComposedItem crown3 = new ComposedItem("the black crown", 2, 1);
        Item redGem = new Item("BalancedRuby", 5, 5);
        Item greenGem = new Item("EmeraldOfWar", 20, 3);
        Item blueGem = new Item("ProtectionSapphire", 3, 20);
     
        [Test]
        public void AddComponent()
        {
            crown.AddComponent(redGem);
            string expectedItemName = "BalancedRuby";
            
            Assert.AreEqual(expectedItemName, crown.Components[0].Name);
        }
        [Test]
        public void AddComponentShouldModifyItemStats()
        {
            int expectedItemAttack = 7;
            int expectedItemDefense = 6;

            crown2.AddComponent(redGem);

            Assert.AreEqual(expectedItemAttack, crown2.GetItemAttack());
            Assert.AreEqual(expectedItemDefense, crown2.GetItemDefense());
        }
        [Test]
        public void RemoveComponent()
        {
            crown.RemoveComponent(redGem);            
            Assert.IsEmpty(crown.Components);
        }
        [Test]
        public void RemoveComponentShouldModifyCharacterStats()
        {
            int expectedItemAttack = 2;
            int expectedItemDefense = 1;

            crown2.RemoveComponent(redGem);

            Assert.AreEqual(expectedItemAttack, crown2.GetItemAttack());
            Assert.AreEqual(expectedItemDefense, crown2.GetItemDefense());
        }

        [Test]
        public void GetCharacterStats()
        {
            crown3.AddComponent(redGem);
            crown3.AddComponent(blueGem);
            crown3.RemoveComponent(redGem);
            crown3.AddComponent(greenGem);
            int expectedItemAttack = 25;
            int expectedItemDefense = 24;
            Assert.AreEqual(expectedItemAttack, crown3.GetItemAttack());
            Assert.AreEqual(expectedItemDefense, crown3.GetItemDefense());
        }
    }


}