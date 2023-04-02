using Microsoft.EntityFrameworkCore;
using System.Text;
using TestTask.Interfaces;
using TestTask.Models;
using TestTask.Data;
using TestTask.DTOs;

namespace TestTask.Services
{
    public class DefaultEncryptServise : IEncryptService
    {
        private readonly IEncryptedKeyRepository _encryptServise;
        private readonly Dictionary<char,char> replacements;

        public DefaultEncryptServise(IEncryptedKeyRepository encryptedServise)
        {
            _encryptServise = encryptedServise;
            replacements = _encryptServise.GetEncryptedKeys().ToDictionary(x => x.oldSymbol, y => y.newSymbol);
        }

        public EncryptedMessage EncryptMessage(MessageDTO message)
        {
            var _message = message.Text;
            var encryptedMessage = new StringBuilder();
            foreach (var ch in _message)
            {
                if (replacements.TryGetValue(ch, out char value))
                {
                    encryptedMessage.Append(value);
                }
                else
                {
                    encryptedMessage.Append(ch);
                }
            }

            return new EncryptedMessage { Text = encryptedMessage.ToString() };
        }
    }
}
