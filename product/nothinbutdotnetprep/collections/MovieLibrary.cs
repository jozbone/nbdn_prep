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

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return all_movies_matching(is_published_by_pixar);
        }

        public MovieFilterCondition create()
        {
            var item = "blah";
            return delegate(Movie movie)
            {
                Console.Out.WriteLine(item);
                return false;
            };
        }

        bool is_published_by_pixar(Movie movie)
        {
            return movie.production_studio == ProductionStudio.Pixar;
        }

        public delegate bool MovieFilterCondition(Movie movie);

        IEnumerable<Movie> all_movies_matching(MovieFilterCondition movie_filter_condition)
        {
            foreach (var movie in movies)
            {
                if (movie_filter_condition(movie)) yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio.Equals(ProductionStudio.Pixar) ||
                    movie.production_studio.Equals(ProductionStudio.Disney))
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            foreach (var movie in movies)
            {
                if (movie.genre == Genre.kids)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            foreach (var movie in movies)
            {
                if (movie.date_published > new DateTime(year, 01, 01))
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            foreach (var movie in movies)
            {
                if (!movie.production_studio.Equals(ProductionStudio.Pixar))
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            foreach (var movie in movies)
            {
                if (movie.date_published >= new DateTime(startingYear, 01, 01) &&
                    movie.date_published <= new DateTime(endingYear, 01, 01))
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_action_movies()
        {
            foreach (var movie in movies)
            {
                if (movie.genre == Genre.action)
                    yield return movie;
            }
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