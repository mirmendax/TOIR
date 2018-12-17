using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Const
    {
        public const string FILE_SMPLCHAR = "simplechar.data";
        public const string FILE_PLCPOSITION = "place.data";
        public const string FILE_COMPONENT = "component.data";
        public const string FILE_SMPLCOMPONENT = "simplecomponent.data";
        public const string FILE_DEVICE = "device.data";

        public const string FILE_LOG = "error.log";



        public static string getId(string soul = "")
        {
            Random r = new Random();
            string iss = soul + DateTime.Now.ToString() + r.Next().ToString();
            MD5 m = MD5.Create();
            byte[] data = m.ComputeHash(Encoding.Default.GetBytes(iss));
            StringBuilder sB = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sB.Append(data[i].ToString("x2"));
            }
            return sB.ToString();
        }

        public static void Save(string _file, object Data)
        {
            BinaryFormatter _data = new BinaryFormatter();
            FileStream file = File.Open(_file, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            _data.Serialize(file, Data);
            file.Close();
        }

        public static object Load(string _file, string type)
        {
            object result = new object();
            BinaryFormatter data = new BinaryFormatter();
            if (!File.Exists(_file))
            {
                File.Open(_file, FileMode.OpenOrCreate, FileAccess.ReadWrite).Close();
            }
            FileStream file = File.Open(_file, FileMode.Open, FileAccess.ReadWrite);
            try
            {
                result = data.Deserialize(file);
            }
            catch (SerializationException ex)
            {
                new Log("Error load "+type+": " + ex.Message);
            }
            file.Close();
            return result;
        }

    }
}
