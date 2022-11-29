using System;
using System.Text;

namespace ExtendString
{
    public static class StringExtension
    {
        private static Random random;
        static StringExtension()
        {
            random = new Random();
        }

        public static string ToRandomCase(this string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach(char c in s)
            {
                if (random.NextDouble()<0.5)
                {
                    sb.Append (char.ToUpper(c));
                }
                else
                {
                    sb.Append (char.ToLower(c));
                }
                return sb.ToString();
            }
        }
    }
}