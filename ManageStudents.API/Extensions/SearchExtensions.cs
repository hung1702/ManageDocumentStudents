using System.Web;
using System.Text.RegularExpressions;

namespace ManageStudents.API.Extensions
{
    public static class SearchExtensions
    {
        private static string FormatHtml(string text)
        {
            var regexText = Regex.Replace(text, @"\t|\n|\r|(&.*?;)|(<(.|\n)*?>)", " ").Trim();
            var result = HttpUtility.HtmlDecode(regexText).Trim();
            return result;
        }
    }
}
