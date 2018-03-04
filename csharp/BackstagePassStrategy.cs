using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class BackstagePassStrategy : IUpdateStrategy
    {
        private const int MINIMUM_QUALITY = 0;
        private const int BACKSTAGE_PASS_TWO_QUALITY_UNITS_THRESHOLD = 11;
        private const int BACKSTAGE_PASS_THREE_QUALITY_UNITS_THRESOLD = 6;
        private const int ONE_SELLIN_UNIT = 1;
        private const int MAXIMUM_QUALITY = 50;
        private const int ONE_QUALITY_UNIT = 1;

        public void Update(Item item)
        {
            IncreaseBackstageQuality(item);
            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                item.Quality = MINIMUM_QUALITY;
            }
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

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - ONE_SELLIN_UNIT;
        }

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < MAXIMUM_QUALITY)
            {
                item.Quality = item.Quality + ONE_QUALITY_UNIT;
            }
        }
    }
}
