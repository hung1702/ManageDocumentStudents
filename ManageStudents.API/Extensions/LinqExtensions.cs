using System.Collections.Generic;
using System.Linq;

namespace ManageStudents.API.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> Paged<T>(this IEnumerable<T> t, int page, int items) where T : class
        {
            return t.Skip((page - 1) * items).Take(items);
        }
    }
}
