﻿namespace GildedRoseKata
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

        protected void IncrementQuality()
        {
            if (_item.Quality < 50)
            {
                _item.Quality++;
            }
        }

        protected void DecrementQuality()
        {
            if (_item.Quality > 0)
            {
                _item.Quality--;
            }
        }

        protected void DropQuality()
        {
            _item.Quality = 0;
        }

        protected void DecrementSellIn()
        {
            _item.SellIn--;
        }
        public virtual void Process()
        {
            throw new System.Exception("Unknow Item Category");
        }
    }
}