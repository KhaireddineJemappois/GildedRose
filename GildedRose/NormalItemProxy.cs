namespace GildedRoseKata
{
    public class NormalItemProxy : ItemProxy
    {
        public NormalItemProxy(Item item) : base(item)
        {
        }

        public override void Process()
        {
            DecrementSellIn();
            if (SellIn < 0)
                DecreaseQuality(2);
            else
                DecreaseQuality();
        }
    }
}
