namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface CriteriaFactory<ItemToFilter, PropertyType>
    {
        CriteriaFactory<ItemToFilter, PropertyType> not { get; }
        Criteria<ItemToFilter> create_property_criteria_for(Criteria<PropertyType> criteria);
    }
}