using MovieLibrary.ExceptionHandling;
using MovieLibrary.Model;
using MovieLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieApp
{
    public class MovieStore
    {
        public static void UserMenuDriver()
        {
            Movie movie = new Movie();
            MovieManager manager = new MovieManager();
            while (true)
            {
                Console.WriteLine("Enter 1 to Add Movie\nEnter 2 to Display Movie\nEnter 3 to Delete Movie\nEnter 4 to clear\nEnter 5 to exit");
                int userInput = int.Parse(Console.ReadLine());
                try
                {
                    switch (userInput)
                    {
                        case 1:                       
                              MovieManager.CreateMovie();                               
                            break;

                        case 2:
                            MovieManager.DisplayMovie();
                            break;

                        case 3:
                            MovieManager.RemoveMovie();
                            break;

                        case 4:
                            MovieManager.ClearAll();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                    }
                }
                catch (LimitReachedException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Do you want to continue (yes/no)");
                string userStringInput=Console.ReadLine();

                if (userStringInput.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }


            }
        }
    }
}
