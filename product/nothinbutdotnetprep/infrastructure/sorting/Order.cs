using System;
using System.Collections;
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

        public static IComparer<ItemToOrder> then_by<PropertyType>(Func<ItemToOrder, PropertyType> property_accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparablePropertyComparer<ItemToOrder, PropertyType>(property_accessor);
        }

       
    }
    public class BasicOrderingFactory<ItemToOrder, PropertyType> : OrderingFactory<ItemToOrder, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        private Func<ItemToOrder, PropertyType> accessor;
          public BasicOrderingFactory(Func<ItemToOrder, PropertyType> property_accessor)
          {
              accessor = property_accessor;
          }

        public Comparer<ItemToOrder> create_order_for(Comparer<PropertyType> comparer)
        {
            return new ComparablePropertyComparer<ItemToOrder, PropertyType>(accessor);
        }
    }

    public interface OrderingFactory<ItemToFilter, PropertyType>
    {
        Comparer<ItemToFilter> create_order_for(Comparer<PropertyType> comparer);
    }
    

}