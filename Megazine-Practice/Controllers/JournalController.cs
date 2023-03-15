using Megazine_Practice.Helper;
using Megazine_Practice.Services.ServiceInterface;
using Megazine_Practice.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Megazine_Practice.Controllers
{
    public class JournalController : Controller
    {
        private readonly IJournalServicecs _journalServices;
        private readonly IEmployeeService _employeeService;
        public JournalController(IJournalServicecs journalServices, IEmployeeService employeeService)
        {
            _employeeService= employeeService;
            _journalServices = journalServices;
        }

        //Get: JournalController
        public ActionResult Index(int PageNumber=1)
        {
            JournalIndexVmcs journalIndexVmcs = new();
            journalIndexVmcs.JournalViewModel = new JournalViewModel();
            journalIndexVmcs.JournalViewModels = _journalServices.GetAll();

            foreach(var item in journalIndexVmcs.JournalViewModels)
            {
                item.EmployeeViewModels = _employeeService.GetById(item.Employee_Id.Value);
            }



            journalIndexVmcs.JournalPagedList = PaginatedList<JournalViewModel>.Create(journalIndexVmcs.JournalViewModels.AsQueryable(), PageNumber, 5);
            return View(journalIndexVmcs);
        }

        //Get: JournalController/Details/5
        public ActionResult Details(int Id)
        {
            return View();
        }

        //Get: JournalController/Create
        public ActionResult Create()
        {
            try
            {
                List<EmployeeViewModel> employeeModels = new List<EmployeeViewModel>();
                employeeModels = _employeeService.GetAll();
                ViewBag.JournalEmployee = new SelectList(employeeModels, "Employee_Id", "FullName");
                return View();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        //Post: JournalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JournalIndexVmcs model, IFormFile file)
        {
            try
            {
                _journalServices.save(model.JournalViewModel);
                return Json(true);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        //Get: JournalController/Edit/5
        public ActionResult Edit(int Id)
        {
            JournalViewModel journalEdit = _journalServices.GetById(Id);
            List<EmployeeViewModel> employeeViewModel = new List<EmployeeViewModel>();
            employeeViewModel = _employeeService.GetAll();
            ViewBag.JournalEmployee = new SelectList(employeeViewModel, "Employee_Id", "FullName");


            
            return View(journalEdit);
        }

        //Post: JournalController/Edit/5
        [HttpPost]
        public ActionResult Edit(JournalViewModel journalViewModel)
        {
            try
            {
                _journalServices.update(journalViewModel);
                return Json(true);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(false);

            }
        }





        //Get: JournalController/Delete/5
        public ActionResult Delete(int Id)
        {
            JournalViewModel journalDelete = _journalServices.GetById(Id);


            JournalViewModel jvm = new JournalViewModel();
            jvm = _journalServices.GetById(Id);
            var emp = _employeeService.GetAll();


            foreach(var item in emp)
            {
                var employe = _employeeService.GetById((int)jvm.Employee_Id);
                jvm.EmployeeViewModels.First_name = employe.First_name;
            }

            return View(jvm);




            return View(journalDelete);


        }

        //Post : JournalController/Delete/5
        [HttpPost]
        public ActionResult Delete(JournalViewModel journalViewModel)
        {
            try
            {
                _journalServices.delete(journalViewModel);
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
