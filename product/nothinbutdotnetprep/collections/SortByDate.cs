using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class SortByDate : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.date_published.CompareTo(y.date_published);
        }
    }
}