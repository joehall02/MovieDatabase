namespace MovieDatabase {
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Count() == 0)
            {
                // menu                    
                string prompt = "Welcome to the definitive Movie Database!\nPlease choose an option:";
                string[] options = { "List all movies", "Search for a movie", "Search by age rating", "Search by genre", "Search by runtime", "Search by date", "Add a movie", "Remove a movie", "Quit" };
                Menu mainMenu = new Menu(options, prompt);                    
                Console.ResetColor();
                
                while(true)
                {
                    // runs menu run function and stores returned index variable
                    int selectedIndex = mainMenu.Run();

                    // if selected index == n then call certain moviaDAO functions
            
                    switch (selectedIndex) {
                        // gets movie list
                        case 0:
                            MovieDAO.GetMovies();
                            Console.ReadLine();
                            break;
                        // searches for movie
                        case 1:
                            MovieDAO.SearchMovie();
                            Console.ReadLine();
                            break;
                        // searches based on age rating
                        case 2:
                            MovieDAO.SearchAgeRating();
                            Console.ReadLine();
                            break;
                        // searches based on genre
                        case 3:
                            MovieDAO.SearchGenre();
                            Console.ReadLine();
                            break;
                        // searches based on runtime
                        case 4:
                            MovieDAO.SearchRuntime();
                            Console.ReadLine();
                            break;
                        // searches based on year
                        case 5:
                            MovieDAO.SearchDate();
                            Console.ReadLine();
                            break;
                        // adds a movie
                        case 6:
                            MovieDAO.AddMovie();
                            Console.ReadLine();
                            break;
                        // removes a movie
                        case 7:
                            MovieDAO.RemoveMovie();
                            Console.ReadLine();
                            break;
                        // quits app
                        case 8:                            
                            // https://www.tutorialspoint.com/exit-methods-in-chash-application
                            Environment.Exit(0);                            
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
                    case "-list":
                        MovieDAO.GetMovies();
                        break;
                    // searches for movie
                    case "-search":
                        MovieDAO.SearchMovie();
                        break;
                    // searches for age rating
                    case "-age":
                        MovieDAO.SearchAgeRating();
                        break;
                    // searches for genre
                    case "-genre":
                        MovieDAO.SearchGenre();
                        break;
                    // searches for runtime
                    case "-runtime":
                        MovieDAO.SearchRuntime();
                        break;
                    // searches for date
                    case "-date":
                        MovieDAO.SearchDate();
                        break;
                    // add movie
                    case "-add":
                        MovieDAO.AddMovie();
                        break;
                    // remove movie
                    case "-remove":
                        MovieDAO.RemoveMovie();
                        break;
                    // help command
                    case "-help":
                        string[] commands = { "-list", "-search", "-age", "-genre", "-runtime", "-date", "-add", "-remove", "-help" };
                        Console.WriteLine("Movie Database Command List:");
                        foreach (string item in commands)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Unrecognised Command, try the '-help' command to see a list of available commands");
                        break;
                }
            }
        }
    }
}