using Megazine_Practice.Helper;
using Megazine_Practice.Services.ServiceInterface;
using Megazine_Practice.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Megazine_Practice.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticlesService _articlesService;
        private readonly IEmployeeService _employeeService;
        public ArticlesController(IArticlesService articlesService, IEmployeeService employeeService)
        {
            _articlesService = articlesService;
            _employeeService = employeeService;
        }
        //GET: ArticlesController
        public ActionResult Index( int pageNumber=1)
        {
            ArticlesIndexVm articlesIndexVm = new();
            articlesIndexVm.ArticlesViewModel = new ArticlesViewModel();
            articlesIndexVm.ArticlesViewModels = _articlesService.GetAll();

            foreach(var item in articlesIndexVm.ArticlesViewModels)
            {
                item.EmployeeViewModel = _employeeService.GetById(item.Employee_Id.Value);
            }



            articlesIndexVm.ArticlesPagedList = PaginatedList<ArticlesViewModel>.Create(articlesIndexVm.ArticlesViewModels.AsQueryable(), pageNumber, 5);
            return View(articlesIndexVm);
        }


        //Get: ArticlesController/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        //Get: ArticlesController/Create
        public ActionResult Create()
        {
            try
            {
                List<EmployeeViewModel> employeeModels = new List<EmployeeViewModel>();
                employeeModels = _employeeService.GetAll();
                ViewBag.ArticleEmployee = new SelectList(employeeModels, "Employee_Id", "FullName");
                return View();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        //POST: ArticlesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(ArticlesIndexVm model)
        {
            try
            {
                _articlesService.save(model.ArticlesViewModel);
                return Json(true);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(false);
            }
        }

        //GET: Articlesontroller/Delete/5
        public ActionResult Delete(int id)
        {
            ArticlesViewModel articles = _articlesService.GetById(id);

            ArticlesViewModel vm = new ArticlesViewModel();
            vm = _articlesService.GetById(id);

            EmployeeViewModel employee = new EmployeeViewModel();
            var emp = _employeeService.GetAll();
            //ArticlesIndexVm articlesIndexVm = new();
            //articlesIndexVm.ArticlesViewModel = new ArticlesViewModel();
            //articlesIndexVm.ArticlesViewModels = _articlesService.GetAll();

            foreach (var item in emp)
            {
                var employe = _employeeService.GetById((int)vm.Employee_Id);
                vm.EmployeeViewModel.First_name = employe.First_name;
            }
            return View(vm);


            return View(articles);
        }

        //POST: ArticlesController/Edit/5
        [HttpPost]
        public ActionResult Edit(ArticlesViewModel articleViewModel)
        {
            try
            {
                _articlesService.update(articleViewModel);
                return Json(true);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(false);
            }

        }
        public ActionResult Edit(int id)
        {
            ArticlesViewModel articles = _articlesService.GetById(id);
            List<EmployeeViewModel> employeeViewModel = new List<EmployeeViewModel>();
            employeeViewModel = _employeeService.GetAll();
            ViewBag.ArticlesEmployee = new SelectList(employeeViewModel, "Employee_Id", "FullName");
            return View(articles);
        }

        [HttpPost]
  
        public ActionResult Delete(ArticlesViewModel articleViewModel)
        {
            try
            {
                _articlesService.delete(articleViewModel);
                return Json(true);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(false);
            }
        }
    }
}
