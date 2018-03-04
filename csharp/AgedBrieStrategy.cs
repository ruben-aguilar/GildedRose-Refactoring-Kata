using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class AgedBrieStrategy : IUpdateStragety
    {
        private const int MAXIMUM_QUALITY = 50;
        private const int ONE_QUALITY_UNIT = 1;

        private const int ONE_SELLIN_UNIT = 1;

        public void Update(Item item)
        {
            IncreaseQuality(item);
            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                IncreaseQuality(item);
            }
        }

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < MAXIMUM_QUALITY)
            {
                item.Quality = item.Quality + ONE_QUALITY_UNIT;
            }
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - ONE_SELLIN_UNIT;
        }

    }
}
