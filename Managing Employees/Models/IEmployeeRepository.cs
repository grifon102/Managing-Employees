using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managing_Employees.Models
{
    interface IEmployeeRepository
    {
        IEnumerable<Employees> GetEmployees();

        Employees GetEmployeeById(int id);

        void InsertEmployee(Employees employee);

        void DeleteEmployee(int id);

        void UpdateEmployee(Employees employee);
    }
}
