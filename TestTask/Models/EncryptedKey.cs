using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class EncryptedKey
    {
        [Key]
        public char oldSymbol { get; set; }
        public char newSymbol { get; set; }
    }
}
