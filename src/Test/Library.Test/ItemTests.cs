using System;
using NUnit.Framework;
using RolGame;

namespace Test.Library
{


    public class ItemTests
    {
        [Test]
        public void InvalidNameShouldThrowException()
        {
            Assert.Throws<Exception>(() => new Item("", 100, 100));
            Assert.Throws<Exception>(() => new Item(null, 100, 100));

        }
        [Test]
        public void ItemStatsShouldNotBeNegative()
        {
            Item item1 = new Item("item1", -10, 10);
            Item item2 = new Item("item2", 10, -10);

            int expectedItem1Attack = 0;
            int expectedItem2Defense = 0;

            Assert.AreEqual(expectedItem1Attack, item1.GetItemAttack());
            Assert.AreEqual(expectedItem2Defense, item2.GetItemDefense());
        }
    }
}