using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure;

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
            get
            {
                ((List<Movie>) movies).Sort(new Comparison<Movie>(Movie.SortByTitle));

                foreach (var movie in movies)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            ((List<Movie>) movies).Sort(new Comparison<Movie>(Movie.SortByStudioAndYearPublished));

            foreach (var movie in movies)
                yield return movie;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            ((List<Movie>) movies).Sort(new Comparison<Movie>(Movie.SortByDate));

            for (var i = movies.Count; i > 0; i--)
                yield return movies[i - 1];
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                ((List<Movie>) movies).Sort(new Comparison<Movie>(Movie.SortByTitle));

                for (var i = movies.Count; i > 0; i--)
                    yield return movies[i - 1];
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            ((List<Movie>) movies).Sort(new Comparison<Movie>(Movie.SortByDate));

            foreach (var movie in movies)
                yield return movie;
        }
    }
}