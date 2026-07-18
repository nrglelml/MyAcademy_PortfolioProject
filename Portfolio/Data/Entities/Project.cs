using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Portfolio.Data.Entities
{
    public class Project
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Proje adı boş geçilemez.")]
        [StringLength(100, ErrorMessage = "Proje adı en fazla 100 karakter olabilir.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "GitHub linki boş geçilemez.")]
        [Url(ErrorMessage = "Lütfen geçerli bir URL giriniz.")]
        public string GithubUrl { get; set; }

        [Required(ErrorMessage = "Proje görseli boş geçilemez.")]
        public string ImageUrl { get; set; }

        public List<ProjectTechStack> ProjectTechStacks { get; set; }
    }
}   