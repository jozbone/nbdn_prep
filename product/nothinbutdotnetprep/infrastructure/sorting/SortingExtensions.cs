using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public static class SortingExtensions
    {
        public static IComparer<ItemToFilter> equal_to_any<ItemToFilter, PropertyType>(
          this BasicOrderingFactory<ItemToFilter, PropertyType> ordering_factory)
        {
            //return ordering_factory.create_order_for(ItemToFilter);
            return null;
        }
    }
}
