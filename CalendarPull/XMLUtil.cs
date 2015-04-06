using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace CalendarPull
{
    public class XMLUtil
    {
        public static string Serialize<T>(T srcObject)
        {
            string srcObjectXml = string.Empty;

            XmlSerializer xmlSerializer = new XmlSerializer(srcObject.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                using (XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.UTF8))
                {
                    xtw.Formatting = Formatting.Indented;

                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");

                    xmlSerializer.Serialize(xtw, srcObject, ns);
                    ms.Seek(0, System.IO.SeekOrigin.Begin);

                    using (StreamReader reader = new StreamReader(ms))
                    {
                        srcObjectXml = reader.ReadToEnd();
                        xtw.Close();
                        reader.Close();
                    }
                }
            }
            return srcObjectXml;
        }

        public static T Deserialize<T>(string xmlString)
        {
            StringReader sr = new StringReader(xmlString);
            XmlTextReader xtr = new XmlTextReader(sr);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T instance = (T)xmlSerializer.Deserialize(xtr);
            xtr.Close();

            return instance;
        }
    }
}
