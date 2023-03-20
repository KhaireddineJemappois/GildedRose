using GildedRose.Domain;

namespace GildedRose.Application.Proxies
{
    public class BackstagePassItemProxy : ItemProxy
    {
        public BackstagePassItemProxy(Item item) : base(item)
        {
        }

        public override void Process()
        {
            DecrementSellIn();
            IncreaseQuality();
            //if <=10 => increase twice
            if (SellIn <= 10)
            {
                IncreaseQuality();
            }
            //if <=5 => increase thrice
            if (SellIn <= 5)
            {
                IncreaseQuality();
            }
            if (SellIn < 0)
            {
                DropQuality();
            }
        }
    }
}