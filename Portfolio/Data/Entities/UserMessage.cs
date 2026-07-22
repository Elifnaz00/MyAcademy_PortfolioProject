using System.ComponentModel.DataAnnotations;

namespace Portfolio.Data.Entities
{
    public class UserMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }

        [MinLength(80, ErrorMessage = "Mesaj içeriği en az 80 karakter uzunluğunda olmalıdır.")]
        [MaxLength(500, ErrorMessage = "Mesaj içeriği en fazla 500 karakter uzunluğunda olmalıdır.")]
        public string MessageBody { get; set; }
        public bool IsRead { get; set; }
        
    }
}
