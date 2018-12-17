using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
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
