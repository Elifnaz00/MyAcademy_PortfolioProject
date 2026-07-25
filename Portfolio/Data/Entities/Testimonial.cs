using System.ComponentModel.DataAnnotations;

namespace Portfolio.Data.Entities
{
    public class Testimonial
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Bu alan boş geçilemez.")]
        public int Rating { get; set; }

        [MaxLength(100, ErrorMessage = "Yorum içeriği en fazla 100 karakter uzunluğunda olmalıdır.")]
        public string Comment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public string Initials { get; set; }
        public string Title { get; set; }
    }
}
