using System;

namespace nothinbutdotnetprep.collections
{
    public class Movie : IComparable
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }


        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

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
    }
}