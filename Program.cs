namespace MovieDatabase {
    public class Program
    {
        public static void Main()
        {
            while(true)
            {

                Console.WriteLine("Hello lrdfhsjknvxz.");
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
    }
}