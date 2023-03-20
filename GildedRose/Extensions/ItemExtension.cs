using GildedRose.Domain;
using GildedRose.Enum;

namespace GildedRose.Extensions
{
    public static class ItemExtension
    {
        public static Category GetCategory(this Item item) =>
            item.Name switch
            {
                "Aged Brie" => Category.AgedBrie,
                "Backstage passes to a TAFKAL80ETC concert" => Category.BackstagePass,
                "Sulfuras, Hand of Ragnaros" => Category.Legendary,
                "Conjured Mana Cake" => Category.Conjured,
                _ => Category.Normal,
            };
    }
}

