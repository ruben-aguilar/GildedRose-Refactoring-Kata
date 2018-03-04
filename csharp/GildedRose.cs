using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
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
                StrategySelector.GetStrategyFor(item).Update(item);
            }
        }
    }
}
