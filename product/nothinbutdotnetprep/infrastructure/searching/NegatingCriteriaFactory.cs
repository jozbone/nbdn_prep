namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NegatingCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        CriteriaFactory<ItemToFilter, PropertyType> basic;

        public NegatingCriteriaFactory(CriteriaFactory<ItemToFilter, PropertyType> basic)
        {
            this.basic = basic;
        }

        public CriteriaFactory<ItemToFilter, PropertyType> not
        {
            get { return this; }
        }

        public Criteria<ItemToFilter> create_property_criteria_for(Criteria<PropertyType> criteria)
        {
            return new NotCriteria<ItemToFilter>(basic.create_property_criteria_for(criteria));
        }
    }
}