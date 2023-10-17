using ManageStudents.Infrastructure.Abstractions;

namespace ManageStudent.Infrastructure.Entities
{
    public class Template : AuditableEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<TemplateLocation> Locations { get; set; }
    }
}
