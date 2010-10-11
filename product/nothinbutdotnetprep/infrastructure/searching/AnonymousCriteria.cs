using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class AnonymousCriteria<T> : Criteria<T>
    {
        Predicate<T> condition;

        public AnonymousCriteria(Predicate<T> condition)
        {
            this.condition = condition;
        }

        public bool is_satisfied_by(T item)
        {
            return condition(item);
        }
    }
}