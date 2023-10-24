using System.Net;

namespace ManageStudents.API.Application.Exceptions
{
    public class UnauthorizedException : BaseHttpException
    {
        public UnauthorizedException(string message) : base(message)
        {
            HttpStatusCode = HttpStatusCode.Unauthorized;
        }
    }
}