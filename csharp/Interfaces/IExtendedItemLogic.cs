using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public interface IExtendedItemLogic
    {
        ExtendedItem ConvertToExtendedItem(Item oldItem);
        Item ConvertToItem(ExtendedItem oldItem);
        void updateSellIn(ExtendedItem item);
        void updateQualityByType(ExtendedItem item);
        void setMinMaxQuality(ExtendedItem item);
    }
}
