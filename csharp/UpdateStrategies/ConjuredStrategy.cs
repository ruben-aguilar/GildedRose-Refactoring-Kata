namespace csharp.UpdateStrategies
{
    class ConjuredStrategy : UpdateStrategy
    {
        public override void Update(Item item)
        {
            DecreaseQuality(item);
            DecreaseQuality(item);

            DecreaseSellIn(item);

            if(item.SellIn < 0)
            {
                DecreaseQuality(item);
                DecreaseQuality(item);
            }
        }
    }
}
