using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
