using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using JBATechTest.DAL;

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
            var rainData = ReadInFile(path);
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
                    path = "C:\\Users\\Alexander Lund\\source\\repos\\JBATechTest\\DataFiles\\cru-ts-2-10.1991-2000-cutdown.pre";
                    fileExists = true;
                }
            }

            return path;
        }

        /// <summary>
        /// Reads in File and returns a list of rainData Objects
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static List<RainData> ReadInFile(string path)
        {

            string[] lines = File.ReadAllLines(path);
            List<RainData> rainDataList = new List<RainData>();

            var yearStart = 0;
            var numOfYears = 0;
            var headerIndex = -1;
            //reads in header data, assumes header ends at fists grid-ref
            foreach (var line in lines.Select((value, i) => (value, i)))
            {
                int j = -1;
                
                if (yearStart == 0&& (j = line.value.IndexOf("Years=")) != -1)
                {
                    yearStart = int.Parse(line.value.Substring(j + 6, 4));
                    numOfYears = int.Parse(line.value.Substring(j + 11, 4))- yearStart+1;
                }
                else if(line.value.IndexOf("Grid-ref") != -1)
                {
                    headerIndex = line.i;
                    break;
                }
                Console.WriteLine("\t" + line.value);
            }

            //splits data into grid chunks
            var i = headerIndex;
            var data = new List<string>();
            while (i< lines.Length)
            {
                var grid = lines.Skip(i).Take(1).First();
                data.Add(grid+"|"+String.Join(" ", lines.Skip(i+1).Take(numOfYears)));
                i += numOfYears + 1;
            }

            //reads through data concurrently and turns each month into rainData objects
            var bag = new ConcurrentBag<RainData>();
            Parallel.ForEach(data, item =>
             {
                 var grid = item.Split('|')[0].Substring(11).Split(',');
                 var xref = int.Parse(grid[0]);
                 var yref = int.Parse(grid[1]);
                 var rainData = item.Split('|')[1].Split(' ');
                 var date = new DateTime(yearStart, 1, 1);

                 foreach (var month in rainData) {
                     if (month != "")
                     {
                         bag.Add(new RainData()
                         {
                             Value = int.Parse(month),
                             Date = date,
                             XRef = xref,
                             YRef = yref,
                         });
                         date=date.AddMonths(1);
                     }
                 }

             });

            //orders data and returns a list of raindata objects
            rainDataList = bag.OrderBy(d=>d.Date).ToList();
            return rainDataList;
        }
    }
}
