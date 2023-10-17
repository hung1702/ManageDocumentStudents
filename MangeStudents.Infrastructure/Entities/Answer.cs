using ManageStudents.Infrastructure.Abstractions;

namespace ManageStudent.Infrastructure.Entities
{
    public class Answer : DeletableEntity<Guid>
    {
        public string Text { get; set; }
        public bool ActionRequired { get; set; }
        public Guid QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
