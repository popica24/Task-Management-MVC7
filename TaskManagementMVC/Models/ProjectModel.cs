using TaskManagementMVC.Models.Enums;
using TechfolioMVC.Models;

namespace TaskManagementMVC.Models
{
    public class ProjectModel
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
        public Status Status { get; set; }
        public DateTime? Created { get; set; }
        List<TechModel>? Techs { get; set; }
        
    }
}
