using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime ReceivedTime { get; set; }
    }

}
