using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class RegularItemStrategy : IUpdateStrategy
    {
        private const int MINIMUM_QUALITY = 0;
        private const int ONE_QUALITY_UNIT = 1;
        private const int ONE_SELLIN_UNIT = 1;

        public void Update(Item item)
        {
            DecreaseQuality(item);
            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                DecreaseQuality(item);
            }
        }

        private static void DecreaseQuality(Item item)
        {
            if (item.Quality > MINIMUM_QUALITY)
            {
                item.Quality = item.Quality - ONE_QUALITY_UNIT;
            }
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - ONE_SELLIN_UNIT;
        }
    }
}
