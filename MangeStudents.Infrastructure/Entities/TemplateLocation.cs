using ManageStudents.Infrastructure.Abstractions;

namespace ManageStudent.Infrastructure.Entities
{
    public class TemplateLocation : IdentifiableEntity<Guid>
    {
        public Guid TemplateId { get; set; }
        public Guid LocationId { get; set; }
        public virtual Template Template { get; set; }
    }
}
