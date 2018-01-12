using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace EmployeeProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            const int END = 999;
            const string FILENAME = "Data.txt";

            Employee emp = new Employee();
            BinaryFormatter bFormatter = new BinaryFormatter();

            int response = 0;
            Console.WriteLine("Enter 1 to write data >> \nEnter 2 to read data >>");
            response = Convert.ToInt32(Console.ReadLine());

            if (response == 1)
            {
                FileStream outFile = new FileStream(FILENAME, FileMode.OpenOrCreate, FileAccess.Write);
                Console.WriteLine("Enter employee number or " + END + " to quit >> ");

                emp.Num = Convert.ToInt32(Console.ReadLine());
                while (emp.Num != END)
                {
                    Console.WriteLine("Enter first name >> ");
                    emp.Name = Console.ReadLine();
                    Console.WriteLine("Enter Salary >> ");
                    emp.Salary = Convert.ToDouble(Console.ReadLine());
                    bFormatter.Serialize(outFile, emp);

                    Console.WriteLine("Enter employee number or " + END + " to quit >> ");
                    emp.Num = Convert.ToInt32(Console.ReadLine());
                }
                outFile.Close();
            }
            else if (response == 2)
            {
                FileStream inFile = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
                Console.WriteLine("\n{0,-5}{1,-12}{2,8}\n", "Num", "Name", "Salary");

                while(inFile.Position < inFile.Length)
                {
                    emp = (Employee)bFormatter.Deserialize(inFile);
                    Console.WriteLine("{0,-5}{1,-12}{2,8}", emp.Num, emp.Name, emp.Salary.ToString("C"));
                }
                inFile.Close();
            }
            
        }
    }
}
