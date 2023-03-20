namespace GildedRoseKata
{
    public class ItemProxy
    {
        private Item _item;
        public ItemProxy(Item item)
        {
            _item = item;
        }
        public string Name => _item.Name;
        public int SellIn => _item.SellIn;
        public int Quality => _item.Quality;

        protected void IncrementQuality(int step = 1)
        {
            if (_item.Quality < 50)
            {
                _item.Quality += step;
            }
        }

        protected void DecrementQuality(int step = 1)
        {
            if (_item.Quality > 0)
            {
                _item.Quality -= step;
            }
        }

        protected void DropQuality()
        {
            _item.Quality = 0;
        }

        protected void DecrementSellIn(int step = 1)
        {
            _item.SellIn -= step;
        }
        public virtual void Process()
        {
            throw new System.Exception("Unknow Item Category");
        }
    }
}
