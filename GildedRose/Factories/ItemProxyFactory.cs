using GildedRoseKata;

namespace GildedRose.Factories
{
    public static class ItemProxyFactory
    {
        public static ItemProxy Create(Item item)
            => item.GetCategory() switch
            {
                Category.Normal => new NormalItemProxy(item),
                Category.Conjured => new ConjuredItemProxy(item),
                Category.BackstagePass => new BackstagePassItemProxy(item),
                Category.Legendary => new LegendaryItemProxy(item),
                Category.AgedBrie => new AgedBrieItemProxy(item),
            };
    }
}
