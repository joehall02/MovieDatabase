using System;
namespace MovieDatabase
{
    public class Movie
    {
        // attributes
        private string Name;
        private string AgeRating;
        private string Genre;
        private TimeSpan Runtime;
        private DateTime DateOfRelease;

        // constructor
        public Movie(string Name, string AgeRating, string Genre, TimeSpan Runtime, DateTime DateOfRelease)
        {
            this.Name = Name;
            this.AgeRating = AgeRating;
            this.Genre = Genre;
            this.Runtime = Runtime;
            this.DateOfRelease = DateOfRelease;
        }

        // getter methods
        public string GetName()
        {
            return Name;
        }

        public string GetAgeRating()
        {
            return AgeRating;
        }

        public string GetGenre()
        {
            return Genre;
        }

        public TimeSpan GetRuntime()
        {
            // returns timespan object as a formatted string
            // return Runtime.Hours + "hrs " + Runtime.Minutes + "m";
            return Runtime;
        }

        public DateTime GetDateOfRelease()
        {
            // returns without the time 
            // return DateOfRelease.Date.ToString("d");
            return DateOfRelease;
        }
    }
}

