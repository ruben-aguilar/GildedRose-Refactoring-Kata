using csharp.UpdateStrategies;

namespace csharp
{
    public static class StrategySelector
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        private const string BACKSTAGE_PASS = "Backstage passes to a TAFKAL80ETC concert";
        private const string CONJURED = "Conjured";

        private static BackstagePassStrategy backstagePassStrategy;
        private static AgedBrieStrategy agedBrieStrategy;
        private static RegularItemStrategy regularItemStrategy;
        private static SulfurasStrategy sulfurasStrategy;
        private static ConjuredStrategy conjuredStrategy;

        static StrategySelector()
        {
            backstagePassStrategy = new BackstagePassStrategy();
            agedBrieStrategy = new AgedBrieStrategy();
            regularItemStrategy = new RegularItemStrategy();
            sulfurasStrategy = new SulfurasStrategy();
            conjuredStrategy = new ConjuredStrategy();
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
                case CONJURED:
                    return conjuredStrategy;
                default:
                    return regularItemStrategy;
            }
        }
    }
}
