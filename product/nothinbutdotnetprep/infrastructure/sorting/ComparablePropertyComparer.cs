using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ComparablePropertyComparer<ItemToCompare, PropertyType> : IComparer<ItemToCompare>
        where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToCompare, PropertyType> accessor;

        public ComparablePropertyComparer(Func<ItemToCompare, PropertyType> property_accessor)
        {
            accessor = property_accessor;
        }

        public int Compare(ItemToCompare x, ItemToCompare y)
        {
            return accessor(x).CompareTo(accessor(y));
        }
    }
}