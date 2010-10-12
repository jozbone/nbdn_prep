using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class Movie  : IEquatable<Movie>
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }
        int new_info { get; set; }


        public static IComparer<Movie> SortByTitle()
        {
            return new SortByTitle();
        }

        public static IComparer<Movie> SortByDate()
        {
            return new SortByDate();
        }

        public static IComparer<Movie> SortByStudioAndYearPublished()
        {
            return new SortByMovieStudioAndYearPublished();
        }
        public int something
        {
            get
            {
                
            return 0;
            }
        }

        public bool Equals(Movie other)
        {
            if (other == null) return false;

            return ReferenceEquals(this,other) || is_equal_to_non_null_instance_of(other);
        }

        bool is_equal_to_non_null_instance_of(Movie other)
        {
            return this.title == other.title;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Movie);
        }

        public override int GetHashCode()
        {
            return title.GetHashCode();
        }
    }
}