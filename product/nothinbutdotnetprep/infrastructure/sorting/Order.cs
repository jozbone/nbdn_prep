using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetprep.collections;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Order<ItemToOrder>
    {
        public static Comparer<ItemToOrder> by_descending<PropertyType>(Func<ItemToOrder, PropertyType> property_accessor)
        {
            Comparer<ItemToOrder> comparer = Comparer<ItemToOrder>.Default;
            return comparer;
        }
    }

    public class ItemComparer<ItemToCompare, PropertyType> : Comparer<ItemToCompare>
    {
        private Func<ItemToCompare, PropertyType> accessor;

        public ItemComparer(Func<ItemToCompare, PropertyType> property_accessor)
        {
            accessor = property_accessor;
        }

        public override int Compare(ItemToCompare x, ItemToCompare y)
        {
            return 0;
        }
    }
}
