
using Megazine_Practice.Models;
using System.ComponentModel.DataAnnotations;



namespace Megazine_Practice.ViewModel
{
    public class NewsViewModel
    {

        public NewsViewModel()
        {
            EmployeeViewModels = new EmployeeViewModel();
        }
        [Key]
        public int News_Id { get; set; }

        [Required]
        [Display(Name = "News Name")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public int? Employee_Id { get; set; }

        public List<Employee> EmployeeModels { get; set; }
        [Display(Name ="FullName")]
        public EmployeeViewModel EmployeeViewModels { get; set; }

        public IFormFile File { get; set; }
        public string NewsImage { get; set; }
        public DateTime? CreatedDate { get; set; }
        
        public bool IsActive { get; set; }
    }
}
