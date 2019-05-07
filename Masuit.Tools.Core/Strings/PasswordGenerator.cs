using System;
using System.Text;

namespace Masuit.Tools.Core.Strings
{
    /// <summary>
    /// 随机密码生成器
    /// </summary>
    public static class PasswordGenerator
    {
        private static string _numbers = "0123456789";
        private static string _symbols = ",./<>?;':\"[]\\{}|`~!@#$%^&*()_+-=";
        private static string _letter = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";

        /// <summary>
        /// 生成密码
        /// </summary>
        /// <returns></returns>
        public static string Generate() => Generate(PasswordOptions.Default);

        /// <summary>
        /// 生成密码
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string Generate(PasswordOptions options)
        {
            var source = new StringBuilder(_letter);
            var password = new StringBuilder();
            if (options.HasNumber)
            {
                source.Append(_numbers);
            }
            if (options.HasSymbol)
            {
                source.Append(_symbols);
            }

            var sourceSpan = source.ToString().AsSpan();
            var max = source.Length;
            var r = new Random();
            for (var i = 0; i < options.Length; i++)
            {
                var index = r.Next(0, max);
                password.Append(sourceSpan[index]);
            }

            return password.ToString();
        }
    }

    /// <summary>
    /// 配置
    /// </summary>
    public class PasswordOptions
    {
        /// <summary>
        /// 默认配置
        /// </summary>
        public static PasswordOptions Default => new PasswordOptions(10, false, false);

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="length">密码长度</param>
        /// <param name="hasNumber">是否包含数字</param>
        /// <param name="hasSymbol">是否包含符号</param>
        public PasswordOptions(int length, bool hasNumber, bool hasSymbol)
        {
            Length = length;
            HasNumber = hasNumber;
            HasSymbol = hasSymbol;
        }

        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// 是否包含数字
        /// </summary>
        public bool HasNumber { get; set; }
        /// <summary>
        /// 是否包含符号
        /// </summary>
        public bool HasSymbol { get; set; }
    }
}
