using System;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Order<ItemToOrder>
    {
        public static ComparerBuilder<ItemToOrder> by_descending<PropertyType>(
            Func<ItemToOrder, PropertyType> property_accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToOrder>(new ReverseComparer<ItemToOrder>(new PropertyComparer<ItemToOrder, PropertyType>(property_accessor,
                                                                                                    new ComparableComparer
                                                                                                        <PropertyType>())));
        }

        public static ComparerBuilder<ItemToOrder> by<PropertyType>(Func<ItemToOrder, PropertyType> property_accessor,
                                                                    params PropertyType[] rankings)
        {
            return new ComparerBuilder<ItemToOrder>(new PropertyComparer<ItemToOrder, PropertyType>(property_accessor,
                                                                                                    new RakingComparer
                                                                                                        <PropertyType>(
                                                                                                        rankings)));
        }

        public static ComparerBuilder<ItemToOrder> by<PropertyType>(Func<ItemToOrder, PropertyType> property_accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToOrder>(new PropertyComparer<ItemToOrder, PropertyType>(property_accessor,
                                                                                                    new ComparableComparer
                                                                                                        <PropertyType>()));
        }
    }
}