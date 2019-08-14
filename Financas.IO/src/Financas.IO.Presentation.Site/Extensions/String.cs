using System.Globalization;
using System.Linq;
using System.Text;

namespace Financas.IO.Presentation.Site.Extensions
{
    public static class String
    {
        public static string RemoveAccents(this string str)
        {
            return new string(str
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
    }
}
