using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToFilter>
    {
        public static ComparableCriteriaFactory<ItemToFilter, PropertyType> has_an<PropertyType>(
            Func<ItemToFilter, PropertyType> property_accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparableCriteriaFactory<ItemToFilter, PropertyType>(property_accessor,
                has_a(property_accessor));
        }

        public static BasicCriteriaFactory<ItemToFilter, PropertyType> has_a<PropertyType>(
            Func<ItemToFilter, PropertyType> property_accessor)
        {
            return new BasicCriteriaFactory<ItemToFilter, PropertyType>(property_accessor);
        }
    }
}