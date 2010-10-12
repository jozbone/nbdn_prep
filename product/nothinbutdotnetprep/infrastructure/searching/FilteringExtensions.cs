using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public static class FilteringExtensions
    {
        public static Criteria<ItemToFilter> equal_to<ItemToFilter, PropertyType>(
            this CriteriaFactory<ItemToFilter, PropertyType> extension_point, PropertyType value)
        {
            return equal_to_any(extension_point, value);
        }

        public static Criteria<ItemToFilter> equal_to_any<ItemToFilter, PropertyType>(
            this CriteriaFactory<ItemToFilter, PropertyType> extension_point, params PropertyType[] values)
        {
            return extension_point.create_property_criteria_for(new IsEqualToAny<PropertyType>(values));
        }

        public static Criteria<ItemToFilter> between<ItemToFilter, PropertyType>(
            this CriteriaFactory<ItemToFilter, PropertyType> criteria_factory, PropertyType start,
            PropertyType end) where PropertyType : IComparable<PropertyType>
        {
            return criteria_factory.create_property_criteria_for(new FallsInRange<PropertyType>(
                                                                     new InclusiveRange<PropertyType>(start, end)));

        }

        public static Criteria<ItemToFilter> greater_than<ItemToFilter, PropertyType>(
            this CriteriaFactory<ItemToFilter, PropertyType> criteria_factory, PropertyType value)
            where PropertyType : IComparable<PropertyType>
        {
            return criteria_factory.create_property_criteria_for(new IsGreaterThan<PropertyType>(value));
        }
    }

  
}