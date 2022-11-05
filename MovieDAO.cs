using System;
namespace MovieDatabase
{

    public class MovieDAO
    {
        
        // changed from list to dictionary to allow searching
        private static Dictionary<string, Movie> Movies = new Dictionary<string, Movie>();
       

        private static void GetMovieData()
        {
            // clears movie dictionary on rerun 
            Movies.Clear();

            // NEEDS SORTING
            if (File.Exists("data.txt"))
            {
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
            } else
            {
                string prompt = "Data file not found, would you like to create one?";
                string[] options = { "Yes", "No" };

                Menu fileNotFoundMemu = new Menu(options, prompt);
                int selectedIndex = fileNotFoundMemu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        File.Create("data.txt");
                        
                        Console.WriteLine("New data file created!\nPress any key to continue");
                        Console.ReadLine();
                        break;
                    case 1:
                        Console.WriteLine("Terminating program");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }

        }

        private static void Layout()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(String.Format("{0, -33} | {1, -10} | {2, -10} | {3, -10} | {4, -10}", "Name", "Age Rating", "Genre", "Runtime", "Date Released  "));
            Console.ResetColor();
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
                Console.WriteLine(String.Format("{0, -33} | {1, -10} | {2, -10} | {3, -10} | {4, -10}", movie.Value.GetName(), movie.Value.GetAgeRating(), movie.Value.GetGenre(),
                movie.Value.GetRuntime().Hours + "hrs " + movie.Value.GetRuntime().Minutes + "m", movie.Value.GetDateOfRelease().Day + "/" + movie.Value.GetDateOfRelease().Month + "/" + movie.Value.GetDateOfRelease().Year));                
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
                Console.WriteLine(String.Format("{0, -33} | {1, -10} | {2, -10} | {3, -10} | {4, -10}", Movies[searchName].GetName(), Movies[searchName].GetAgeRating(), Movies[searchName].GetGenre(),
                Movies[searchName].GetRuntime().Hours + "hrs " + Movies[searchName].GetRuntime().Minutes + "m", Movies[searchName].GetDateOfRelease().Day + "/" + Movies[searchName].GetDateOfRelease().Month + "/" + Movies[searchName].GetDateOfRelease().Year));
            } else
            {
                Console.WriteLine("Unfortunately, that film is not in our database");
            }

        }

        // method to search films with specific age ratings
        public static void SearchAgeRating()
        {
            Console.Clear();
            GetMovieData();

            string searchAge = "";
               
            // creating new instance of menu class to search for age rating 
            string prompt = "Choose age rating:";
            string[] options = { "U", "PG", "12", "12A", "15", "18" };
            Menu ageRatingMenu = new Menu(options, prompt);

            int selectedIndex = ageRatingMenu.Run();

            // sets the searchAge variable to the selected menu option
            switch(selectedIndex)
            {
                case 0:
                    searchAge = options[0];
                    break;
                case 1:
                    searchAge = options[1];
                    break;
                case 2:
                    searchAge = options[2];
                    break;
                case 3:
                    searchAge = options[3];
                    break;
                case 4:
                    searchAge = options[4];
                    break;
                case 5:
                    searchAge = options[5];
                    break;
            }

            Console.Clear();
            Layout();

            // loops through collection to check for films with the inputted age rating            
            foreach (KeyValuePair<string, Movie> movie in Movies)
            {
                if (movie.Value.GetAgeRating() == searchAge)
                {
                    Console.WriteLine(String.Format("{0, -33} | {1, -10} | {2, -10} | {3, -10} | {4, -10}", movie.Value.GetName(), movie.Value.GetAgeRating(), movie.Value.GetGenre(),
                    movie.Value.GetRuntime().Hours + "hrs " + movie.Value.GetRuntime().Minutes + "m", movie.Value.GetDateOfRelease().Day + "/" + movie.Value.GetDateOfRelease().Month + "/" + movie.Value.GetDateOfRelease().Year));
                }
               
            }
        }

        // method to search films with specific genre
        public static void SearchGenre()
        {
            Console.Clear();
            GetMovieData();

            Console.WriteLine("What is the genre of the film you're looking for?");
            string searchGenre = "";

            string prompt = "Choose a genre:";
            string[] options = { "Action", "Adventure", "Animation", "Biography", "Crime", "Drama", "Horror", "Sci-Fi", "War" };
            Menu genreMenu = new Menu(options, prompt);

            int selectedIndex = genreMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    searchGenre = options[0];
                    break;
                case 1:
                    searchGenre = options[1];
                    break;
                case 2:
                    searchGenre = options[2];
                    break;
                case 3:
                    searchGenre = options[3];
                    break;
                case 4:
                    searchGenre = options[4];
                    break;
                case 5:
                    searchGenre = options[5];
                    break;
                case 6:
                    searchGenre = options[6];
                    break;
                case 7:
                    searchGenre = options[7];
                    break;
                case 8:
                    searchGenre = options[8];
                    break;
            }

            Console.Clear();
            Layout();

            foreach (KeyValuePair<string, Movie> movie in Movies)
            {
                if (movie.Value.GetGenre() == searchGenre)
                {
                    Console.WriteLine(String.Format("{0, -33} | {1, -10} | {2, -10} | {3, -10} | {4, -10}", movie.Value.GetName(), movie.Value.GetAgeRating(), movie.Value.GetGenre(),
                    movie.Value.GetRuntime().Hours + "hrs " + movie.Value.GetRuntime().Minutes + "m", movie.Value.GetDateOfRelease().Day + "/" + movie.Value.GetDateOfRelease().Month + "/" + movie.Value.GetDateOfRelease().Year));
                }
            }
        }

        // method to search films with specific runtime
        public static void SearchRuntime()
        {
            Console.Clear();
            GetMovieData();

            Console.WriteLine("How many hours long is the film you want to watch?");
            string searchRuntime = "";

            string prompt = "Choose a runtime:";
            string[] options = { "0-1 Hours", "1-2 Hours", "2-3 Hours", "3-4 Hours" };
            Menu runtimeMenu = new Menu(options, prompt);
            int selectedIndex = runtimeMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    searchRuntime = "0";
                    break;
                case 1:
                    searchRuntime = "1";
                    break;
                case 2:
                    searchRuntime = "2";
                    break;
                case 3:
                    searchRuntime = "3";
                    break;
            }

            Console.Clear();
            Layout();

            foreach (KeyValuePair<string, Movie> movie in Movies)
            {
                if (movie.Value.GetRuntime().Hours == Int32.Parse(searchRuntime))
                {
                    Console.WriteLine(String.Format("{0, -33} | {1, -10} | {2, -10} | {3, -10} | {4, -10}", movie.Value.GetName(), movie.Value.GetAgeRating(), movie.Value.GetGenre(),
                    movie.Value.GetRuntime().Hours + "hrs " + movie.Value.GetRuntime().Minutes + "m", movie.Value.GetDateOfRelease().Day + "/" + movie.Value.GetDateOfRelease().Month + "/" + movie.Value.GetDateOfRelease().Year));
                }
            }
        }

        public static void SearchDate()
        {
            Console.Clear();
            GetMovieData();

            Console.WriteLine("What is the year of release of the film you're looking for?");
            string searchYear = Console.ReadLine();

            if (searchYear.Length == 4)
            {
                Console.Clear();
                Layout();

                foreach (KeyValuePair<string, Movie> movie in Movies)
                {
                    if (movie.Value.GetDateOfRelease().Year == Int32.Parse(searchYear))
                    {
                        Console.WriteLine(String.Format("{0, -33} | {1, -10} | {2, -10} | {3, -10} | {4, -10}", movie.Value.GetName(), movie.Value.GetAgeRating(), movie.Value.GetGenre(),
                        movie.Value.GetRuntime().Hours + "hrs " + movie.Value.GetRuntime().Minutes + "m", movie.Value.GetDateOfRelease().Day + "/" + movie.Value.GetDateOfRelease().Month + "/" + movie.Value.GetDateOfRelease().Year));
                    }
                }
            } else
            {
                Console.WriteLine("The date you entered was invalid");
            }

        }

        // method to add movie to the data file
        public static void AddMovie()
        {
            Console.Clear();
                
            Console.WriteLine("Name of the movie:");
            string name = Console.ReadLine();
            if (name.Length > 0)
            {
                Console.WriteLine();

                Console.WriteLine("Age rating:");
                string ageRating = Console.ReadLine();
                string[] ageRatings = { "U", "PG", "12", "12A", "15", "18" };

                // checks to make sure the user enters a valid age rating
                if (ageRatings.Contains(ageRating))
                {
                    Console.WriteLine();

                    Console.WriteLine("Genre:");
                    string genre = Console.ReadLine();
                    string[] genres = { "Action", "Adventure", "Animation", "Biography", "Crime", "Drama", "Horror", "Sci-Fi", "War" };

                    // checks to make sure the user enters a valid genre
                    if (genres.Contains(genre))
                    {
                        Console.WriteLine();

                        Console.WriteLine("Hours:");

                        int hours = 0;
                        // checks to make sure the user inputs an int
                        try
                        {
                            hours = Int32.Parse(Console.ReadLine());

                        }
                        catch (System.FormatException)
                        {
                            Console.WriteLine("The value you entered was not a number, try again");
                            return;

                        }
                        // checks to make sure the hour is less than 24, due to using timespan object
                        if (hours <= 24)
                        {
                            Console.WriteLine();

                            Console.WriteLine("Minutes:");

                            int minutes = 0;
                            try
                            {
                                minutes = Int32.Parse(Console.ReadLine());
                            }
                            catch (System.FormatException)
                            {
                                Console.WriteLine("The value you entered was not a number, try again");
                                return;
                            }
                            // checks to make sure inputted minutes is less than 60
                            if (minutes > 0 && minutes < 60)
                            {
                                Console.WriteLine();

                                Console.WriteLine("Year of release:");
                                int year = 0000;
                                try
                                {
                                    year = Int32.Parse(Console.ReadLine());
                                }
                                catch (System.FormatException)
                                {
                                    Console.WriteLine("The value you entered for not a number, try again");
                                    return;
                                }
                                // checks to make sure the year is valid, year has to be after the first ever film made
                                // and <= the current year
                                if (year > 1888 && year <= DateTime.Now.Year)
                                {
                                    Console.WriteLine();

                                    Console.WriteLine("Month(Number):");
                                    int month = 0;
                                    try
                                    {
                                        month = Int32.Parse(Console.ReadLine());
                                    }
                                    catch (System.FormatException)
                                    {
                                        Console.WriteLine("Sorry, the value you entered was not valid, make sure you enter the month number");
                                        return;
                                    }
                                    // check to make sure the inputted month is 1-12
                                    if (month > 0 && month <= 12)
                                    {

                                        Console.WriteLine();

                                        Console.WriteLine("Day:");
                                        int day = 0;
                                        try
                                        {
                                            day = Int32.Parse(Console.ReadLine());
                                        }
                                        catch (System.FormatException)
                                        {
                                            Console.WriteLine("The value you entered was not a number, try again");
                                        }
                                        // checks to make sure the inputted day is accurate
                                        if (day > 0 && day <= 31)
                                        {
                                            string newMovie = name + "::" + ageRating + "::" + genre + "::" +
                                            hours + "::" + minutes + "::" + year + "::" + month + "::" + day;

                                            // adds new movie to the data file
                                            File.AppendAllText("data.txt", newMovie + Environment.NewLine);

                                            Console.WriteLine("Movie added successfully");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Sorry, the day you entered was not valid, try again");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sorry, the month you entered was not valid, try again");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, the year you entered was not valid, try again");
                                }

                            }
                            else
                            {
                                Console.WriteLine("Sorry, the value you entered was not valid, try again");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry, the length of the movie is too long, try again");
                        }
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid genre, try again");
                    }
                }
                else
                {
                    Console.WriteLine("That is not a valid age rating, try again");
                }
            }
            else
            {
                Console.WriteLine("You didn't enter a name, try again.");
            }            
        }

        private static void UpdateData()
        {
            // removes all the contents from the data file
            File.WriteAllText("data.txt", "");

            // adds each movie from the movies list back to the data file
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
            Console.Clear();
            if(Movies.ContainsKey(movieToRemove))
            {
                Movies.Remove(movieToRemove);
                UpdateData();
                Console.WriteLine("Movie removed successfully");
            } else
            {
                Console.WriteLine("Unfotunately, that movie isn't in the database");
            }
        }
    }
}

