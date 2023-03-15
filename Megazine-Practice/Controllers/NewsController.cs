using Megazine_Practice.Helper;
using Megazine_Practice.Models;
using Megazine_Practice.Services.ServiceInterface;
using Megazine_Practice.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Megazine_Practice.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly IEmployeeService _employeeService;

        public NewsController(INewsService newsService, IEmployeeService employeeService)
        {
            _newsService = newsService;
            _employeeService = employeeService;
        }


        //Get: NewsController
        public ActionResult Index(int PageNumber=1)
        {
            NewsIndexVm newsIndexVm = new();
            newsIndexVm.NewsViewModel = new NewsViewModel();
            newsIndexVm.NewsViewModels = _newsService.GetAll();

            foreach(var item in newsIndexVm.NewsViewModels)
            {
                item.EmployeeViewModels = _employeeService.GetById(item.Employee_Id.Value);
            }

            newsIndexVm.NewsPagedList = PaginatedList<NewsViewModel>.Create(newsIndexVm.NewsViewModels.AsQueryable(), PageNumber,5);
            return View(newsIndexVm);
        }

        //Get: Create
        public ActionResult Create()
        {
            try
            {
                List<EmployeeViewModel> employeeModels= new List<EmployeeViewModel>();
                employeeModels = _employeeService.GetAll();
                ViewBag.NewsEmployee = new SelectList(employeeModels, "Employee_Id", "FullName");
                return View();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsIndexVm model, IFormFile file)
        {
            try
            {
                _newsService.save(model.NewsViewModel);
                return Json(true);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            try
            {
                NewsViewModel newsVm = _newsService.GetById(Id);
                List<EmployeeViewModel> employeeViewModel = new List<EmployeeViewModel>();
                employeeViewModel = _employeeService.GetAll();
                ViewBag.NewsEmployee = new SelectList(employeeViewModel, "Employee_Id", "FullName");
                return View(newsVm);


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(NewsViewModel newsViewModel)
        {
            try
            {
                _newsService.update(newsViewModel);
                return Json(true);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public ActionResult Delete(int id)
        {
            NewsViewModel newsDelete = _newsService.GetById(id);

            NewsViewModel nvm = new NewsViewModel();
            nvm = _newsService.GetById(id);
            var emp = _employeeService.GetAll();

            foreach(var item in emp)
            {
                var employee = _employeeService.GetById((int)nvm.Employee_Id);
                nvm.EmployeeViewModels.First_name = employee.FullName;
            }
            return View(nvm);

            return View(newsDelete);
        }

        [HttpPost]
        public ActionResult Delete(NewsViewModel newsViewModel)
        {
            try
            {
                _newsService.delete(newsViewModel);
                return Json(true);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }





    }
}
