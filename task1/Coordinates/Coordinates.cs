using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CoordinatesLibrary
{
    public class Coordinates
    {
        private static bool IsCorrectInput(string[] array)
        {
            foreach (string s in array)
            {
                double tmp = 0;
                bool result = Double.TryParse(s.Replace('.', ','), out tmp);  // !
                if (!result) return false;
            }
            return true;
        }

        public static bool ReadFromFile(string path)
        {
            StreamReader sr = File.OpenText(path);

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                string[] fields = line.Split(',');

                if (!IsCorrectInput(fields))
                {
                    Console.WriteLine("Invalid input");
                    return false;
                }

                try
                {
                    Console.WriteLine(String.Format("X:{0} Y:{1}", fields[0].Replace('.', ','), fields[1].Replace('.', ',')));
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(string.Format("{0}", ex.Message));
                    return false;
                }

            }
            return true;
        }
    }
}
