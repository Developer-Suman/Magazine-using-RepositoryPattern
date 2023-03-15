using Megazine_Practice.Helper;
using Megazine_Practice.Services.ServiceInterface;
using Megazine_Practice.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Megazine_Practice.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public ActionResult Index(int pageNumber = 1)
        {
            EmployeeIndexVm employeevm = new();
            employeevm.EmployeeViewModel= new EmployeeViewModel();
            employeevm.EmployeeViewModels = _employeeService.GetAll();
            employeevm.EmployeePagedList = PaginatedList<EmployeeViewModel>.Create(employeevm.EmployeeViewModels.AsQueryable(), pageNumber, 5);
            return View(employeevm);
        }

        //Get : EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeIndexVm mode, IFormFile File)
        {
            try
            {
                _employeeService.save(mode.EmployeeViewModel);
                return Json(true);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        //Get : EmployeeController/Edit/4
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            EmployeeViewModel employeeEdit = _employeeService.GetById(Id);
            return View(employeeEdit);
        }


        //Post: EmployeeController/Edit/4
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel employeeViewModel, IFormFile File)
        {
            try
            {
                _employeeService.update(employeeViewModel);
                return Json(true);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        //Get : EmployeeController/Delete/5
        public ActionResult Delete(int Id)
        {
            EmployeeViewModel employeeDelete = _employeeService.GetById(Id);
            return View(employeeDelete);
        }

        //Post : EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmployeeViewModel employeeViewModel)
        {
            try
            {
                _employeeService.delete(employeeViewModel);
                return Json(true);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public JsonResult ChangeEmployeeStatus(int id)
        {
            try
            {
                var result = _employeeService.ChangeEmployeeStatus(id);
                return Json(result);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        
    }
}
