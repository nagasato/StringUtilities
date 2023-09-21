using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringUtilities
{
    /// <summary>
    /// ByteStringExtensions
    /// </summary>
    public static class ByteStringExtensions
    {
        /// <summary>
        /// valueをbyteLengthずつに区切って列挙する
        /// (多バイト文字の途中で区切られないように考慮)
        /// <param name="value"></param>
        /// <param name="byteLength"></param>
        /// <param name="encoding">省略した場合はShift_JIS</param>
        /// <returns></returns>
        public static IEnumerable<string> FixedByteSplit(this string value, int byteLength, Encoding encoding)
        {
            if (value == null) { throw new ArgumentNullException(); }

            var s = value;
            while (!string.IsNullOrEmpty(s))
            {
                // lengthバイトまでの文字をcharとして列挙->string生成
                var chars = s.TakeWhile((c, i) => encoding.GetByteCount(s.Substring(0, i + 1)) <= byteLength).ToArray();
                var cutout = new string(chars);
                yield return cutout;

                s = s.Replace(cutout, string.Empty); // 切り出した分を詰める
            }
        }

        /// <summary>
        /// valueをbyteLengthになるようにPadCharで右埋めにする
        /// </summary>
        /// <param name="value"></param>
        /// <param name="byteLength">byte数</param>
        /// <param name="encoding"></param>
        /// <param name="padChar">省略した場合は空白</param>
        /// <returns></returns>
        public static string PadByteRight(this string value, int byteLength, Encoding encoding, char padChar = ' ')
        {
            if (value == null) { throw new ArgumentNullException(); }

            encoding ??= Encoding.GetEncoding("Shift_JIS");
            var valueLen = encoding.GetByteCount(value);
            if (valueLen >= byteLength) { return value; }

            var pad = new string(padChar, byteLength - valueLen);
            return value + pad;
        }

        /// <summary>
        /// valueをbyteLengthになるようにPadCharで左埋めにする
        /// </summary>
        /// <param name="value"></param>
        /// <param name="byteLength">byte数</param>
        /// <param name="encoding"></param>
        /// <param name="padChar">省略した場合は空白</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string PadByteLeft(this string value, int byteLength, Encoding encoding, char padChar = ' ')
        {
            if (value == null) { throw new ArgumentNullException(); }

            var valueLen = encoding.GetByteCount(value);
            if (valueLen >= byteLength) { return value; }

            var pad = new string(padChar, byteLength - valueLen);
            return pad + value;
        }
    }
}
