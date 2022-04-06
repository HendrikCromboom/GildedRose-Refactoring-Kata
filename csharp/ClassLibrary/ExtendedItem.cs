using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class ExtendedItem: Item
    {
        public enum Type
        {
            normal,
            legendary,
            aged_brie,
            backstage_ticket,
        }

        public Type ItemType { get; set; }

        public void SetItemType()
        {
            switch(Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    ItemType = Type.legendary;
                    break;

                case "Backstage passes to a TAFKAL80ETC concert":
                    ItemType = Type.backstage_ticket;
                    break;

                case "Aged Brie":
                    ItemType = Type.aged_brie;
                    break;

                default:
                    ItemType = Type.normal;
                    break;
            }
        }

        public bool hasExpired()
        {
            return this.SellIn < 0; 
        }
        
        public bool hasMaxQuality()
        {
            return this.Quality == 50;
        }
    }
}
