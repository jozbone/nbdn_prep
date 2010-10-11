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

        public static Predicate<Movie> is_in_genre(Genre genre)
        {
            return movie => movie.genre == genre; 
        }

        public static Predicate<Movie> is_published_by(ProductionStudio studio)
        {
            return movie => movie.production_studio == studio;
        }

        public static Predicate<Movie> is_published_between(int starting_year, int ending_year)
        {
            return movie => movie.date_published.Year >= starting_year && movie.date_published.Year <= ending_year;
        }

        public static Predicate<Movie> is_published_after(int year)
        {
            return movie => movie.date_published.Year > year;
        }

        public static bool is_not_published_by_pixar(Movie movie)
        {
            return movie.production_studio != ProductionStudio.Pixar;
        }

        public static bool is_published_by_pixar_or_disney(Movie movie)
        {
            return movie.production_studio == ProductionStudio.Pixar || movie.production_studio == ProductionStudio.Disney;
        }
    }
}