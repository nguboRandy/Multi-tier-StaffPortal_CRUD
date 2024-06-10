using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataLayer
{
    public class Data
    {
        private static readonly string staffFile = "staff.txt";

        public static void WriteToFile(string data)
        {
            try
            {
                File.AppendAllText(staffFile, data);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<string> ReadFromFile()
        {
            List<string> data = new List<string>();

            using(var read = new StreamReader(staffFile))
            {
                while (!read.EndOfStream)
                {
                    data.Add(read.ReadLine());

                }
                return data;
            }
        }
       

       
        

        
    }
}
