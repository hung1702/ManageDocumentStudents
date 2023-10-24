using Microsoft.EntityFrameworkCore;
using ManageStudents.Infrastructure.Abstractions;
using ManageStudents.Infrastructure.Encryption;
using ManageStudents.Infrastructure.Configurations;
using ManageStudents.Infrastructure.Entities.Users;

namespace ManageStudents.Infrastructure
{
    public class StudentContext: DbContext, IUnitOfWork
    {
        private readonly IEncryptor _encryptor;
        public const string DEFAULT_SCHEMA = "dbo";
        
        //public DbSet<Template> Templates { get; set; }
        //public DbSet<Question> Questions { get; set; }
        //public DbSet<Answer> Answers { get; set; }
        //public DbSet<TemplateLocation> TemplateLocations { get; set; }

        public DbSet<DiaChi> DiaChis { get; set; }
        public DbSet<GiangVien> GiangViens { get; set; }
        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<LopSinhVien> LopSinhViens { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<Truong> Truongs { get; set; }
        public DbSet<User> Users { get; set; }

        public StudentContext(DbContextOptions<StudentContext> options, IEncryptor encryptor) : base(options)
        {
            _encryptor = encryptor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Template>();
            //modelBuilder.Entity<Question>();
            //modelBuilder.Entity<Answer>();
            //modelBuilder.Entity<TemplateLocation>();

            modelBuilder.Entity<DiaChi>();
            modelBuilder.Entity<GiangVien>();
            modelBuilder.Entity<Khoa>();
            modelBuilder.Entity<LopSinhVien>();
            modelBuilder.Entity<SinhVien>();
            modelBuilder.Entity<Truong>();
            modelBuilder.Entity<User>();

            modelBuilder
                //.ApplyConfiguration(new TemplateEntityConfiguration(_encryptor))
                //.ApplyConfiguration(new QuestionEntityConfiguration(_encryptor))
                //.ApplyConfiguration(new AnswerEntityConfiguration(_encryptor))

                .ApplyConfiguration(new DiaChiEntityConfiguration())
                .ApplyConfiguration(new GiangVienEntityConfiguration())
                .ApplyConfiguration(new KhoaEntityConfiguration())
                .ApplyConfiguration(new LopSinhVienEntityConfiguration())
                .ApplyConfiguration(new SinhVienEntityConfiguration())
                .ApplyConfiguration(new TruongEntityConfiguration())
                .ApplyConfiguration(new UserEntityConfiguration(_encryptor))
                ;
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public int SaveEntities()
        {
            var result = base.SaveChanges();
            return result;
        }
    }
}
