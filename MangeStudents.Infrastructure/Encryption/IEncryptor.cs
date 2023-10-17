using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent.Infrastructure.Encryption
{
    public interface IEncryptor
    {
        string Encrypt(string plaintext);

        string Decrypt(string encryptedText);
    }
}