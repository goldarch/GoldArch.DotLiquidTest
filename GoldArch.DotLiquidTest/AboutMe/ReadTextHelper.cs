using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GoldArch.DotLiquidTest.AboutMe
{
    public class ReadTextHelper
    {
        public static string GetAboutMe()
        {
            //获得正在运行类所在的名称空间
            Type type = MethodBase.GetCurrentMethod().DeclaringType;
            string _namespace = type.Namespace;
            //获得当前运行的Assembly
            Assembly _assembly = Assembly.GetExecutingAssembly();
            //根据名称空间和文件名生成资源名称
            var resourceName = _namespace + ".AboutMe.txt";
            //根据资源名称从Assembly中获取此资源的Stream
            Stream stream = _assembly.GetManifestResourceStream(resourceName);

            byte[] StreamData = new byte[stream.Length];
            stream.Read(StreamData, 0, (int)stream.Length);

            //var str = System.Text.Encoding.ASCII.GetString(StreamData);
            var str = Encoding.GetEncoding("gb2312").GetString(StreamData);

            return str;
        }
    }
}
