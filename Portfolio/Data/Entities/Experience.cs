namespace Portfolio.Data.Entities
{
    public class Experience
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public int StarYear {  get; set; }
        public string? EndYear { get; set; }

    }
}
