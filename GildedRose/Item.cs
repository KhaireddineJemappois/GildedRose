namespace GildedRoseKata
{
    public class Item
    {
        public Item(int sellin, int quality)
        {
            SellIn = sellin;
            Quality = quality;
        }

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
}
