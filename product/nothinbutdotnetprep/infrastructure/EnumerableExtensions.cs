using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.searching;
using nothinbutdotnetprep.infrastructure.sorting;

namespace nothinbutdotnetprep.infrastructure
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items) yield return item;
        }

        static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Predicate<T> condition)
        {
            foreach (var item in items)
            {
                if (condition(item)) yield return item;
            }
        }

        public static IEnumerable<T> sort_using<T>(this IEnumerable<T> items, IComparer<T> comparer)
        {
            var sorted = new List<T>(items);
            sorted.Sort(comparer);
            return sorted;
        }

        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Criteria<T> condition)
        {
            return all_items_matching(items, condition.is_satisfied_by);
        }

        public static IEnumerable<ItemToSort> order_by_descending<ItemToSort, PropertyType>(
            this IEnumerable<ItemToSort> items, Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return items.sort_using(new ReverseComparer<ItemToSort>(new PropertyComparer<ItemToSort, PropertyType>(accessor,
                                                                                           new ComparableComparer
                                                                                               <PropertyType>())));
        }

        public static IEnumerable<ItemToSort> order_by<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> items,
                                                                                 Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return items.sort_using(new PropertyComparer<ItemToSort, PropertyType>(accessor, new ComparableComparer<PropertyType>()));
        }

        public static IEnumerable<ItemToSort> order_by<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> items,
                                                                                 Func<ItemToSort, PropertyType> accessor,
                                                                                 params PropertyType[] values)
        {
            return items.sort_using(new PropertyComparer<ItemToSort, PropertyType>(accessor, new RakingComparer<PropertyType>(values)));
        }

        public static IEnumerable<ItemToSort> then_by<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> items, 
                                                                                Func<ItemToSort, PropertyType> accessor)
        {
//            
//            var comparer = new ComparerBuilder<ItemToSort>(new PropertyComparer<ItemToSort, PropertyType>(accessor,
//                                                                
//            return items.sort_using(comparer);
        }
    }
}