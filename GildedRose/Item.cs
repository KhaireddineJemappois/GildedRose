namespace GildedRoseKata
{
    public class Item
    {
        public Item()
        {
            
        }
        public Item(string name, int sellin, int quality)
        {
            SellIn = sellin;
            Quality = quality;
            Name = name;
        }

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
}
