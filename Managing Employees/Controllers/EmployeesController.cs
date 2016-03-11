using Managing_Employees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Managing_Employees.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeRepository _repository;

        

        public EmployeesController()
        {
            _repository = new EmployeeRepository();
        }

        public  ActionResult Index(string SortOrder,string SortBy)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;

            var  emp = _repository.GetEmployees();

            switch (SortBy)
            {
                case "FIO":
                switch (SortOrder)
                {
                    case "Asc":
                        emp = emp.OrderBy(x => x.FIO).ToList();
                        break;
                    case "Desc":
                        emp = emp.OrderByDescending(x => x.FIO).ToList();
                        break;
                    default:
                        break;
                }
                break;

                case "Birthdate":
                    switch (SortOrder)
                    {
                        case "Asc":
                            emp = emp.OrderBy(x => x.Birthdate).ToList();
                            break;
                        case "Desc":
                            emp = emp.OrderByDescending(x => x.Birthdate).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Position":
                    switch (SortOrder)
                    {
                        case "Asc":
                            emp = emp.OrderBy(x => x.Position).ToList();
                            break;
                        case "Desc":
                            emp = emp.OrderByDescending(x => x.Position).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Salary":
                    switch (SortOrder)
                    {
                        case "Asc":
                            emp = emp.OrderBy(x => x.Salary).ToList();
                            break;
                        case "Desc":
                            emp = emp.OrderByDescending(x => x.Salary).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
            }
            
            return View(emp);
        }


        public ActionResult Details(int id)
        {
            Employees employee = _repository.GetEmployeeById(id);
            if (employee == null)
                return RedirectToAction("Index");

            return View(employee);
        }


        public ActionResult Create()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult Create(Employees employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.InsertEmployee(employee);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //error msg for failed insert in XML file
                    ModelState.AddModelError("", "Error creating record. " + ex.Message);
                }
            }

            return View(employee);
        }


        public ActionResult Edit(int id)
        {
            Employees employee = _repository.GetEmployeeById(id);
            if (employee == null)
                return RedirectToAction("Index");

            
            return View(employee);
        }


        [HttpPost]
        public ActionResult Edit(Employees employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.UpdateEmployee(employee);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //error msg for failed edit in XML file
                    ModelState.AddModelError("", "Error editing record. " + ex.Message);
                }
            }

            return View(employee);
        }


        public ActionResult Delete(int id)
        {
            Employees employee = _repository.GetEmployeeById(id);
            if (employee == null)
                return RedirectToAction("Index");
            return View(employee);
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _repository.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //error msg for failed delete in XML file
                ViewBag.ErrorMsg = "Error deleting record. " + ex.Message;
                return View(_repository.GetEmployeeById(id));
            }
        }


    }
}