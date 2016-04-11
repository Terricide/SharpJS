using System.Linq;
using JSIL.Meta;

namespace System.Text.RegularExpressions
{
    [JSStubOnly]
    public class Regex
    {
        protected Regex()
        {
        }

        public Regex(string pattern)
        {
            this._pattern = pattern;
        }

        public Regex(string pattern, RegexOptions options)
        {
            this._pattern = pattern;
            this._options = options;
        }

        public static string Escape(string str)
        {
            string result;
            for (int i = 0; i < str.Length; i++)
            {
                if (Regex.IsMetachar(str[i]))
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    char c = str[i];
                    stringBuilder.Append(str, 0, i);
                    do
                    {
                        stringBuilder.Append('\\');
                        stringBuilder.Append(c);
                        i++;
                        int num = i;
                        while (i < str.Length)
                        {
                            c = str[i];
                            if (Regex.IsMetachar(c))
                            {
                                break;
                            }
                            i++;
                        }
                        stringBuilder.Append(str, num, i - num);
                    }
                    while (i < str.Length);
                    result = stringBuilder.ToString();
                    return result;
                }
            }
            result = str;
            return result;
        }

        public bool IsMatch(string input)
        {
            return true;
        }

        public bool IsMatch(string input, int startat)
        {
            string input2 = input.Substring(startat);
            return this.IsMatch(input2);
        }

        public static bool IsMatch(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern, RegexOptions.None);
        }

        public static bool IsMatch(string input, string pattern, RegexOptions options)
        {
            return new Regex(pattern, options).IsMatch(input);
        }

        internal static bool IsMetachar(char ch)
        {
            char[] source = new char[]
            {
                '\\',
                '*',
                '+',
                '?',
                '|',
                '{',
                '[',
                '(',
                ')',
                '^',
                '$',
                '.',
                '#',
                ' '
            };
            return source.ToList<char>().Contains(ch);
        }

        public Match Match(string input)
        {
            return Regex.Match(input, this._pattern, this._options);
        }

        public Match Match(string input, int startat)
        {
            string input2 = input.Substring(startat);
            return this.Match(input2);
        }

        public static Match Match(string input, string pattern)
        {
            return Regex.Match(input, pattern, RegexOptions.None);
        }

        public Match Match(string input, int beginning, int length)
        {
            string input2 = input.Substring(beginning, length);
            return this.Match(input2);
        }

        public static Match Match(string input, string pattern, RegexOptions options)
        {
            return new Regex(pattern, options).Match(input);
        }

        public MatchCollection Matches(string input)
        {
            return Regex.Matches(input, this._pattern, this._options);
        }

        public MatchCollection Matches(string input, int startat)
        {
            string input2 = input.Substring(startat);
            return this.Matches(input2);
        }

        public static MatchCollection Matches(string input, string pattern)
        {
            return Regex.Matches(input, pattern, RegexOptions.None);
        }

        public static MatchCollection Matches(string input, string pattern, RegexOptions options)
        {
            return new Regex(pattern, options).Matches(input);
        }

        public string Replace(string input, string replacement)
        {
            return Regex.Replace(input, this._pattern, replacement, this._options);
        }

        public static string Replace(string input, string pattern, string replacement)
        {
            return Regex.Replace(input, pattern, replacement, RegexOptions.None);
        }

        public static string Replace(string input, string pattern, string replacement, RegexOptions options)
        {
            return Regex.Replace(input, pattern, replacement, options);
        }

        public override string ToString()
        {
            return this._pattern;
        }

        public static string Unescape(string str)
        {
            string result;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '\\')
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(str, 0, i);
                    do
                    {
                        i++;
                        if (i == str.Length || str[i] == '\\')
                        {
                            stringBuilder.Append('\\');
                            i++;
                        }
                        int num = i;
                        while (i < str.Length && str[i] != '\\')
                        {
                            i++;
                        }
                        stringBuilder.Append(str, num, i - num);
                    }
                    while (i < str.Length);
                    result = stringBuilder.ToString();
                    return result;
                }
            }
            result = str;
            return result;
        }

        public RegexOptions Options
        {
            get
            {
                return this._options;
            }
        }

        public bool RightToLeft
        {
            get
            {
                return this._options.HasFlag(RegexOptions.RightToLeft);
            }
        }

        public static readonly TimeSpan InfiniteMatchTimeout = TimeSpan.MaxValue;

        private RegexOptions _options = RegexOptions.None;

        private string _pattern;
    }
}