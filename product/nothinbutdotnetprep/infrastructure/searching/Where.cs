using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToFilter>
    {
        public static BasicCriteriaFactory<ItemToFilter, PropertyType> has_a<PropertyType>(
            Func<ItemToFilter, PropertyType> property_accessor)
        {
            return new BasicCriteriaFactory<ItemToFilter, PropertyType>(property_accessor);
        }
    }
}