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

        public EmployeesController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View(_repository.GetEmployees();
        }


        public ActionResult Details(int id)
        {
            Billing billing = _repository.GetBillingByID(id);
            if (billing == null)
                return RedirectToAction("Index");

            return View(billing);
        }


        public ActionResult Create()
        {
            ViewBag.TypeList = typeList;
            return View();
        }


        [HttpPost]
        public ActionResult Create(Billing billing)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.InsertBilling(billing);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //error msg for failed insert in XML file
                    ModelState.AddModelError("", "Error creating record. " + ex.Message);
                }
            }

            return View(billing);
        }


        public ActionResult Edit(int id)
        {
            Billing billing = _repository.GetBillingByID(id);
            if (billing == null)
                return RedirectToAction("Index");

            ViewBag.TypeList = typeList;
            return View(billing);
        }


        [HttpPost]
        public ActionResult Edit(Billing billing)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.EditBilling(billing);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //error msg for failed edit in XML file
                    ModelState.AddModelError("", "Error editing record. " + ex.Message);
                }
            }

            return View(billing);
        }


        public ActionResult Delete(int id)
        {
            Billing billing = _repository.GetBillingByID(id);
            if (billing == null)
                return RedirectToAction("Index");
            return View(billing);
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _repository.DeleteBilling(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //error msg for failed delete in XML file
                ViewBag.ErrorMsg = "Error deleting record. " + ex.Message;
                return View(_repository.GetBillingByID(id));
            }
        }
    }
}