using GildedRose.Domain;

namespace GildedRose.Application.Proxies
{
    public class LegendaryItemProxy : ItemProxy
    {
        public LegendaryItemProxy(Item item) : base(item)
        {
        }

        public override void Process()
        {
            DecrementSellIn();
            //Do not adjust quality
        }
    }
}
