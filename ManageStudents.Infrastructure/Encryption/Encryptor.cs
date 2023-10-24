using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.Infrastructure.Encryption
{
    public class Encryptor : IEncryptor
    {
        private readonly IDataProtector _protector;

        public Encryptor(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector(GetType().FullName);
        }

        public string Encrypt(string plaintext)
        {
            return !string.IsNullOrWhiteSpace(plaintext) ? _protector.Protect(plaintext) : plaintext;
        }

        public string Decrypt(string encryptedText)
        {
            return !string.IsNullOrWhiteSpace(encryptedText) ? _protector.Unprotect(encryptedText) : encryptedText;
        }
    }
}
