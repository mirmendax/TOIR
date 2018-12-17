using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TripleLib
{
    public class Const
    {
        public const string FILE_OBJECT = "obj.dat";
        public const string FILE_SUBJECT = "sub.dat";
        public const string FILE_PREDICAT = "pred.dat";
        public const string FILE_TRIPLET = "trip.dat";

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
    public class Log
    {
        /// <summary>
        /// Запись журнала ошибок
        /// </summary>
        /// <param name="sLog">Текст ошибки</param>
        public Log(string sLog)
        {
            if (!File.Exists(Const.FILE_LOG))
            {
                StreamWriter createfile = File.CreateText(Const.FILE_LOG);
                createfile.Close();
            }
            StreamWriter addlog = File.AppendText(Const.FILE_LOG);

            addlog.WriteLine("[" + DateTime.Now.ToString("d.MM.yyyy") + "(" + DateTime.Now.ToString("HH:mm") + ")]" + sLog);
            addlog.Close();
        }
    }
}
