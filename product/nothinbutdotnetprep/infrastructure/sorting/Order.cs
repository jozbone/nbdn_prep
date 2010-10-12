using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Order<ItemToOrder>
    {
        public static IComparer<ItemToOrder> by_descending<PropertyType>(
            Func<ItemToOrder, PropertyType> property_accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ReverseComparer<ItemToOrder>(by(property_accessor));
        }

        public static IComparer<ItemToOrder> by<PropertyType>(Func<ItemToOrder, PropertyType> property_accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparablePropertyComparer<ItemToOrder, PropertyType>(property_accessor);
        }
    }
}