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

        public static IComparer<ItemToOrder> by<PropertyType>(Func<ItemToOrder, PropertyType> property_accessor,params PropertyType[] rankings)
        {
            return new PropertyComparer<ItemToOrder, PropertyType>(property_accessor,
                                                                   new RakingComparer<PropertyType>(rankings));
        }

        public static IComparer<ItemToOrder> by<PropertyType>(Func<ItemToOrder, PropertyType> property_accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new PropertyComparer<ItemToOrder, PropertyType>(property_accessor,
                                                                   new ComparableComparer<PropertyType>());
        }

    }

    public static class ComparerExtensions
    {
        public static IComparer<ItemToOrder> then_by<ItemToOrder,PropertyType>(this IComparer<ItemToOrder> first,Func<ItemToOrder,PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ChainedComparer<ItemToOrder>(first,  Order<ItemToOrder>.by(accessor)); 
        }

        public static IComparer<ItemToOrder> then_by_descending<ItemToOrder,PropertyType>(this IComparer<ItemToOrder> first,Func<ItemToOrder,PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ChainedComparer<ItemToOrder>(first,  Order<ItemToOrder>.by_descending(accessor)); 
        }
    }
}