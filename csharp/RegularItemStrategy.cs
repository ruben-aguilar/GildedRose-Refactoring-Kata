using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class RegularItemStrategy : UpdateStrategy
    {
        public override void Update(Item item)
        {
            DecreaseQuality(item);

            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                DecreaseQuality(item);
            }
        }
    }
}
