using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Megazine_Practice.Models
{
    public class Articles
    {
        [Key]
        public int Articles_Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public int? Employee_Id { get; set; }
        [ForeignKey("Employee_Id")]

        public virtual Employee EmployeeModels { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool Is_Active { get; set; } = true;

        public void Active()
        {
            Is_Active = true;
        }
        public void Inactive()
        {
            Is_Active = false;

        }
        public string TimeAgo
        {
            get
            {
                TimeSpan timeSincePosted = DateTime.Now - CreatedDate;

                if (timeSincePosted.TotalMinutes < 1)
                {
                    return "just Now";
                }
                else if (timeSincePosted.TotalHours < 1)
                {
                    int minutes = (int)Math.Floor(timeSincePosted.TotalMinutes);
                    return $"{minutes} minute{(minutes > 1 ? "s" : "")} ago";
                }
                else if (timeSincePosted.TotalDays < 1)
                {
                    int hours = (int)Math.Floor(timeSincePosted.TotalHours);
                    return $"{hours} hour{(hours > 1 ? "s" : "")} ago";
                }
                else
                {
                    int days = (int)Math.Floor(timeSincePosted.TotalDays);
                    return $"{days} day{(days > 1 ? "s" : "")} ago";

                }
            }
        }
    }
}
