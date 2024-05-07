namespace DZBufPotoki
{
    internal class Program
    {
        static void SearchAndPrint(DirectoryInfo dir, string extension, string word) 
        {
            var path = dir.FullName;
            foreach (var file in dir.EnumerateFiles()) 
            {
                if (extension == file.Extension)
                {
                    string line;
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (!sr.EndOfStream)
                        {
                          line = sr.ReadLine() ?? "Null";
                            if (line.Contains(word)) 
                            {
                                Console.WriteLine(line);
                            }

                        }
                    }
                
                }
            }
            foreach (var directory in dir.EnumerateDirectories())
            {
                SearchAndPrint(directory, extension ,word);
            }
        }
       
    
        static void Main(string[] args)
        {
            //Объедините две предыдущих работы (практические работы 2 и 3):
            //поиск файла и поиск текста в файле написав утилиту которая ищет файлы определенного
            //расширения с указанным текстом. Рекурсивно. Пример вызова утилиты: utility.exe txt текст.

            string path = @"C:\Users\User\OneDrive\Desktop\CV";
            string extension = ".txt";
            string word = "Boo";

            DirectoryInfo dir = new DirectoryInfo(path);

              SearchAndPrint(dir ,extension ,word );

        }


    }
}
