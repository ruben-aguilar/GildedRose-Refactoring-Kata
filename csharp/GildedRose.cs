using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";

        private const string BACKSTAGE_PASS = "Backstage passes to a TAFKAL80ETC concert";
        private const int BACKSTAGE_PASS_TWO_QUALITY_UNITS_THRESHOLD = 11;
        private const int BACKSTAGE_PASS_THREE_QUALITY_UNITS_THRESOLD = 6;

        private const int MINIMUM_QUALITY = 0;
        private const int MAXIMUM_QUALITY = 50;
        private const int ONE_QUALITY_UNIT = 1;

        private const int ONE_SELLIN_UNIT = 1;

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            AgedBrieStrategy agedBrieStrategy = new AgedBrieStrategy();

            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];

                if(IsAgedBrie(item))
                {
                    agedBrieStrategy.Update(item);
                }

                if (IsBackstagePass(item))
                {
                    IncreaseBackstageQuality(item);
                    DecreaseSellIn(item);

                    if (item.SellIn < 0)
                    {
                        item.Quality = MINIMUM_QUALITY;
                    }
                }

                if (IsRegularItem(item))
                {
                    DecreaseQuality(item);
                    DecreaseSellIn(item);

                    if(item.SellIn < 0)
                    {
                        DecreaseQuality(item);
                    }
                }
            }
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - ONE_SELLIN_UNIT;
        }

        private static void IncreaseBackstageQuality(Item item)
        {
            IncreaseQuality(item);

            if (item.SellIn < BACKSTAGE_PASS_TWO_QUALITY_UNITS_THRESHOLD)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < BACKSTAGE_PASS_THREE_QUALITY_UNITS_THRESOLD)
            {
                IncreaseQuality(item);
            }
        }

        private bool IsRegularItem(Item item)
        {
            return !IsAgedBrie(item) && !IsBackstagePass(item) && !IsSulfuras(item);
        }

        private static void IncreaseQuality(Item item)
        {
            if(item.Quality < MAXIMUM_QUALITY)
            {
                item.Quality = item.Quality + ONE_QUALITY_UNIT;
            }
        }

        private static void DecreaseQuality(Item item)
        {
            if(item.Quality > MINIMUM_QUALITY)
            {
                item.Quality = item.Quality - ONE_QUALITY_UNIT;
            }
        }

        private bool IsSulfuras(Item item)
        {
            return item.Name == SULFURAS;
        }

        private bool IsBackstagePass(Item item)
        {
            return item.Name == BACKSTAGE_PASS;
        }

        private bool IsAgedBrie(Item item)
        {
            return item.Name == AGED_BRIE;
        }
    }
}
