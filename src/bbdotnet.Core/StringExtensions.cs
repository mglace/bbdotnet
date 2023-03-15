using System.Globalization;
using System.Text;

namespace bbdotnet;

public static class StringExtensions
{
    public static bool ContainsOnlyPrintableChars(this string value)
    {
        var len = value.Length;
        char c;

        for (var i = 0; i < len; i++)
        {
            c = value[i];

            if (c > 126)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>http://stackoverflow.com/questions/25259/how-does-stack-overflow-generate-its-seo-friendly-urls</remarks>
    /// <param name="title"></param>
    /// <param name="maxlen"></param>
    /// <param name="separator"></param>
    /// <returns></returns>
    public static string NormalizeString(this string title, char separator = ' ', int? maxlen = null)
    {
        if (title == null) return string.Empty;

        var len = title.Length;
        var prevdash = false;
        var sb = new StringBuilder(len);
        char c;

        for (var i = 0; i < len; i++)
        {
            c = title[i];
            if (c >= 'a' && c <= 'z' || c >= '0' && c <= '9')
            {
                sb.Append(c);
                prevdash = false;
            }
            else if (c >= 'A' && c <= 'Z')
            {
                // tricky way to convert to lowercase
                sb.Append((char)(c | 32));
                prevdash = false;
            }
            else if (c == ' ' || c == ',' || c == '.' || c == '/' ||
                     c == '\\' || c == '-' || c == '_' || c == '=')
            {
                if (!prevdash && sb.Length > 0)
                {
                    sb.Append(separator);
                    prevdash = true;
                }
            }
            else if (c >= 128)
            {
                var prevlen = sb.Length;
                sb.Append(RemapInternationalCharToAscii(c));
                if (prevlen != sb.Length) prevdash = false;
            }
            if (i == maxlen) break;
        }

        return prevdash ? sb.ToString().Substring(0, sb.Length - 1) : sb.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>http://meta.stackoverflow.com/questions/7435/non-us-ascii-characters-dropped-from-full-profile-url/7696#7696</remarks>
    /// <param name="c"></param>
    /// <returns></returns>
    public static string RemapInternationalCharToAscii(char c)
    {
        var s = c.ToString(CultureInfo.InvariantCulture).ToLowerInvariant();

        if ("àåáâäãåą".Contains(s)) return "a";
        if ("èéêëę".Contains(s)) return "e";
        if ("ìíîïı".Contains(s)) return "i";
        if ("òóôõöøőð".Contains(s)) return "o";
        if ("ùúûüŭů".Contains(s)) return "u";
        if ("çćčĉ".Contains(s)) return "c";
        if ("żźž".Contains(s)) return "z";
        if ("śşšŝ".Contains(s)) return "s";
        if ("ñń".Contains(s)) return "n";
        if ("ýÿ".Contains(s)) return "y";
        if ("ğĝ".Contains(s)) return "g";
        if ("Ææ".Contains(s)) return "ae";
        if (c == 'ř') return "r";
        if (c == 'ł') return "l";
        if (c == 'đ') return "d";
        if (c == 'ß') return "ss";
        if (c == 'Þ') return "th";
        if (c == 'ĥ') return "h";
        if (c == 'ĵ') return "j";

        return "";
    }
}
