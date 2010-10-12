using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public static class FilteringExtensions
    {
        public static Criteria<ItemToFilter> between<ItemToFilter, PropertyType>(
            this FilteringExtensionPoint<ItemToFilter, PropertyType> extension_point, PropertyType start,
            PropertyType end) where PropertyType : IComparable<PropertyType>
        {
            return
                new AnonymousCriteria<ItemToFilter>(
                    item =>
                        extension_point.accessor(item).CompareTo(start) >= 0 &&
                            extension_point.accessor(item).CompareTo(end) <= 0);
        }

        public static Criteria<ItemToFilter> greater_than<ItemToFilter, PropertyType>(
            this FilteringExtensionPoint<ItemToFilter, PropertyType> extension_point, PropertyType value)
            where PropertyType : IComparable<PropertyType>
        {
            return new AnonymousCriteria<ItemToFilter>(item => extension_point.accessor(item).CompareTo(value) > 0);
        }
    }
}