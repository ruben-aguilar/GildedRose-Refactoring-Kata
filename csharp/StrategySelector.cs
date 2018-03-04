using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public static class StrategySelector
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        private const string BACKSTAGE_PASS = "Backstage passes to a TAFKAL80ETC concert";

        private static BackstagePassStrategy backstagePassStrategy;
        private static AgedBrieStrategy agedBrieStrategy;
        private static RegularItemStrategy regularItemStrategy;
        private static SulfurasStrategy sulfurasStrategy;

        static StrategySelector()
        {
            backstagePassStrategy = new BackstagePassStrategy();
            agedBrieStrategy = new AgedBrieStrategy();
            regularItemStrategy = new RegularItemStrategy();
            sulfurasStrategy = new SulfurasStrategy();
        }


        public static UpdateStrategy GetStrategyFor(Item item)
        {
            switch(item.Name)
            {
                case AGED_BRIE:
                    return agedBrieStrategy;
                case BACKSTAGE_PASS:
                    return backstagePassStrategy;
                case SULFURAS:
                    return sulfurasStrategy;
                default:
                    return regularItemStrategy;
            }
        }
    }
}
