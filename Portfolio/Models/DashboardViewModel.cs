namespace Portfolio.Models
{
    public class DashboardViewModel
    {
        public int TotalProjects { get; set; }
        public int TotalTechStacks { get; set; }
        public int TotalMessages { get; set; }
        public int TotalTestimonials { get; set; }
        public int TotalSkills { get; set; }
        public List<RecentMessageItem> RecentMessages { get; set; } = new();
    }

    public class RecentMessageItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MessageBody { get; set; }
    }
}