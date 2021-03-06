using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class IsEqualToAny<T> : Criteria<T>
    {
        IList<T> values;

        public IsEqualToAny(params T[] values)
        {
            this.values = new List<T>(values);
        }

        public bool is_satisfied_by(T item)
        {
            return values.Contains(item);
        }
    }
}