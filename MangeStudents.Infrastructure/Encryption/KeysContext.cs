using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ManageStudent.Infrastructure.Encryption
{
    public class KeysContext : DbContext, IDataProtectionKeyContext
    {
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

        public KeysContext(DbContextOptions<KeysContext> options)
           : base(options) { }
    }
}
