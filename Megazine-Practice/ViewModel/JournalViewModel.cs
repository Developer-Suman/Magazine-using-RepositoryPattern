using Megazine_Practice.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Megazine_Practice.ViewModel
{
    public class JournalViewModel
    {
        public JournalViewModel()
        {
            EmployeeViewModels = new EmployeeViewModel();
        }
        public int Journal_Id { get; set; }

        public int? Employee_Id { get; set; }
        public List<Employee> EmployeeModels { get; set; }

        [Display(Name ="FullName")]
        public EmployeeViewModel EmployeeViewModels { get; set; }



        [Required]
        [Display(Name = "Journal Name")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string JournalImage { get; set; }

        public IFormFile File { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool Is_Active { get; set; } = true;
    }
}
