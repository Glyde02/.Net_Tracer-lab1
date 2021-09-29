using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace TracerLib
{
    public class Record
    {
        [XmlAttribute]
        public int ID;

        [XmlElement]
        public ThreadRes res;

        public Record(int key, ThreadRes res)
        {
            ID = key;
            this.res = res;
        }
        public Record()
        {

        }
    }

    public class Serializers
    {

        public void toXML(System.IO.Stream stream, TraceResult result)
        {
            List<Record> records = new List<Record>();
            foreach (int key in result.threads.Keys)
            {
                records.Add(new Record(key, result.threads[key]));
            }


            XmlSerializer formatter = new XmlSerializer(typeof(List<Record>));
            formatter.Serialize(stream, records);


            //XmlSerializer formatter = new XmlSerializer(typeof(TraceResult));

            //formatter.Serialize(stream, result.threads);

            //using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            //{


            //    Console.WriteLine("Объект сериализован");
            //}

        }

        public void toJSON(System.IO.Stream stream, TraceResult result)
        {
            List<Record> records = new List<Record>();
            foreach (int key in result.threads.Keys)
            {
                records.Add(new Record(key, result.threads[key]));
            }

            //string json = JsonSerializer.Serialize<List<Record>>(records);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            var stream2 = new StreamWriter(stream);
            stream2.AutoFlush = true;
            stream2.Write(json);

            //Console.WriteLine(json);
        }

    }
}
