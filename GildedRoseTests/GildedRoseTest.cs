using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using Moq;

namespace GildedRose
{
    public class GildedRoseTest
    {
        private readonly IItemProcessor _itemProcessor;
        public GildedRoseTest()
        {
            var mockedProcessor = new Mock<IItemProcessor>();
            mockedProcessor.Setup(q => q.Process(It.IsAny<ItemProxy>()))
                .Callback<ItemProxy>(item=>
                {
                    item.Process();
                })
                ;
            _itemProcessor = mockedProcessor.Object;
        }
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("fixme", Items[0].Name);
        }
        [Theory]
        [InlineData("+5 Dexterity Vest", 10, 20, 9, 19)]
        [InlineData("Aged Brie", 2, 0, 1, 1)]
        [InlineData("Aged Brie", 2, 50, 1, 50)]
        [InlineData("Aged Brie", 0, 40, -1, 42)]
        [InlineData("Elixir of the Mongoose", 5, 7, 4, 6)]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        [InlineData("Sulfuras, Hand of Ragnaros", -1, 80, 0, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 15, 20, 14, 22)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 49, 9, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 5, 49, 4, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 6, 20, 5, 22)]
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
            _itemProcessor.Process(item);
            //Verify
            Assert.Equal(item.SellIn, newSellin);
            Assert.Equal(item.Quality, newQuality);


        }
    }
}
