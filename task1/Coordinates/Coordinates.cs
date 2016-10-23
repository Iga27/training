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
        private string result;
        private bool IsCorrectInput(string[] array)
        {
            foreach (string s in array)
            {
                double tmp = 0;
                bool result = Double.TryParse(s.Replace('.', ','), out tmp);  // !
                if (!result) 
                    return false;
            }
            return true;
        }
        /// <summary>
        /// gets coordinates from input file and formates them in correct view
        /// </summary>
        /// <param name="path">the path to input file </param>
        ///<exception cref="System.IndexOutOfRangeException">throwing when goes out of range of string array</exception>
        ///<remarks>uses private method IsCorrectInput()</remarks>
        public  bool FormatInput(string path)
        {
            StreamReader sr = File.OpenText(path);

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                string[] fields = line.Split(',');

                if (!IsCorrectInput(fields))
                {
                    return false;
                }
                   result+=String.Format("X:{0} Y:{1}", fields[0].Replace('.', ','), fields[1].Replace('.', ','))+'\n';
            }
            return true;
        }
        public override string ToString()
        {
            return result;
        }
    }
}
