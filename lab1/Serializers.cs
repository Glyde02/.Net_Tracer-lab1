using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab1
{
    class Serializers
    {

        public void toXML(TraceResult result)
        {

            XmlSerializer formatter = new XmlSerializer(typeof(TraceResult));

            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, result);

                Console.WriteLine("Объект сериализован");
            }

        }

        //public void toJSON(TraceRes result)
        //{
        //    string jsonString = JsonConvert.SerializeObject(root, Formatting.Indented);
        //    var stream = new StreamWriter(serializationStream);
        //    stream.AutoFlush = true;
        //    stream.Write(jsonString);
        //}

    }
}
