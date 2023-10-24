﻿using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ManageStudents.Infrastructure.Encryption
{
    public class KeysContext : DbContext, IDataProtectionKeyContext
    {
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

        public KeysContext(DbContextOptions<KeysContext> options)
           : base(options) { }
    }
}
