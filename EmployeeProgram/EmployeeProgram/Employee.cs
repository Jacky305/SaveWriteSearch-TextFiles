using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProgram
{
    [Serializable]
    class Employee
    {
        public string Name { get; set; }
        public int Num { get; set; }
        public double Salary { get; set; }
    }
}
