using System.Net;

namespace ManageStudents.API.Application.Exceptions
{
    public class BadRequestException : BaseHttpException
    {
        public BadRequestException(string message) : base(message)
        {
            HttpStatusCode = HttpStatusCode.BadRequest;
        }
    }
}