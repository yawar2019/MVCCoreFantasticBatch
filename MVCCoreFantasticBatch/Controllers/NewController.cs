using Microsoft.AspNetCore.Mvc;
using MVCCoreFantasticBatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreFantasticBatch.Controllers
{
    public class NewController : Controller
    {
        public string Index()
        {
            return "Hello World";
        }

        public IActionResult GetMeView() 
        {
            return View();
        }

        public IActionResult GetMeView2()
        {
            ViewBag.info = "Imtiyaz";
            return View();
        }

        public IActionResult GetMeView3()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Imtiyaz";
            emp.EmpSalary = 193836;

            ViewBag.info = emp;
            return View();
        }

        [Route("Srilanka/Roti/{id:int}")]
        [Route("Srilanka/biryani")]
        public IActionResult GetMultipleDataView()
        {
            List<EmployeeModel> listEmp = new List<EmployeeModel>();


            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Imtiyaz";
            emp.EmpSalary = 193836;


            EmployeeModel emp1 = new EmployeeModel();
            emp1.EmpId = 2;
            emp1.EmpName = "Riyaz";
            emp1.EmpSalary = 77678;


            EmployeeModel emp2 = new EmployeeModel();
            emp2.EmpId = 3;
            emp2.EmpName = "Farhan";
            emp2.EmpSalary = 897666;

            listEmp.Add(emp);
            listEmp.Add(emp1);
            listEmp.Add(emp2);


            ViewBag.info = listEmp;

            return View();
        }

        public IActionResult GetMeView5()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Imtiyaz";
            emp.EmpSalary = 193836;

            
            return View(emp);
        }

        public IActionResult GetMultipleDataView2()
        {
            List<EmployeeModel> listEmp = new List<EmployeeModel>();
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Imtiyaz";
            emp.EmpSalary = 193836;
            EmployeeModel emp1 = new EmployeeModel();
            emp1.EmpId = 2;
            emp1.EmpName = "Riyaz";
            emp1.EmpSalary = 77678;
            EmployeeModel emp2 = new EmployeeModel();
            emp2.EmpId = 3;
            emp2.EmpName = "Farhan";
            emp2.EmpSalary = 897666;
            listEmp.Add(emp);
            listEmp.Add(emp1);
            listEmp.Add(emp2);

            return View("GetMultipleViewPArt2", listEmp);
        }


        public IActionResult GetMultipleDataView3()
        {
            List<EmployeeModel> listEmp = new List<EmployeeModel>();

            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Imtiyaz";
            emp.EmpSalary = 193836;


            EmployeeModel emp1 = new EmployeeModel();
            emp1.EmpId = 2;
            emp1.EmpName = "Riyaz";
            emp1.EmpSalary = 77678;


            EmployeeModel emp2 = new EmployeeModel();
            emp2.EmpId = 3;
            emp2.EmpName = "Farhan";
            emp2.EmpSalary = 897666;

            listEmp.Add(emp);
            listEmp.Add(emp1);
            listEmp.Add(emp2);


            List<DepartmentModel> listDept = new List<DepartmentModel>();

            DepartmentModel dept = new DepartmentModel();
            dept.DeptId = 1211;
            dept.DeptName = "IT";


            DepartmentModel dept2 = new DepartmentModel();
            dept2.DeptId = 1212;
            dept2.DeptName = "Network";
             
            listDept.Add(dept);
            listDept.Add(dept2);

            EmpDept empdept = new EmpDept();
            empdept.Emp =listEmp;
            empdept.dept =listDept;
             

            return View(empdept);
        }


        public IActionResult RedirectToHomeControllerView()
        {
            return View("~/Views/Home/Privacy.cshtml");

        }

        public IActionResult jumptoAnotherActionMethod()
        {

            return RedirectToAction("RedirectToHomeControllerView");
        }

        public IActionResult jumptoAnotherActionMethod2()
        {

            return RedirectToAction("Privacy","Home");
        }

        public IActionResult jumptoAnotherActionMethod3()
        {

            return RedirectToAction("Agreememt", "Home",new {id=1211});
        }
    }
}
