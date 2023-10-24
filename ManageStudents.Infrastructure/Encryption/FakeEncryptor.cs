using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudents.Infrastructure.Encryption
{
    public class FakeEncryptor : IEncryptor
    {
        public string Decrypt(string encryptedText)
        {
            return encryptedText;
        }

        public string Encrypt(string plaintext)
        {
            return plaintext;
        }
    }
}
