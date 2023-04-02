using System.ComponentModel.DataAnnotations;

namespace TestTask.DTOs
{
    public class MessageDTO
    {
        public string Text { get; set; }
        public DateTime ReceivedTime { get; set; }
    }
}
