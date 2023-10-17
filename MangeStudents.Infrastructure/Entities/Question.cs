using ManageStudents.Infrastructure.Abstractions;

namespace ManageStudent.Infrastructure.Entities
{
    public class Question : DeletableEntity<Guid>
    {
        public string Text { get; set; }
        public bool AllowOtherAnswer { get; set; }
        public bool AllowMultiple { get; set; }
        public Guid TemplateId { get; set; }
        public virtual Template Template { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
