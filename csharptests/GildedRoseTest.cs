using csharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace csharptests
{
    [TestClass]
    public class GildedRoseTest
    {
        [TestMethod]
        public void updateQuality_nameIsFoo_returnsFoo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Foo, -1, 0", app.getItems()[0].ToString()); //on update the item has passed one unit but the quality can not go beneath 0
        }
    }
}
