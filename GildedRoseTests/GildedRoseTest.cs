using GildedRose.Factories;
using GildedRoseKata;

namespace GildedRose
{
    public class GildedRoseTest
    {
        [Theory]
        [InlineData("+5 Dexterity Vest", 10, 20, 9, 19)]
        [InlineData("Aged Brie", 2, 0, 1, 1)]
        [InlineData("Aged Brie", 2, 50, 1, 50)]
        [InlineData("Aged Brie", 0, 40, -1, 42)]
        [InlineData("Elixir of the Mongoose", 5, 7, 4, 6)]
        [InlineData("Sulfuras, Hand of Ragnaros", 1, 80, 0, 80)]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, -1, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 15, 20, 14, 21)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 49, 9, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 49, 4, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 7, 20, 6, 22)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 20, 4, 23)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 49, -1, 0)]
        [InlineData("Conjured Mana Cake", 3, 6, 2, 4)]
        [InlineData("Conjured Mana Cake", 0, 6, -1, 2)]
        [InlineData("Conjured Mana Cake", 0, 2, -1, 0)]
        public void ShouldUpdateSellInAndQualityCorrectly(string name, int sellin, int quality, int newSellin, int newQuality)
        {
            //Arrange
            var item = ItemProxyFactory.Create(new Item { Name = name, SellIn = sellin, Quality = quality });
            //Act
            item.Process();
            //Verify
            Assert.Equal(item.SellIn, newSellin);
            Assert.Equal(item.Quality, newQuality);


        }
        [Theory]
        [InlineData("Aged Brie", Category.AgedBrie)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", Category.BackstagePass)]
        [InlineData("Sulfuras, Hand of Ragnaros", Category.Legendary)]
        [InlineData("Conjured Mana Cake", Category.Conjured)]
        [InlineData("+5 Dexterity Vest", Category.Normal)]
        [InlineData("Elixir of the Mongoose", Category.Normal)]
        public void Shoud_Get_The_Right_Category_From_Name(string name, Category expectedCategory)
        {
            var item = new Item { Name = name };
            var category = item.GetCategory();
            Assert.Equal(category, expectedCategory);
        }

        [Theory]
        [InlineData("Aged Brie", typeof(AgedBrieItemProxy))]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", typeof(BackstagePassItemProxy))]
        [InlineData("Sulfuras, Hand of Ragnaros", typeof(LegendaryItemProxy))]
        [InlineData("Conjured Mana Cake", typeof(ConjuredItemProxy))]
        [InlineData("+5 Dexterity Vest", typeof(NormalItemProxy))]
        [InlineData("Elixir of the Mongoose", typeof(NormalItemProxy))]
        public void Should_Create_The_Right_Instance_Of_The_Proxy_Depending_On_Name(string name, Type type)
        {
            var item = new Item { Name = name };
            var proxy = ItemProxyFactory.Create(item);
            Assert.NotNull(proxy);
            Assert.IsType(type, proxy);
        }
    }
}
