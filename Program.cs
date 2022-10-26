namespace MovieDatabase {
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Count() == 0)
            {
                while(true)
                {
                    // menu
                    string prompt = "pick an option";
                    string[] options = { "List all movies", "Search for a movie", "Search by age range", "Search by genre", "Search by runtime", "Search by date", "Add a movie", "Remove a movie" };
                    Menu mainMenu = new Menu(options, prompt);

                    int selectedIndex = mainMenu.Run();

                    // if selected index == n then call certain moviaDAO options
            
                    switch (selectedIndex) {
                        // gets movie list
                        case 0:
                            MovieDAO.GetMovies();
                            Console.Read();
                            break;
                        // searches for movie
                        case 1:
                            MovieDAO.SearchMovie();
                            Console.Read();
                            break;
                        // searches based on age rating
                        case 2:
                            MovieDAO.SearchAgeRating();
                            Console.Read();
                            break;
                        // searches based on genre
                        case 3:
                            MovieDAO.SearchGenre();
                            Console.Read();
                            break;
                        // searches based on runtime
                        case 4:
                            MovieDAO.SearchRuntime();
                            Console.Read();
                            break;
                        // searches based on year
                        case 5:
                            MovieDAO.SearchDate();
                            Console.Read();
                            break;
                        // adds a movie
                        case 6:
                            MovieDAO.AddMovie();
                            break;
                        // removes a movie
                        case 7:
                            MovieDAO.RemoveMovie();
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }
                } 
            }
            // only runs the else statement if given command line arguments
            else
            {

                switch(args[0])
                {
                    // gets movie list
                    case "list":
                        MovieDAO.GetMovies();
                        break;
                    // searches for movie
                    case "search":
                        MovieDAO.SearchMovie();
                        break;
                    // searches for age rating
                    case "age":
                        MovieDAO.SearchAgeRating();
                        break;
                    // searches for genre
                    case "genre":
                        MovieDAO.SearchGenre();
                        break;
                    // searches for runtime
                    case "runtime":
                        MovieDAO.SearchRuntime();
                        break;
                    // searches for date
                    case "date":
                        MovieDAO.SearchDate();
                        break;
                    // add movie
                    case "add":
                        MovieDAO.AddMovie();
                        break;
                    // remove movie
                    case "remove":
                        MovieDAO.RemoveMovie();
                        break;
                    // help command
                    case "help":
                        string[] commands = { "list", "search", "age", "genre", "runtime", "date", "add", "remove" };
                        Console.WriteLine("Commands:");
                        foreach (string item in commands)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Unrecognised Command, try the 'help' command to see a list of available commands");
                        break;
                }
            }
        }
    }
}