using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class EncryptedMessage
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
