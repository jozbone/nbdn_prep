using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class BasicCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;

        public BasicCriteriaFactory(Func<ItemToFilter, PropertyType> property_accessor)
        {
            this.accessor = property_accessor;
        }

        public CriteriaFactory<ItemToFilter, PropertyType> not
        {
            get
            {
                return new NegatingCriteriaFactory<ItemToFilter, PropertyType>(this);
            }
        }

        public Criteria<ItemToFilter> create_property_criteria_for(Criteria<PropertyType> criteria)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor, criteria);
        }
    }
}