using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Data.Entities
{
    public class Testimonial
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string Title { get; set; }
        [NotMapped]
        public string Initials
        {
            get
            {
                var firstChar = !string.IsNullOrWhiteSpace(FirstName) ? FirstName.Trim()[0].ToString().ToUpper() : "";
                var lastChar = !string.IsNullOrWhiteSpace(LastName) ? LastName.Trim()[0].ToString().ToUpper() : "";
                return $"{firstChar}{lastChar}";
            }
        }
    }
}
