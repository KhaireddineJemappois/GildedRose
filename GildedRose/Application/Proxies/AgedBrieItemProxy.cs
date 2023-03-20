using GildedRose.Domain;

namespace GildedRose.Application.Proxies
{
    public class AgedBrieItemProxy : ItemProxy
    {
        public AgedBrieItemProxy(Item item) : base(item)
        {
        }

        public override void Process()
        {
            DecrementSellIn();
            if (SellIn < 0)
                IncreaseQuality(2);
            else
                IncreaseQuality();
        }
    }
}