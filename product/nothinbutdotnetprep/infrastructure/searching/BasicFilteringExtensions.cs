using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public static class BasicFilteringExtensions
    {
        public static Criteria<ItemToFilter> equal_to<ItemToFilter, PropertyType>(
            this FilteringExtensionPoint<ItemToFilter, PropertyType> extension_point, PropertyType value)
        {
            return equal_to_any(extension_point, value);
        }

        public static Criteria<ItemToFilter> equal_to_any<ItemToFilter, PropertyType>(
            this FilteringExtensionPoint<ItemToFilter, PropertyType> extension_point, params PropertyType[] values)
        {
            return
                new AnonymousCriteria<ItemToFilter>(
                    x => new List<PropertyType>(values).Contains(extension_point.accessor(x)));
        }

        public static Criteria<ItemToFilter> not_equal_to<ItemToFilter, PropertyType>(
            this FilteringExtensionPoint<ItemToFilter, PropertyType> extension_point, PropertyType value)
        {
            return equal_to(extension_point, value).not();
        }
    }
}