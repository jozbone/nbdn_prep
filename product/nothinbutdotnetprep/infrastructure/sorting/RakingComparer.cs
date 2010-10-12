using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class RakingComparer<PropertyType> : IComparer<PropertyType>
    {
        List<PropertyType> rankings;

        public RakingComparer(params PropertyType[] rankings)
        {
            this.rankings = new List<PropertyType>(rankings);
        }

        public int Compare(PropertyType x, PropertyType y)
        {
            return rankings.IndexOf(x).CompareTo(rankings.IndexOf(y));
        }
    }
}