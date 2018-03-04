namespace csharp.Tests
{
    internal class ItemBuilder
    {
        private string name;
        private int sellin;
        private int quality; 

        public static ItemBuilder AnItem()
        {
            return new ItemBuilder();
        }

        public static ItemBuilder AnAgedBrie()
        {
            return new ItemBuilder("Aged Brie");
        }

        public static ItemBuilder ASulfuras()
        {
            // Something weird here, I had to check the code to find Sulfura's real name
            return new ItemBuilder("Sulfuras, Hand of Ragnaros");
        }

        public static ItemBuilder ABackstagePass()
        {
            // I had to look at the code again
            return new ItemBuilder("Backstage passes to a TAFKAL80ETC concert");
        }

        private ItemBuilder()
        {
            name = "Default name";
            sellin = quality = 0;
        }

        private ItemBuilder(string name) : this()
        {
            this.name = name;
        }

        public ItemBuilder WithName(string name)
        {
            this.name = name;

            return this;
        }

        public ItemBuilder WithSellIn(int sellin)
        {
            this.sellin = sellin;

            return this;
        }

        public ItemBuilder WithQuality(int quality)
        {
            this.quality = quality;

            return this;
        }

        public Item Build()
        {
            return new Item
            {
                Name = this.name,
                SellIn = this.sellin,
                Quality = this.quality
            };
        }
    }
}
