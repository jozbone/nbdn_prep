using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableCriteriaFactory<ItemToFilter,PropertyType> where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToFilter, PropertyType> property_accessor;

        public ComparableCriteriaFactory(Func<ItemToFilter, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return new AnonymousCriteria<ItemToFilter>(item => property_accessor(item).CompareTo(value) > 0);
        }
    }
}