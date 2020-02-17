using System;
using System.IO;

namespace JBATechTest
{
    class Program
    {
        /// <summary>
        /// Initialised Project
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var path = GetFilePath();
            var Filestring = ReadInFile(path);
        }
        /// <summary>
        /// Returns file path from user
        /// </summary>
        /// <returns></returns>
        private static string GetFilePath()
        {
            var fileExists = false;
            var path = string.Empty;
            while (!fileExists) {
                Console.WriteLine("Please enter Full Path:");
                path = Console.ReadLine();
                if (path != "")
                {
                    if (path.Contains("\\"))
                        path = Path.GetFullPath(path);
                    var directory = Environment.CurrentDirectory;
                    if (File.Exists(path))
                        fileExists = true;
                    else
                        Console.WriteLine("File Not Found,");
                }
                else//For Debugging
                {
                    path = "C:\\Users\\Alexander Lund\\source\repos\\JBATechTest\\DataFiles\\cru-ts-2-10.1991-2000-cutdown.pre";
                }
            }

            return path;
        }

        /// <summary>
        /// Reads in File 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string ReadInFile(string path)
        {

            return "";
        }
    }
}
