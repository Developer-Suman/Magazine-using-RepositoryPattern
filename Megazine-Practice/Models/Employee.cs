
using Megazine_Practice.Enum;
using NHibernate.Type;
using System.ComponentModel.DataAnnotations;

namespace Megazine_Practice.Models
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }
        [Display(Name = "Full Name")]
        public string FullName => First_name + " " + Last_name;
        [Required]
        public string First_name { get; set; }
        [Required]
        public string Last_name { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact_1 { get; set; }
        public string Contact_2 { get; set; }

        public MartialStatusEnum Martial_Status { get; set; }
        public GenderEnum Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime Joining_Date { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public string Email { get; set; }
        public string? Description { get; set; }
        public string? Employee_Image { get; set; }
        public bool Is_Active { get; set; } = true;

        public void Active()
        {
            Is_Active = true;
        }

        public void InActive()
        {
            Is_Active = false;
        }
    }
}
