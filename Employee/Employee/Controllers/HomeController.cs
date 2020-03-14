
using Employee.Models;
using Employee.ViewsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Employee.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeLeaveRepository _employeeLeaveRepository;
        private readonly IHostingEnvironment _hostingEnviroment;

        public HomeController(IEmployeeRepository employeeRepository,
                              IEmployeeLeaveRepository employeeLeaveRepository,
                              IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _employeeLeaveRepository = employeeLeaveRepository;
            _hostingEnviroment = hostingEnvironment;
        }

        [Route("Home")]
        [Route("Home/Dashboard")]
        public ViewResult Dashboard()
        {
            return View();
        }


        [Route("Home")]
        [Route("Home/Index")]
        public ViewResult Index()
        {
            var Model = _employeeRepository.GetAllEmployeeProps();
            return View(Model);
        }

        [Route("Home")]
        [Route("Home/Details")]
        [Route("Home/Details/{Id?}")]
        public ViewResult Details(int? Id)
        {
            EmployeeProp employeeProp = _employeeRepository.GetEmployeeId(Id.Value);

            if (employeeProp == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", Id.Value);
            }

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                employeeProp = employeeProp,
                PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }

        //[Route("Home")]
        //[Route("Home/Create")]

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        //[Route("Home")]
        //[Route("Home/Create")]

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadFile(model);

                EmployeeProp newEmploy = new EmployeeProp
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    photoPath = uniqueFileName
                };
                _employeeRepository.Add(newEmploy);
                return RedirectToAction("Details", new { id = newEmploy.Id });
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public ViewResult Edit(int id)
        {
            EmployeeProp employeeProp = _employeeRepository.GetEmployeeId(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                id = employeeProp.Id,
                Name = employeeProp.Name,
                Email = employeeProp.Email,
                Department = employeeProp.Department,
                ExistingPhoto = employeeProp.photoPath
            };
            return View(employeeEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeProp employeeProp = _employeeRepository.GetEmployeeId(model.id);

                employeeProp.Name = model.Name;
                employeeProp.Department = model.Department;
                employeeProp.Email = model.Email;

                if (model.Photo != null)
                {
                    if (model.ExistingPhoto != null)
                    {
                        string filePath = Path.Combine(_hostingEnviroment.WebRootPath,
                            "images", model.ExistingPhoto);
                        System.IO.File.Delete(filePath);
                    }

                    employeeProp.photoPath = ProcessUploadFile(model);
                }

                _ = _employeeRepository.Update(employeeProp);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        private string ProcessUploadFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string UploadFolderPath = Path.Combine(_hostingEnviroment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string FilePath = Path.Combine(UploadFolderPath, uniqueFileName);
                using (var fileStream = new FileStream(FilePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [HttpGet]
        [Route("Delete/{id}")]

        public IActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return RedirectToAction("Index");
        }
        //[Route("Home")]
        //[Route("Home/ViewLeaves")]
        //[HttpGet]
        //public ViewResult ViewLeaves()
        //{
        //    var Model = _employeeLeaveRepository.GetEMPLeaves();
        //    return View(Model);
        //}
        [HttpGet]
        public ViewResult AddLeave()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddLeave(EMPLeave model)
        {
            if (ModelState.IsValid)
            {

                EMPLeave eMPLeave = new EMPLeave
                {
                    LeaveType = model.LeaveType,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate
                };
                _employeeLeaveRepository.AddLeave(eMPLeave);
                return RedirectToAction("Details");
            }
            return View();
        }

    }
}
