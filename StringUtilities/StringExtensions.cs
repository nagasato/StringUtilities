using System;
using System.Collections.Generic;
using System.Linq;

namespace StringUtilities
{
    /// <summary>
    /// StringExtensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 文字列から制御文字を除去した文字列を取得する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveControlChars(this string value)
        {
            if (value == null) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(value)) { return value; }

            var s = value.Where(c => !char.IsControl(c)).ToArray(); // 制御文字を除去
            return new string(s);
        }

        /// <summary>
        /// 文字列の先頭・末尾の両端の制御文字と空白を除去した文字列を取得する
        /// </summary>
        /// <returns></returns>
        public static string TrimEx(this string value)
        {
            if (value == null) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(value)) { return value; }

            var s = value.TrimStartEx();
            s = s.TrimEndEx();
            return s;
        }

        /// <summary>
        /// 文字列の先頭側の制御文字と空白を除去した文字列を取得する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string TrimStartEx(this string value)
        {
            if (value == null) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(value)) { return value; }

            IEnumerable<char> removeChars = EnumerateStartControlAndSpaceChars(value);
            return value.TrimStart(removeChars.ToArray());
        }

        /// <summary>
        /// 文字列の末尾側の制御文字と空白を除去した文字列を取得する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string TrimEndEx(this string value)
        {
            if (value == null) { throw new ArgumentNullException(); }
            if (string.IsNullOrEmpty(value)) { return value; }

            IEnumerable<char> removeChars = EnumerateEndControlAndSpaceChars(value);
            return value.TrimEnd(removeChars.ToArray());
        }

        /// <summary>
        /// 先頭側の制御文字と空白文字を列挙する
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        private static IEnumerable<char> EnumerateStartControlAndSpaceChars(IEnumerable<char> chars)
        {
            foreach (char c in chars)
            {
                if (char.IsControl(c) || c == ' ')
                {
                    yield return c;
                    continue;
                }

                yield break;
            }
        }

        /// <summary>
        /// 末尾側の制御文字と空白文字を列挙する
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        private static IEnumerable<char> EnumerateEndControlAndSpaceChars(IEnumerable<char> chars)
        {
            var chars2 = chars.ToArray();
            for (var i = chars2.Length - 1; i < 0; i--)
            {
                char c = chars2[i];
                if (char.IsControl(c) || c == ' ')
                {
                    yield return c;
                    continue;
                }

                yield break;
            }
        }
    }
}
