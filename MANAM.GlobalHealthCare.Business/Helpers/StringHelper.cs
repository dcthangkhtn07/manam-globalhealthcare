using System.Globalization;
using System.Text;

namespace MANAM.GlobalHealthCare.Business.Helpers
{
    public static class StringHelper
    {
        public static string GenerateSlugUrl(this string phrase)
        {
            int maxLength = 100;

            if (phrase == null)
                return "";

            var normalizedString = phrase.ToLowerInvariant().Normalize(NormalizationForm.FormD);

            var stringBuilder = new StringBuilder();
            var stringLength = normalizedString.Length;
            var prevdash = false;
            var trueLength = 0;

            char c;

            for (int i = 0; i < stringLength; i++)
            {
                c = normalizedString[i];

                switch (CharUnicodeInfo.GetUnicodeCategory(c))
                {
                    case UnicodeCategory.LowercaseLetter:
                    case UnicodeCategory.UppercaseLetter:
                    case UnicodeCategory.DecimalDigitNumber:
                        if (c < 128)
                            stringBuilder.Append(c);
                        else
                            stringBuilder.Append(c.RemapInternationalCharToAscii());

                        prevdash = false;
                        trueLength = stringBuilder.Length;
                        break;

                    case UnicodeCategory.SpaceSeparator:
                    case UnicodeCategory.ConnectorPunctuation:
                    case UnicodeCategory.DashPunctuation:
                    case UnicodeCategory.OtherPunctuation:
                    case UnicodeCategory.MathSymbol:
                        if (!prevdash)
                        {
                            stringBuilder.Append('-');
                            prevdash = true;
                            trueLength = stringBuilder.Length;
                        }
                        break;
                }

                if (maxLength > 0 && trueLength >= maxLength)
                    break;
            }

            var result = stringBuilder.ToString().Trim('-');

            return maxLength <= 0 || result.Length <= maxLength ? result : result.Substring(0, maxLength);
        }

        public static string RemapInternationalCharToAscii(this char c)
        {
            string s = c.ToString().ToLowerInvariant();
            if ("áàảãạăắằẳẵặâấầẩẫậ".Contains(s))
            {
                return "a";
            }
            else if ("éèẻẽẹêếềễệ".Contains(s))
            {
                return "e";
            }
            else if ("íìỉĩị".Contains(s))
            {
                return "i";
            }
            else if ("óòỏõọôốồổỗộơớờởỡợ".Contains(s))
            {
                return "o";
            }
            else if ("úùủũụưứừửữự".Contains(s))
            {
                return "u";
            }

            else if ("ýỳỷỹỵ".Contains(s))
            {
                return "y";
            }
            else if (c == 'đ')
            {
                return "d";
            }
            else
            {
                return "";
            }
        }
    }
}
