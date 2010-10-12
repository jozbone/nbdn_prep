using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
    {
        IComparer<ItemToSort> initial_comparer;

        public ComparerBuilder(IComparer<ItemToSort> initial_comparer)
        {
            this.initial_comparer = initial_comparer;
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(
                new ChainedComparer<ItemToSort>(initial_comparer,
                                                new PropertyComparer<ItemToSort, PropertyType>(accessor,
                                                                                               new ComparableComparer
                                                                                                   <PropertyType>())));
        }

        public ComparerBuilder<ItemToSort> then_by_descending<PropertyType>(
            Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(
                new ChainedComparer<ItemToSort>(initial_comparer,
                                                new ReverseComparer<ItemToSort>(new PropertyComparer<ItemToSort, PropertyType>(accessor,
                                                                                               new ComparableComparer
                                                                                                   <PropertyType>()))));
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return initial_comparer.Compare(x, y);
        }
    }
}