using System;
namespace MovieDatabase
{

    public class MovieDAO
    {
        
        // changed from list to dictionary to allow searching
        private static Dictionary<string, Movie> Movies = new Dictionary<string, Movie>();
       

        public static void GetMovieData()
        {
            // clears movie dictionary on rerun 
            Movies.Clear();

            // path of data file
            string[] data = File.ReadAllLines("data.txt");

            // for every line in the data file it will split up every part of the line and create a movie object from it
            foreach (string line in data)
            {
                // used this video to figure out how to split up strings in a text file https://www.youtube.com/watch?v=PJnejyvH9Dc&ab_channel=LearnCoding
                string[] movieData = line.Split("::");

                // Used this link to learn about the timespan object https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-timespan-format-strings
                Movies.Add(movieData[0].ToLower(), new Movie(movieData[0], movieData[1], movieData[2],
                new TimeSpan(Int32.Parse(movieData[3]), Int32.Parse(movieData[4]), 00),
                new DateTime(Int32.Parse(movieData[5]), Int32.Parse(movieData[6]), Int32.Parse(movieData[7])) ));
            }
        }

        private static void Layout()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0, -33} | {1, -10} | {2, -10} | {3, -10} | {4, -10}", "Name", "Age Rating", "Genre", "Runtime", "Date Released"));
            Console.WriteLine("------------------------------------------------------------------------------------------");
        }

        // method to get the list of movies in the database 
        public static void GetMovies()
        {
            // calls function to get movie data from data.txt and add them to the list
            GetMovieData();
            Console.Clear();

            Layout();
            foreach (KeyValuePair<string, Movie> movie in Movies)
            {              
                // used this resource for string formatting https://www.csharp-examples.net/align-string-with-spaces/
                Console.WriteLine(String.Format("{0, -33} | {1, -10} | {2, -10} | {3, -10} | {4, -10}", movie.Value.GetName(), movie.Value.GetAgeRating(), movie.Value.GetGenre(), movie.Value.GetRuntime().Hours + "hrs " + movie.Value.GetRuntime().Minutes + "m", movie.Value.GetDateOfRelease().Day + "/" + movie.Value.GetDateOfRelease().Month + "/" + movie.Value.GetDateOfRelease().Year));                
            }            
        }

        // method to search film
        public static void SearchMovie()
        {
            // clears console and gets movie data
            Console.Clear();
            GetMovieData();

            // asks for movie then stores in a variable
            Console.WriteLine("What is the name of the movie you want to find?");
            string searchName = Console.ReadLine().ToLower();

            Console.Clear();
            // checks if the dictionary contains the searched film and if it does it displays the information for that film
            if(Movies.ContainsKey(searchName))
            {
                Layout();
                Console.WriteLine(String.Format("{0, -33} | {1, -10} | {2, -10} | {3, -10} | {4, -10}", Movies[searchName].GetName(), Movies[searchName].GetAgeRating(), Movies[searchName].GetGenre(), Movies[searchName].GetRuntime().Hours + "hrs " + Movies[searchName].GetRuntime().Minutes + "m", Movies[searchName].GetDateOfRelease().Day + "/" + Movies[searchName].GetDateOfRelease().Month + "/" + Movies[searchName].GetDateOfRelease().Year));
            } else
            {
                Console.WriteLine("Sorry, that film is not in our database");
            }

        }

        // method to search films with specific age ratings
        public static void SearchAgeRating()
        {
            Console.Clear();
            GetMovieData();

            Console.WriteLine("What is the age rating of the films you want to see?");
            string searchAge = Console.ReadLine();

            Console.Clear();
            Layout();

            // loops through collection to check for films with the inputted age rating
            // going to change to a list of age rating 
            foreach (KeyValuePair<string, Movie> movie in Movies)
            {
                if (movie.Value.GetAgeRating() == searchAge)
                {
                    Console.WriteLine(String.Format("{0, -33} | {1, -10} | {2, -10} | {3, -10} | {4, -10}", movie.Value.GetName(), movie.Value.GetAgeRating(), movie.Value.GetGenre(), movie.Value.GetRuntime().Hours + "hrs " + movie.Value.GetRuntime().Minutes + "m", movie.Value.GetDateOfRelease().Day + "/" + movie.Value.GetDateOfRelease().Month + "/" + movie.Value.GetDateOfRelease().Year));
                }
               
            }
        }

        // method to search films with specific genre
        public static void SearchGenre()
        {
            Console.Clear();
            GetMovieData();

            Console.WriteLine("What is the genre of the film you're looking for?");
            string searchGenre = Console.ReadLine();

            Console.Clear();
            Layout();

            foreach (KeyValuePair<string, Movie> movie in Movies)
            {
                if (movie.Value.GetGenre() == searchGenre)
                {
                    Console.WriteLine(String.Format("{0, -33} | {1, -10} | {2, -10} | {3, -10} | {4, -10}", movie.Value.GetName(), movie.Value.GetAgeRating(), movie.Value.GetGenre(), movie.Value.GetRuntime().Hours + "hrs " + movie.Value.GetRuntime().Minutes + "m", movie.Value.GetDateOfRelease().Day + "/" + movie.Value.GetDateOfRelease().Month + "/" + movie.Value.GetDateOfRelease().Year));
                }
            }
        }

        // method to search films with specific runtime
        public static void SearchRuntime()
        {
            Console.Clear();
            GetMovieData();

            Console.WriteLine("How many hours long is the film you want to watch?");
            string searchRuntime = Console.ReadLine();

            Console.Clear();
            Layout();

            foreach (KeyValuePair<string, Movie> movie in Movies)
            {
                if (movie.Value.GetRuntime().Hours == Int32.Parse(searchRuntime))
                {
                    Console.WriteLine(String.Format("{0, -33} | {1, -10} | {2, -10} | {3, -10} | {4, -10}", movie.Value.GetName(), movie.Value.GetAgeRating(), movie.Value.GetGenre(), movie.Value.GetRuntime().Hours + "hrs " + movie.Value.GetRuntime().Minutes + "m", movie.Value.GetDateOfRelease().Day + "/" + movie.Value.GetDateOfRelease().Month + "/" + movie.Value.GetDateOfRelease().Year));
                }
            }
        }

        public static void SearchDate()
        {
            Console.Clear();
            GetMovieData();

            Console.WriteLine("What is the year of release of the film you're looking for?");
            string searchYear = Console.ReadLine();

            Console.Clear();
            Layout();

            foreach (KeyValuePair<string, Movie> movie in Movies)
            {
                if (movie.Value.GetDateOfRelease().Year == Int32.Parse(searchYear))
                {
                    Console.WriteLine(String.Format("{0, -33} | {1, -10} | {2, -10} | {3, -10} | {4, -10}", movie.Value.GetName(), movie.Value.GetAgeRating(), movie.Value.GetGenre(), movie.Value.GetRuntime().Hours + "hrs " + movie.Value.GetRuntime().Minutes + "m", movie.Value.GetDateOfRelease().Day + "/" + movie.Value.GetDateOfRelease().Month + "/" + movie.Value.GetDateOfRelease().Year));
                }
            }
        }

        // method to add movie to the data file
        public static void AddMovie()
        {
            Console.Clear();
            Console.WriteLine("Name of the movie:");
            string name = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Age rating:");
            string ageRating = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Genre:");
            string genre = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Hours:");
            int hours = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Minutes:");
            int minutes = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Year of release:");
            int year = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Month:");
            int month = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Day:");
            int day = Int32.Parse(Console.ReadLine());

            string newMovie = name + "::" + ageRating + "::" + genre + "::" +
            hours + "::" + minutes + "::" + year + "::" + month + "::" + day;

            // adds new movie to the data file
            File.AppendAllText("data.txt", newMovie + Environment.NewLine);
        }

        private static void UpdateData()
        {
            // removes all the contents from the data file
            File.WriteAllText("data.txt", "");

            foreach (KeyValuePair<string, Movie> movie in Movies)
            {
                File.AppendAllText("data.txt", movie.Value.GetName() + "::" + movie.Value.GetAgeRating() + "::" + movie.Value.GetGenre() +
                    "::" + movie.Value.GetRuntime().Hours + "::" + movie.Value.GetRuntime().Minutes + "::" + movie.Value.GetDateOfRelease().Year
                    + "::" + movie.Value.GetDateOfRelease().Month + "::" + movie.Value.GetDateOfRelease().Day + Environment.NewLine);
            }
        }

        public static void RemoveMovie()
        {
            Console.Clear();
            GetMovieData();

            Console.WriteLine("What film do you want to remove?");
            string movieToRemove = Console.ReadLine().ToLower();

            // checks if the movies dictionary contains the inputted movie
            // if it does then it gets removed from the movie collection

            if(Movies.ContainsKey(movieToRemove))
            {
                Movies.Remove(movieToRemove);
                UpdateData();
            } else
            {
                Console.WriteLine("That movie isn't in the database");
            }
        }
    }
}

