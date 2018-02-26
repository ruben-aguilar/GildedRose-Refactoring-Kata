using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseShould_
    {
        private Item item1;
        private const string ITEM_ONE_NAME = "Test item 1";
        private const int ITEM_ONE_QUALITY = 3;
        private const int ITEM_ONE_SELLIN = 1;

        private Item item2;
        private const string ITEM_TWO_NAME = "Test item 2";
        private const int ITEM_TWO_QUALITY = 5;
        private const int ITEM_TWO_SELLIN = 4;

        [SetUp]
        public void Setup()
        {
            item1 = Tests.ItemBuilder.AnItem()
                                     .WithName(ITEM_ONE_NAME)
                                     .WithQuality(ITEM_ONE_QUALITY)
                                     .WithSellIn(ITEM_ONE_SELLIN)
                                     .Build();

            item2 = Tests.ItemBuilder.AnItem()
                                     .WithName(ITEM_TWO_NAME)
                                     .WithQuality(ITEM_TWO_QUALITY)
                                     .WithSellIn(ITEM_TWO_SELLIN)
                                     .Build();
        }

        [Test]
        public void decrease_item_quality_after_a_day_by_one()
        {
            GildedRose gildedRose = new GildedRose(new List<Item> { item1 });

            gildedRose.UpdateQuality();

            Assert.AreEqual(ITEM_ONE_QUALITY - 1, item1.Quality);
        }

        [Test]
        public void decrease_item_quality_after_three_days_by_three()
        {
            GildedRose gildedRose = new GildedRose(new List<Item> { item1 });

            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();

            Assert.AreEqual(ITEM_ONE_QUALITY - 3, item1.Quality);
        }

        [Test]
        public void decrease_item_quality_of_all_the_items_after_a_day()
        {
            GildedRose gildedRose = new GildedRose(new List<Item> { item1, item2 });

            gildedRose.UpdateQuality();

            Assert.AreEqual(ITEM_ONE_QUALITY - 1, item1.Quality);
            Assert.AreEqual(ITEM_TWO_QUALITY - 1, item2.Quality);
        }

        [Test]
        public void decrease_item_sellin_after_a_day_by_one()
        {
            GildedRose gildedRose = new GildedRose(new List<Item> { item1 });

            gildedRose.UpdateQuality();

            Assert.AreEqual(ITEM_ONE_SELLIN - 1, item1.SellIn);
        }

        [Test]
        public void decrease_item_sellin_after_three_days_by_three()
        {
            GildedRose gildedRose = new GildedRose(new List<Item> { item1 });

            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();

            Assert.AreEqual(ITEM_ONE_SELLIN- 3, item1.SellIn);
        }

        [Test]
        public void decrease_item_sellin_of_all_the_items_after_a_day()
        {
            GildedRose gildedRose = new GildedRose(new List<Item> { item1, item2 });

            gildedRose.UpdateQuality();

            Assert.AreEqual(ITEM_ONE_SELLIN - 1, item1.SellIn);
            Assert.AreEqual(ITEM_TWO_SELLIN - 1, item2.SellIn);
        }




    }
}
