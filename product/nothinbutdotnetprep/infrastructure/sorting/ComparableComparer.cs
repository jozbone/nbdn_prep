using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ComparableComparer<ComparableType> : IComparer<ComparableType>
        where ComparableType : IComparable<ComparableType>
    {
        public int Compare(ComparableType x, ComparableType y)
        {
            return x.CompareTo(y);
        }
    }
}