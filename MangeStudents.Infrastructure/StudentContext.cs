using Microsoft.EntityFrameworkCore;
using ManageStudent.Infrastructure.Abstractions;
using ManageStudent.Infrastructure.Encryption;
using System.Threading.Tasks;
using System.Threading;
using ManageStudent.Infrastructure.Entities;
using ManageStudent.Infrastructure.Configurations;

namespace ManageStudent.Infrastructure
{
    public class StudentContext: DbContext, IUnitOfWork
    {
        private readonly IEncryptor _encryptor;
        public const string DEFAULT_SCHEMA = "dbo";
        
        public DbSet<Template> Templates { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TemplateLocation> TemplateLocations { get; set; }

        public StudentContext(DbContextOptions<StudentContext> options, IEncryptor encryptor) : base(options)
        {
            _encryptor = encryptor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Template>();
            modelBuilder.Entity<Question>();
            modelBuilder.Entity<Answer>();
            modelBuilder.Entity<TemplateLocation>();

            modelBuilder.ApplyConfiguration(new TemplateEntityConfiguration(_encryptor))
                .ApplyConfiguration(new QuestionEntityConfiguration(_encryptor))
                .ApplyConfiguration(new AnswerEntityConfiguration(_encryptor))
                .ApplyConfiguration(new TemplateLocationEntityConfiguration())
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
