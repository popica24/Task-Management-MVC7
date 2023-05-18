namespace TaskManagementMVC.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        //Navigation property for related tasks
        public ICollection<TaskModel>? Tasks { get; set; }
    }
}
