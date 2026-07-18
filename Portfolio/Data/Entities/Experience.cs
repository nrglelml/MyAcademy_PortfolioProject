using System.ComponentModel.DataAnnotations;

namespace Portfolio.Data.Entities
{
    public class Experience
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pozisyon / Unvan alanı boş geçilemez.")]
        [StringLength(100, ErrorMessage = "Pozisyon / Unvan en fazla 100 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama alanı boş geçilemez.")]
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Şirket / Kurum adı boş geçilemez.")]
        [StringLength(150, ErrorMessage = "Şirket / Kurum adı en fazla 150 karakter olabilir.")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Başlangıç yılı boş geçilemez.")]
        [Range(1900, 2100, ErrorMessage = "Lütfen geçerli bir başlangıç yılı giriniz.")]
        public int StarYear { get; set; }

        [RegularExpression(@"^(19|20|21)\d{2}$", ErrorMessage = "Bitiş yılı 4 haneli geçerli bir yıl olmalıdır.")]
        public string? EndYear { get; set; }
    }
}