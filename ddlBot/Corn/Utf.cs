﻿using System.Globalization;
using System.Text.RegularExpressions;

namespace CornSDK
{
    static class Utf
    {
        public static string Encode(string s)
        {
            var reUnicodeChar = new Regex(@"[^\u0000-\u00ff]", RegexOptions.Compiled);
            return reUnicodeChar.Replace(s, m => string.Format(@"\u{0:x4}", (short) m.Value[0]));
        }

        public static string Decode(string value)
        {
            var regexUtfEscape = new Regex(@"\\u(?<Value>[a-zA-Z0-9]{4})", RegexOptions.Compiled);
            return regexUtfEscape.Replace(
                value,
                m => ((char) int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString()
            );
        }
    }
}