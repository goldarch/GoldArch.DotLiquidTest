using System;

namespace GoldArch.DotLiquidTest.CustomFilter
{

    public class CustomFilters
    {
        /// <summary>
        /// 字符截断过滤器（测试用例）
        /// </summary>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Substr(string value, int startIndex, int length = -1)
        {
            if (length >= 0)
                return value.Substring(startIndex, length);
            return value.Substring(startIndex);
        }

        /// <summary>   
        /// 从左边填充字符串   
        /// </summary>   
        /// <param name="value">要操作的字符串</param>   
        /// <param name="totalWidth">结果字符串中的字符数</param>   
        /// <param name="paddingString">填充的字符</param>
        /// <returns>string</returns>   
        public static string left_pad(string value, int totalWidth, string paddingString)
        {
            if (value.Length < totalWidth)
            {
                var paddingChar = char.Parse(paddingString);
                return value.PadLeft(totalWidth, paddingChar);
            }

            return value;
        }

        public static string Left_pad_zero(string value, int totalWidth)
        {
            return left_pad(value, totalWidth, "0");
        }

        /// <summary>
        /// 来源于GoldArch.DataBase.QueryBuilder.WhereStatement
        /// </summary>
        /// <param name="someValue"></param>
        /// <returns></returns>
        public static string Format_sql(object someValue)
        {
            string str;
            if (someValue == null)
            {
                str = "NULL";
            }
            else
            {
                switch (someValue.GetType().Name)
                {
                    case "String":
                        str = "'" + ((string)someValue).Replace("'", "''") + "'";
                        break;
                    case "DateTime":
                        str = "'" + ((DateTime)someValue).ToString("yyyy/MM/dd HH:mm:ss") + "'";
                        break;
                    case "DBNull":
                        str = "NULL";
                        break;
                    case "Boolean":
                        str = (bool)someValue ? "1" : "0";
                        break;
                    case "Guid":
                        str = "'" + ((Guid)someValue) + "'";
                        break;
                    default:
                        str = someValue.ToString();
                        break;
                }
            }

            return str;
        }
    }
}
