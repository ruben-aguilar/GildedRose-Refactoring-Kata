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
                if (Items[i].Name != AGED_BRIE && Items[i].Name != BACKSTAGE_PASS)
                {
                    if (Items[i].Quality > MINIMUM_QUALITY)
                    {
                        if (Items[i].Name != SULFURAS)
                        {
                            Items[i].Quality = Items[i].Quality - ONE_QUALITY_UNIT;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < MAXIMUM_QUALITY)
                    {
                        Items[i].Quality = Items[i].Quality + ONE_QUALITY_UNIT;

                        if (Items[i].Name == BACKSTAGE_PASS)
                        {
                            if (Items[i].SellIn < BACKSTAGE_PASS_TWO_QUALITY_UNITS_THRESHOLD)
                            {
                                if (Items[i].Quality < MAXIMUM_QUALITY)
                                {
                                    Items[i].Quality = Items[i].Quality + ONE_QUALITY_UNIT;
                                }
                            }

                            if (Items[i].SellIn < BACKSTAGE_PASS_THREE_QUALITY_UNITS_THRESOLD)
                            {
                                if (Items[i].Quality < MAXIMUM_QUALITY)
                                {
                                    Items[i].Quality = Items[i].Quality + ONE_QUALITY_UNIT;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != SULFURAS)
                {
                    Items[i].SellIn = Items[i].SellIn - ONE_SELLIN_UNIT;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != AGED_BRIE)
                    {
                        if (Items[i].Name != BACKSTAGE_PASS)
                        {
                            if (Items[i].Quality > MINIMUM_QUALITY)
                            {
                                if (Items[i].Name != SULFURAS)
                                {
                                    Items[i].Quality = Items[i].Quality - ONE_QUALITY_UNIT;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < MAXIMUM_QUALITY)
                        {
                            Items[i].Quality = Items[i].Quality + ONE_QUALITY_UNIT;
                        }
                    }
                }
            }
        }
    }
}
