using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class BackstagePassStrategy : UpdateStrategy
    {
        private const int BACKSTAGE_PASS_TWO_QUALITY_UNITS_THRESHOLD = 11;
        private const int BACKSTAGE_PASS_THREE_QUALITY_UNITS_THRESOLD = 6;

        public override void Update(Item item)
        {
            IncreaseBackstageQuality(item);
            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                SetToMinimumQuality(item);
            }
        }

        private static void SetToMinimumQuality(Item item)
        {
            item.Quality = MINIMUM_QUALITY;
        }

        private void IncreaseBackstageQuality(Item item)
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
    }
}
