using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ruanmou.Framework.Extension
{
    public class XmlHelper
    {

        public static string ToXml<T>(T t) where T : new()
        {
            string fileName = @"";//文件名称与路径
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
                xmlFormat.Serialize(fStream, t);
            }
            string[] lines = File.ReadAllLines(fileName);
            return string.Join("", lines);
        }

        public static T ToObject<T>() where T : new()
        {
            string fileName = @"";//文件名称与路径
            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
                return (T)xmlFormat.Deserialize(fStream);
            }
        }

    }
}
