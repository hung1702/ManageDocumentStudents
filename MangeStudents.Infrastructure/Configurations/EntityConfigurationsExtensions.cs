using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageStudent.Infrastructure.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent.Infrastructure.EntityConfigurations
{
    public static class EntityConfigurationsExtensions
    {
        public static PropertyBuilder<string> Encrypt(this PropertyBuilder<string> prop, IEncryptor encryptor)
        {
            return prop.HasConversion(x => encryptor.Encrypt(x), x => encryptor.Decrypt(x));
        }

        public static PropertyBuilder<T> Encrypt<T>(this PropertyBuilder<T> prop, IEncryptor encryptor) where T : new()
        {
            return prop.HasConversion(x => encryptor.Encrypt(ChangeType<string>(x)), x => ChangeType<T>(encryptor.Decrypt(x)));
        }

        private static T ChangeType<T>(this object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }
    }
}
