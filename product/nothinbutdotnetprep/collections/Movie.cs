using System;

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

        public static int SortByTitle(Movie movie1, Movie movie2)
        {
            return movie1.title.CompareTo(movie2.title);
        }

        public static int SortByDate(Movie movie1, Movie movie2)
        {
            return movie1.date_published.CompareTo(movie2.date_published);
        }

        public static int SortByStudioAndYearPublished(Movie movie1, Movie movie2)
        {
            return movie1.date_published.CompareTo(movie2.date_published);
            //var publisher = movie1.production_studio.CompareTo(movie2.production_studio);
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