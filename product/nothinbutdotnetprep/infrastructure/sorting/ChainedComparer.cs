using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ChainedComparer<T> : IComparer<T>
    {
        IComparer<T> first;
        IComparer<T> second;

        public ChainedComparer(IComparer<T> first, IComparer<T> second)
        {
            this.first = first;
            this.second = second;
        }

        public int Compare(T x, T y)
        {
            var value = first.Compare(x, y);
            if (value == 0) return second.Compare(x, y);
            return value;
        }
    }
}