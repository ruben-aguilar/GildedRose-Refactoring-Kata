namespace csharp.UpdateStrategies
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
    }
}
