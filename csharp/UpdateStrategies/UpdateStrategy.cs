namespace csharp.UpdateStrategies
{
    public abstract class UpdateStrategy
    {
        protected const int MINIMUM_QUALITY = 0;
        protected const int ONE_SELLIN_UNIT = 1;
        protected const int MAXIMUM_QUALITY = 50;
        protected const int ONE_QUALITY_UNIT = 1;


        public abstract void Update(Item item);


        protected static void DecreaseQuality(Item item)
        {
            if (item.Quality > MINIMUM_QUALITY)
            {
                item.Quality = item.Quality - ONE_QUALITY_UNIT;
            }
        }

        protected static void IncreaseQuality(Item item)
        {
            if (item.Quality < MAXIMUM_QUALITY)
            {
                item.Quality = item.Quality + ONE_QUALITY_UNIT;
            }
        }

        protected static void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - ONE_SELLIN_UNIT;
        }
    }
}
