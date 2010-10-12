using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType>  : CriteriaFactory<ItemToFilter,PropertyType> where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToFilter, PropertyType> property_accessor;
        CriteriaFactory<ItemToFilter, PropertyType> regular_factory;

        public ComparableCriteriaFactory(Func<ItemToFilter, PropertyType> property_accessor, CriteriaFactory<ItemToFilter, PropertyType> regular_factory)
        {
            this.property_accessor = property_accessor;
            this.regular_factory = regular_factory;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return new AnonymousCriteria<ItemToFilter>(item => property_accessor(item).CompareTo(value) > 0);
        }

        public Criteria<ItemToFilter> between(PropertyType value1, PropertyType value2)
        {
            return
                new AnonymousCriteria<ItemToFilter>(
                    item =>
                        property_accessor(item).CompareTo(value1) >= 0 && property_accessor(item).CompareTo(value2) <= 0);
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return regular_factory.equal_to(value);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return regular_factory.equal_to_any(values);
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return regular_factory.not_equal_to(value);
        }
    }
}