namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Open file");
            Console.WriteLine("2 - Create new file");
            Console.WriteLine("0 - Exit");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    Open();
                    break;
                case 2:
                    Edit();
                    break;
                default:
                    Menu();
                    break;
            }
        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Type the file path:");
            string path = Console.ReadLine();

            try
            {
                string text = File.ReadAllText(path);
                Console.WriteLine("File content:");
                Console.WriteLine(text);
            }
            catch
            {
                Console.WriteLine("This file could not be opened.");
            }
        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Type your text below (Down Arrow to exit):");
            Console.WriteLine("---------------------");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            } while (Console.ReadKey().Key != ConsoleKey.DownArrow);

            Save(text);
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("What is the file path?");
            var path = Console.ReadLine();

            try
            {
                using (var file = new StreamWriter(path))
                {
                    file.Write(text);
                }

                Console.WriteLine($"File {path} saved successfully!");
            }
            catch
            {
                Console.WriteLine("It was not possible to save the file.");
            }
            Menu();
        }
    }
}
