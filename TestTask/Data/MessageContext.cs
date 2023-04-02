using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Data
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> opt) : base(opt)
        {
            
        }


        public DbSet<Message> Messages { get; set; }

        public DbSet<EncryptedMessage> EncryptedMessages { get; set; }

        public DbSet<EncryptedKey> EncryptedKeys { get; set; }
    }
}
