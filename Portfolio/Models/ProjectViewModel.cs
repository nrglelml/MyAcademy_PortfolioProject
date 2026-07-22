namespace Portfolio.Models
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string TechNames { get; set; }
    }
}