using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Managing_Employees.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employees> allEmployees;

        private XDocument dataEmployee;

        //Constructor
        public EmployeeRepository()
        {
            allEmployees = new List<Employees>();

            dataEmployee = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Employees.xml"));

            var employees = from Employees in dataEmployee.Descendants("Employee")
                           select new Employees((int)Employees.Element("ID"), Employees.Element("FIO").Value,
                           (DateTime)Employees.Element("Birthdate"), Employees.Element("Position").Value,
                           (decimal)Employees.Element("Salary"));
            allEmployees.AddRange(employees.ToList<Employees>());
        }
        //Delete Record
        public void DeleteEmployee(int id)
        {
            dataEmployee.Root.Elements("Employee").Where(i => (int)i.Element("ID") == id).Remove();

            dataEmployee.Save(HttpContext.Current.Server.MapPath("~/App_Data/Employees.xml"));
        }
        //Get Record By Id
        public Employees GetEmployeeById(int id)
        {
            return allEmployees.Find(emp => emp.ID == id);
        }
        //Get List Employees
        public IEnumerable<Employees> GetEmployees()
        {
            return allEmployees;
        }
        //Insert Record
        public void InsertEmployee(Employees employee)
        {
            employee.ID = (int)(from b in dataEmployee.Descendants("Employee") orderby (int)b.Element("ID") descending select (int)b.Element("ID")).FirstOrDefault() + 1;

            dataEmployee.Root.Add(new XElement("Employee", new XElement("ID", employee.ID), new XElement("FIO", employee.FIO),
                new XElement("Birthdate", employee.Birthdate.ToShortDateString()), new XElement("Position", employee.Position), new XElement("Salary", employee.Salary)
                ));

            dataEmployee.Save(HttpContext.Current.Server.MapPath("~/App_Data/Employees.xml"));
        }

        public void UpdateEmployee(Employees employee)
        {
            XElement node = dataEmployee.Root.Elements("Employee").Where(i => (int)i.Element("ID") == employee.ID).FirstOrDefault();

            node.SetElementValue("FIO", employee.FIO);
            node.SetElementValue("Birthdate", employee.Birthdate.ToShortDateString());
            node.SetElementValue("Position", employee.Position);
            node.SetElementValue("Salary", employee.Salary);
            

            dataEmployee.Save(HttpContext.Current.Server.MapPath("~/App_Data/Employees.xml"));
        }
    }
}