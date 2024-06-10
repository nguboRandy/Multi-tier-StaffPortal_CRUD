using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using DataLayer;


namespace BusinessLayer
{
    public class BusinessLogic
    {
        Data obj = new Data();


        public void SaveDataToFile(string name, string surname, string idNum)
        {
            string mail = name.Substring(0, 1);
            string age = CalculateAge(idNum);
            int birthYear = DateTime.Now.Year - int.Parse(age);
            

            string email = $"{mail.ToLower()}{surname.ToLower()}@uj.ac.za";
            string data = $"{name},{surname},{email}, {age}\n";
            Data.WriteToFile(data);
        } 



        public string GenerateEmail(string name, string surname)
        {
            string mail = name.Substring(0, 1);
            string email = $"{mail.ToLower()}{surname.ToLower()}@uj.ac.za";
            return email;
        }


        public string CalculateAge(string idNum)
        {          
            string birthDateStr = idNum.Substring(0, 6);            
            DateTime birthDate;
            if (!DateTime.TryParseExact(birthDateStr, "yyMMdd", null, System.Globalization.DateTimeStyles.None, out birthDate))
            {
                throw new ArgumentException("Invalid ID number format.");
            }            
            int age = CalculateAge(birthDate);           
            return age.ToString();

        }
        private int CalculateAge(DateTime birthDate)
        {
            
            int age = DateTime.Now.Year - birthDate.Year;

            
            if (DateTime.Now.Month < birthDate.Month || (DateTime.Now.Month == birthDate.Month && DateTime.Now.Day < birthDate.Day))
            {
                age--; 
            }

            return age;
        }



        public List<string> GetAllData()
        {
            List<string> data = obj.ReadFromFile();
            List<string> list = new List<string>();

            foreach (var item in data)
            {

                string[] word = item.Split(',');

                if (word.Length >= 4)
                {
                    
                    string formattedData = $"{word[0]} \t {word[1]} \t {word[2]} \t {word[3]}";
                    list.Add(formattedData);
                }
                else
                {
                    
                    Console.WriteLine($"Unexpected data format in line: {item}");
                }
            }

            return list;
        }
    }
}
