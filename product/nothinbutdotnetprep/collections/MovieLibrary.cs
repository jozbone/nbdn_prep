using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure;
using nothinbutdotnetprep.infrastructure.sorting;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            movies.Add(movie);
        }

        bool already_contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get { return movies.sort_using(Movie.SortByTitle()); }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            return movies.sort_using(Movie.SortByStudioAndYearPublished());
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            return movies.sort_using(new ReverseComparer<Movie>(new SortByDate()));
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get { return movies.sort_using(new ReverseComparer<Movie>(Movie.SortByTitle())); }
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            return movies.sort_using(Movie.SortByDate());
        }
    }
}