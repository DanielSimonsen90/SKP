using System.ComponentModel.DataAnnotations;

namespace Common.Entities
{
    public class Message
    {
        [Required] [Key]
        public int Id { get; set; }
        
        [Required] 
        public string Author { get; set; }
        
        [Required] 
        public string Content { get; set; }

        [Required]
        public string Timestamp { get; set; }
    }
}
