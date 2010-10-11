using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public static class RandomExtensions
    {
        public static Criteria<ItemToFilter> equal_to<ItemToFilter, PropertyType>(this Func<ItemToFilter, PropertyType> property_accessor,
            PropertyType value_to_equal)
        {
            return new AnonymousCriteria<ItemToFilter>(x => property_accessor(x).Equals(value_to_equal));
        }
    }
}