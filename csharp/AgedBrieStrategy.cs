using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class AgedBrieStrategy : UpdateStrategy
    {
        public override void Update(Item item)
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
    }
}
