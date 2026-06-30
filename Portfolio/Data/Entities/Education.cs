namespace Portfolio.Data.Entities
{
    public class Education
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public string? Description { get; set; }
        public string SchoolName { get; set; }
        public double GPA { get; set; }
        public int StarYear { get; set; }
        public string? GradationYear { get; set; }
    }
}
