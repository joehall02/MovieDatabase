using System;
namespace MovieDatabase
{
    // inspiration for the menu https://www.youtube.com/watch?v=qAWhGEPMlS8
    public class Menu
    {
        // attributes
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;

        // constructor
        public Menu(string[] Options, string Prompt)
        {
            this.Options = Options;
            this.Prompt = Prompt;
            SelectedIndex = 0;
        }

        // methods
        // method to draw out the menu
        private void DrawMenu()
        {
            // https://stackoverflow.com/questions/2743260/is-it-possible-to-write-to-the-console-in-colour-in-net
            // Console.BackgroundColor = ConsoleColor.White;
            //Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;            
            Console.WriteLine(Prompt);
            Console.ResetColor();

            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string selectorArrow;

                if(i == SelectedIndex)
                {
                    selectorArrow = "> ";
                } else
                {
                    selectorArrow = " ";
                }

                // for every option passed it will output the option and add the selctor arrow to the
                // start of the selected item
                
                Console.WriteLine(selectorArrow + currentOption);
                

            }
        }

        public int Run()
        {
            // initialising keypress variable
            ConsoleKey KeyPress;
 
            do
            {
                // clears console everytime it runs, then redraws it
                Console.Clear();
                DrawMenu();

                // variable to hold key press
                KeyPress = Console.ReadKey(true).Key;

                // if up arrow is pressed then go up in the menu ,
                // if down arrow is pressed then go down in the menu
                if (KeyPress == ConsoleKey.UpArrow)
                {
                    SelectedIndex -= 1;
                    // checks to make sure the selector doesn't go out of bounds
                    if(SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }

                } else if (KeyPress == ConsoleKey.DownArrow){
                    SelectedIndex += 1;
                    if(SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
                // method does the above code until the enter key is pressed,
                // then it returns the selectedindex in order to determine what
                // Movie DAO function need to be called
            } while (KeyPress != ConsoleKey.Enter);

            return SelectedIndex;
        }

        
    }
}

