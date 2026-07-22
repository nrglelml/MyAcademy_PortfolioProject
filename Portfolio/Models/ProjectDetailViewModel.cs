namespace Portfolio.Models
{
    public class ProjectDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? GithubUrl { get; set; }
        public string? ImageUrl { get; set; }
        public List<string> TechNames { get; set; } = new();
    }
}