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
        private const int MAXIMUM_QUALITY = 50;

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

            Assert.AreEqual(ITEM_ONE_SELLIN - 3, item1.SellIn);
        }

        [Test]
        public void decrease_item_sellin_of_all_the_items_after_a_day()
        {
            GildedRose gildedRose = new GildedRose(new List<Item> { item1, item2 });

            gildedRose.UpdateQuality();

            Assert.AreEqual(ITEM_ONE_SELLIN - 1, item1.SellIn);
            Assert.AreEqual(ITEM_TWO_SELLIN - 1, item2.SellIn);
        }

        [Test]
        public void not_decrease_quality_below_zero()
        {
            GildedRose gildedRose = new GildedRose(new List<Item> { item1 });

            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();

            Assert.AreEqual(0, item1.Quality);
        }

        [Test]
        public void decrease_quality_twice_as_fast_when_the_sell_date_has_passed()
        {
            Item passedDateItem = Tests.ItemBuilder.AnItem()
                                                   .WithQuality(4)
                                                   .WithSellIn(0)
                                                   .Build();
            GildedRose gildedRose = new GildedRose(new List<Item> { passedDateItem });

            gildedRose.UpdateQuality();

            Assert.AreEqual(2, passedDateItem.Quality);
        }

        [Test]
        public void increase_quality_when_the_time_passes_for_aged_brie()
        {
            Item agedBrie = Tests.ItemBuilder.AnAgedBrie()
                                             .WithQuality(5)
                                             .WithSellIn(5)
                                             .Build();
            GildedRose gildedRose = new GildedRose(new List<Item> { agedBrie });

            gildedRose.UpdateQuality();

            Assert.AreEqual(6, agedBrie.Quality);
        }

        [Test]
        public void not_increase_above_50_the_quality_of_aged_brie()
        {
            Item agedBrie = Tests.ItemBuilder.AnAgedBrie()
                                             .WithQuality(MAXIMUM_QUALITY)
                                             .WithSellIn(4)
                                             .Build();
            GildedRose gildedRose = new GildedRose(new List<Item> { agedBrie });

            gildedRose.UpdateQuality();

            Assert.AreEqual(MAXIMUM_QUALITY, agedBrie.Quality);
        }

        [Test]
        public void not_update_the_quality_for_sulfuras()
        {
            Item sulfuras = Tests.ItemBuilder.ASulfuras()
                                             .WithQuality(2)
                                             .WithSellIn(2)
                                             .Build();
            GildedRose gildedRose = new GildedRose(new List<Item> { sulfuras });

            gildedRose.UpdateQuality();

            Assert.AreEqual(2, sulfuras.Quality);
        }

        [Test]
        public void not_update_the_sellin_for_sulfuras()
        {
            Item sulfuras = Tests.ItemBuilder.ASulfuras()
                                 .WithQuality(2)
                                 .WithSellIn(2)
                                 .Build();
            GildedRose gildedRose = new GildedRose(new List<Item> { sulfuras });

            gildedRose.UpdateQuality();

            Assert.AreEqual(2, sulfuras.SellIn);
        }

        [Test]
        public void update_backstage_passes_quality_by_two_when_there_are_10_days_or_less_to_the_concert()
        {
            Item backstagePass = Tests.ItemBuilder.ABackstagePass()
                                                  .WithQuality(3)
                                                  .WithSellIn(10)
                                                  .Build();
            GildedRose gildedRose = new GildedRose(new List<Item> { backstagePass });

            gildedRose.UpdateQuality();

            Assert.AreEqual(5, backstagePass.Quality);
        }

        [Test]
        public void update_backstage_passes_quality_by_one_when_there_are_more_than_10_days_to_the_concert()
        {
            Item backstagePass = Tests.ItemBuilder.ABackstagePass()
                                                  .WithQuality(3)
                                                  .WithSellIn(11)
                                                  .Build();
            GildedRose gildedRose = new GildedRose(new List<Item> { backstagePass });

            gildedRose.UpdateQuality();

            Assert.AreEqual(4, backstagePass.Quality);
        }

        [Test]
        public void update_backstage_passes_quality_by_three_when_there_are_5_days_or_less_to_the_concert()
        {
            Item backstagePass = Tests.ItemBuilder.ABackstagePass()
                                                  .WithQuality(3)
                                                  .WithSellIn(5)
                                                  .Build();
            GildedRose gildedRose = new GildedRose(new List<Item> { backstagePass });

            gildedRose.UpdateQuality();

            Assert.AreEqual(6, backstagePass.Quality);
        }

        [Test]
        public void drop_backstage_passes_quality_to_0_after_the_concert()
        {
            Item backstagePass = Tests.ItemBuilder.ABackstagePass()
                                                  .WithQuality(5)
                                                  .WithSellIn(0)
                                                  .Build();
            GildedRose gildedRose = new GildedRose(new List<Item> { backstagePass });

            gildedRose.UpdateQuality();

            Assert.AreEqual(0, backstagePass.Quality);
        }

        [Test]
        public void not_update_above_50_the_quality_of_backstage_passes()
        {
            Item backstagePass = Tests.ItemBuilder.ABackstagePass()
                                      .WithQuality(MAXIMUM_QUALITY)
                                      .WithSellIn(5)
                                      .Build();
            GildedRose gildedRose = new GildedRose(new List<Item> { backstagePass });

            gildedRose.UpdateQuality();

            Assert.AreEqual(50, backstagePass.Quality);
        }

        [Test]
        public void drop_conjured_items_quality_by_two_per_day()
        {
            Item conjured = Tests.ItemBuilder.AConjured()
                                                 .WithQuality(4)
                                                 .WithSellIn(4)
                                                 .Build();
            GildedRose gildedRose = new GildedRose(new List<Item> { conjured });

            gildedRose.UpdateQuality();

            Assert.AreEqual(2, conjured.Quality);
        }

        [Test]
        public void drop_conjured_items_quality_by_four_per_day_when_the_sellin_date_has_passed()
        {
            Item conjured = Tests.ItemBuilder.AConjured()
                                     .WithQuality(5)
                                     .WithSellIn(0)
                                     .Build();
            GildedRose gildedRose = new GildedRose(new List<Item> { conjured });

            gildedRose.UpdateQuality();

            Assert.AreEqual(1, conjured.Quality);
        }

        [Test]
        public void decrease_sellin_after_update()
        {
            Item conjured = Tests.ItemBuilder.AConjured()
                         .WithSellIn(1)
                         .Build();
            GildedRose gildedRose = new GildedRose(new List<Item> { conjured });

            gildedRose.UpdateQuality();

            Assert.AreEqual(0, conjured.SellIn);
        }

    }
}
