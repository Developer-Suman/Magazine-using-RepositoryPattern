using Megazine_Practice.Models;
using System.ComponentModel.DataAnnotations;

namespace Megazine_Practice.ViewModel
{
    public class ArticlesViewModel
    {

        public ArticlesViewModel()
        {
             EmployeeViewModel = new EmployeeViewModel();
        }
        public int Articles_Id { get; set; }

        public int? Employee_Id { get; set; }
        public List<Employee> EmployeeModels { get; set; }

        [Display(Name ="FullName")]
        public EmployeeViewModel EmployeeViewModel { get; set; }


        [Required]
        [Display(Name = "Articles Name")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    
        public DateTime? CreatedDate { get; set; }
        public bool Is_Active { get; set; } = true;
    }
}
