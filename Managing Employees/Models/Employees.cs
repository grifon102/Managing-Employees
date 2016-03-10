using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Managing_Employees.Models
{
    public class Employees
    {
        public Employees()
        {
            this.ID = 0;
            this.FIO = "Fktrctq";
            this.Birthdate = DateTime.Now;
            this.Position = null;
            this.Salary = 0;
        }

        public Employees(int id, string fio, DateTime dateTime, string position, decimal salary)
        {
            this.ID = id;
            this.FIO = fio;
            this.Birthdate = dateTime;
            this.Position = position;
            this.Salary = salary;
        }

        public int ID { get; set; }
        [Required(ErrorMessage = "необходимо заполнить ФИО")]
        public string FIO { get; set; }
        [Required(ErrorMessage = "необходимо заполнить дату рождения")]
        public DateTime Birthdate { get; set; }
        [Required(ErrorMessage = "необходимо заполнить должность сотрудника")]
        public string Position { get; set; }
        [Required(ErrorMessage = "необходимо заполнить получаемую зарплату")]
        public decimal Salary { get; set; }
    }
}