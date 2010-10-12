using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public static class ComparableFilteringExtensions
    {
        public static Criteria<ItemToFilter> between<ItemToFilter, PropertyType>(
            this FilteringExtensionPoint<ItemToFilter, PropertyType> extension_point, PropertyType start,
            PropertyType end) where PropertyType : IComparable<PropertyType>
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(extension_point.accessor,
                                                                    new FallsInRange<PropertyType>(
                                                                        new InclusiveRange<PropertyType>(start, end)));

        }

        public static Criteria<ItemToFilter> greater_than<ItemToFilter, PropertyType>(
            this FilteringExtensionPoint<ItemToFilter, PropertyType> extension_point, PropertyType value)
            where PropertyType : IComparable<PropertyType>
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(extension_point.accessor,
                                                                    new IsGreaterThan<PropertyType>(value));
        }
    }
}