using System.Net;

namespace ManageStudents.API.Application.Exceptions
{
    public class ConflictException : BaseHttpException
    {
        public ConflictException(string message) : base(message)
        {
            HttpStatusCode = HttpStatusCode.Conflict;
        }
    }
}