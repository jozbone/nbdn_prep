using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class FilteringExtensionPoint<ItemToFilter, PropertyType>
    {
        public Func<ItemToFilter, PropertyType> accessor { private set; get; }

        public FilteringExtensionPoint(Func<ItemToFilter, PropertyType> property_accessor)
        {
            this.accessor = property_accessor;
        }
    }
}