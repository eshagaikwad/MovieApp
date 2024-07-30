using MovieLibrary.ExceptionHandling;
using MovieLibrary.Services;

namespace MovieLibrary.Model
{
    public class MovieManager
    {
        public static List<Movie> list = new List<Movie>();
        public MovieManager()
        {
            list = SerialDesrial.DeserializeData();
        }

        public static string GenerateMovieId(string name, string genre, int release)
        {

            string id = name.Substring(0, 2) + genre.Substring(0, 2) + release.ToString().Substring(release.ToString().Length - 2);
            return id.ToUpper();
        }
        public static void CreateMovie()
        {
            if (list.Count >= 5)
            {
                throw new LimitReachedException("Maximum limit Reached. Cannot Add More Movies");
            }
            Console.WriteLine("Enter movie name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter movie genre");
            string description = Console.ReadLine();

            Console.WriteLine("Enter movie Release year");
            int date = int.Parse(Console.ReadLine());

            string id = GenerateMovieId(name, description, date);

            Movie newMovie = new Movie
            {
                Id = id,
                Name = name,
                Genre = description,
                Release = date
            };

            list.Add(newMovie);
            SerialDesrial.SerializeData(list);
        }
       
        public static void PrintDetails(Movie movie)
        {
            Console.WriteLine("Movie Id is: " + movie.Id);
            Console.WriteLine("Movie Name is: " + movie.Name);
            Console.WriteLine("Movie Genre is: " + movie.Genre);
            Console.WriteLine("Movie Release Date is: " + movie.Release);
            Console.WriteLine();
        }
        public static void DisplayMovie()
        {
            foreach (Movie movie in list)
            {
                PrintDetails(movie);
            }
        }


        public static void RemoveMovie()
        {
            Console.WriteLine("Enter movie Id:");
            string userInput = Console.ReadLine();

            bool movieFound = false;

            foreach (Movie item in list)
            {
                if (item.Id == userInput)
                {
                    list.Remove(item);
                    Console.WriteLine("Movie deleted successfully.");
                    SerialDesrial.SerializeData(list);
                    movieFound = true;
                    break; 
                }
            }
            if (!movieFound)
            {
                Console.WriteLine("Movie not found.");
            }
        }

        public static void ClearAll()
        { 
            list.Clear();
            Console.WriteLine("All movies Cleared");
        }
    }
}
