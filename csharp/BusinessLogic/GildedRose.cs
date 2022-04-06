﻿using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public IList<Item> getItems()
        {
            return this.Items;
        }
        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                ExtendedItem item = ConvertToExtendedItem(Items[i]);

                item.SetItemType();

                updateSellIn(item);
                updateQualityByType(item);

                Items[i] = ConvertToItem(item);
            }
        }

        public ExtendedItem ConvertToExtendedItem(Item oldItem)
        {
            ExtendedItem item = new ExtendedItem { Name = oldItem.Name, SellIn = oldItem.SellIn, Quality = oldItem.Quality };
            return item;
        }

        public Item ConvertToItem(ExtendedItem oldItem)
        {
            Item item = new Item { Name = oldItem.Name, SellIn = oldItem.SellIn, Quality = oldItem.Quality };
            return item;
        }

        public void updateSellIn(ExtendedItem item)
        {
            if(item.ItemType != ExtendedItem.Type.legendary)
            {
                item.SellIn -= 1;
            }
        }
        public void updateQualityByType(ExtendedItem item)
        {
            if (item.ItemType == ExtendedItem.Type.backstage_ticket)
            {
                if (item.SellIn < 11 && item.SellIn > 5)
                {
                    item.Quality += 2;
                }
                else if (item.SellIn < 6 && item.SellIn > -1)
                {
                    item.Quality += 3;
                }
                else if (item.SellIn < 0)
                {
                    item.Quality = 0;
                }
                else
                {
                    item.Quality += 1;
                }
            }
            else
            {
                int multiplier = 1;
                if (item.hasExpired())
                {
                    multiplier = 2;
                }
                if (item.ItemType == ExtendedItem.Type.aged_brie)
                {
                    item.Quality += multiplier;
                } 
                else if (item.ItemType == ExtendedItem.Type.normal)
                {
                    item.Quality -= multiplier;
                }
            }
            setMinMaxQuality(item);
        }

        public void setMinMaxQuality(ExtendedItem item)
        {
            if (item.ItemType != ExtendedItem.Type.legendary)
            {
                if (item.Quality > 50)
                {
                    item.Quality = 50;
                }
                else if (item.Quality < 0)
                {
                    item.Quality = 0;
                }
            }
        }
    }
}
