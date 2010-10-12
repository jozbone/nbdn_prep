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

        //public static class Not
        //{
            public  FilteringExtensionPoint<ItemToFilter, PropertyType> toNegate;

            public  FilteringExtensionPoint<ItemToFilter, PropertyType> not
            {
                 get { return toNegate; }
                set { toNegate = value; }
            }
        //}
    }
}