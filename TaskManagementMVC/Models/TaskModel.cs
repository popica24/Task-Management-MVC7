using TaskManagementMVC.Models.Enums;

namespace TaskManagementMVC.Models
{
    public class TaskModel
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public Status Status { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Due { get; set; }

        //Navigation property for related user
        public UserModel user { get; set; }
        public int UserID { get; set; }
    }
}
