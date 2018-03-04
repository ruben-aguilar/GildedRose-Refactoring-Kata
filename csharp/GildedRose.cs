using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        private const string BACKSTAGE_PASS = "Backstage passes to a TAFKAL80ETC concert";

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            AgedBrieStrategy agedBrieStrategy = new AgedBrieStrategy();
            BackstagePassStrategy backstagePassStrategy = new BackstagePassStrategy();
            RegularItemStrategy regularItemStrategy = new RegularItemStrategy();

            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];

                if(IsAgedBrie(item))
                {
                    agedBrieStrategy.Update(item);
                }

                if (IsBackstagePass(item))
                {
                    backstagePassStrategy.Update(item);
                }

                if (IsRegularItem(item))
                {
                    regularItemStrategy.Update(item);
                }
            }
        }

        private bool IsRegularItem(Item item)
        {
            return !IsAgedBrie(item) && !IsBackstagePass(item) && !IsSulfuras(item);
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
