using csharp.BusinessLogic;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        IExtendedItemLogic _extendedItemLogic;
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
            _extendedItemLogic = new ExtendedItemLogic();
            for (var i = 0; i < Items.Count; i++)
            {
                ExtendedItem item = _extendedItemLogic.ConvertToExtendedItem(Items[i]);

                item.SetItemType();

                _extendedItemLogic.updateSellIn(item);
                _extendedItemLogic.updateQualityByType(item);

                Items[i] = _extendedItemLogic.ConvertToItem(item);
            }
        }
    }
}
