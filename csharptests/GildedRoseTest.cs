using csharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace csharptests
{
    [TestClass]
    public class GildedRoseTest
    {
        [TestMethod]
        public void updateQuality_FooSellIn0Quality0_SellinMinus1()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Foo, -1, 0", app.getItems()[0].ToString()); //The Quality of an item is never negative
        }

        [TestMethod]
        public void updateQuality_FooSellIn2Quality2_Sellin1Quality1()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Foo", SellIn = 2, Quality = 2 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Foo, 1, 1", app.getItems()[0].ToString()); //At the end of each day our system lowers both values for every item
        }

        [TestMethod]
        public void updateQuality_FooSellIn0Quality10_SellinMinus1Quality8()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Foo", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Foo, -1, 8", app.getItems()[0].ToString()); // Once the sell by date has passed, Quality degrades twice as fast
        }

        [TestMethod]
        public void updateQuality_AgedBrieSellIn10Quality10_Sellin9Quality11()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Aged Brie, 9, 11", app.getItems()[0].ToString()); // "Aged Brie" actually increases in Quality the older it gets
        }

        [TestMethod]
        public void updateQuality_AgedBrieSellIn10Quality50_Sellin9Quality50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Aged Brie, 9, 50", app.getItems()[0].ToString()); // The Quality of an item is never more than 50
        }

        [TestMethod]
        public void updateQuality_SulfurasSellIn10Quality10_Sellin10Quality10()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Sulfuras, Hand of Ragnaros, 10, 10", app.getItems()[0].ToString()); // "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        }

        [TestMethod]
        public void updateQuality_BackstagePassesSellIn12Quality10_Sellin11Quality11()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert, 11, 11", app.getItems()[0].ToString()); // "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
        }

        [TestMethod]
        public void updateQuality_BackstagePassesSellIn10Quality10_Sellin9Quality12()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert, 9, 12", app.getItems()[0].ToString()); // Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
        }

        [TestMethod]
        public void updateQuality_BackstagePassesSellIn5Quality10_Sellin4Quality13()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert, 4, 13", app.getItems()[0].ToString()); // Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
        }

        [TestMethod]
        public void updateQuality_BackstagePassesSellIn0Quality20_SellinMinus1Quality0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert, -1, 0", app.getItems()[0].ToString()); // Quality drops to 0 after the concert
        }



    }
}
