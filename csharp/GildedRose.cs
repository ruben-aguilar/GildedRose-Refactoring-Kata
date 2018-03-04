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
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];

                if (!IsAgedBrie(item) && !IsBackstagePass(item))
                {
                    if(!IsSulfuras(item))
                    {
                        DecreaseQuality(item);
                    }
                }
                else
                {
                    if (item.Quality < MAXIMUM_QUALITY)
                    {
                        IncreaseQuality(item);

                        if (IsBackstagePass(item))
                        {
                            if (item.SellIn < BACKSTAGE_PASS_TWO_QUALITY_UNITS_THRESHOLD)
                            {
                                IncreaseQuality(item);
                            }

                            if (item.SellIn < BACKSTAGE_PASS_THREE_QUALITY_UNITS_THRESOLD)
                            {
                                IncreaseQuality(item);
                            }
                        }
                    }
                }

                if (!IsSulfuras(item))
                {
                    item.SellIn = item.SellIn - ONE_SELLIN_UNIT;
                }

                if (item.SellIn < 0)
                {
                    if (!IsAgedBrie(item))
                    {
                        if (!IsBackstagePass(item))
                        {
                            if(!IsSulfuras(item))
                            {
                                DecreaseQuality(item);
                            }
                        }
                        else
                        {
                            item.Quality = MINIMUM_QUALITY;
                        }
                    }
                    else
                    {
                        IncreaseQuality(item);
                    }
                }
            }
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
