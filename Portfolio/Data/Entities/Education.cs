using System.ComponentModel.DataAnnotations;

namespace Portfolio.Data.Entities
{
    public class Education
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bölüm adı boş geçilemez.")]
        [StringLength(100, ErrorMessage = "Bölüm adı en fazla 100 karakter olabilir.")]
        public string Department { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Okul adı boş geçilemez.")]
        [StringLength(150, ErrorMessage = "Okul adı en fazla 150 karakter olabilir.")]
        public string SchoolName { get; set; }

        [Required(ErrorMessage = "Ortalama boş geçilemez.")]
        public string GPA { get; set; }

        [Required(ErrorMessage = "Başlangıç yılı boş geçilemez.")]
        [Range(1900, 2100, ErrorMessage = "Lütfen geçerli bir başlangıç yılı giriniz.")]
        public int StarYear { get; set; }

        [RegularExpression(@"^(19|20|21)\d{2}$", ErrorMessage = "Mezuniyet yılı 4 haneli geçerli bir yıl olmalıdır.")]
        public string? GradationYear { get; set; }
    }
}