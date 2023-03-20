namespace GildedRoseKata
{
    public class ConjuredItemProxy : ItemProxy
    {
        public ConjuredItemProxy(Item item) : base(item)
        {
        }

        public override void Process()
        {
            DecrementSellIn();
            DecreaseQuality(2);
            //if concert => decrease 4 times
            if (SellIn < 0)
            {
                DecreaseQuality(2);
            }
        }
    }
}
