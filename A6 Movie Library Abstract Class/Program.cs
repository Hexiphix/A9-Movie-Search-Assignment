using A6_Movie_Library_Abstract_Class.Models;

namespace A6_Movie_Library_Abstract_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Media> media = new List<Media>();
            string _fileName;
            string choice;

            Console.WriteLine("Enter the number of the info you want");
            Console.WriteLine("1) Display Movies");
            Console.WriteLine("2) Display Shows");
            Console.WriteLine("3) Display Videos");
            Console.WriteLine("X) Quit");

            choice = Console.ReadLine();

            //Ensures the file is properly chosen
            _fileName = $"{Environment.CurrentDirectory}";

            if (choice == "1")
            {
                if (_fileName.Substring(_fileName.Length - 16, 16).Equals("bin\\Debug\\net6.0"))
                {
                    _fileName = _fileName.Remove(_fileName.Length - 16, 16);
                    _fileName = $"{_fileName}movies.csv";
                }
                else
                {
                    _fileName = $"{_fileName}\\movies.csv";
                }
            }
            else if (choice == "2")
            {
                if (_fileName.Substring(_fileName.Length - 16, 16).Equals("bin\\Debug\\net6.0"))
                {
                    _fileName = _fileName.Remove(_fileName.Length - 16, 16);
                    _fileName = $"{_fileName}shows.csv";
                }
                else
                {
                    _fileName = $"{_fileName}\\shows.csv";
                }
            }
            else if(choice == "3")
            {
                if (_fileName.Substring(_fileName.Length - 16, 16).Equals("bin\\Debug\\net6.0"))
                {
                    _fileName = _fileName.Remove(_fileName.Length - 16, 16);
                    _fileName = $"{_fileName}videos.csv";
                }
                else
                {
                    _fileName = $"{_fileName}\\videos.csv";
                }
            }

            // Attemps to read the given file
            try
            {
                int i = 0;
                StreamReader sr = new StreamReader(_fileName);
                // first line contains column headers
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    if (choice == "1")
                    {
                        media.Add(new Movie());
                        media[i].Read(line);
                    }
                    else if (choice == "2")
                    {
                        media.Add(new Show());
                        media[i].Read(line);
                    }
                    else if (choice == "3")
                    {
                        media.Add(new Video());
                        media[i].Read(line);
                    }

                    i++;
                }
                // close file when done
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            for (int i = 0; i < media.Count; i++)
            {
                media[i].Display();
            }
        }
    }
}