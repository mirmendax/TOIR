using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace dotNetProject
{
    public class Tools
    {
        private static string Tr2(string s)
        {
            StringBuilder ret = new StringBuilder();
            s = s.ToUpper();
            string[] rus = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц",   
                                "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", " ", "1" , "2", "3", "4", "5", "6", "7", "8", "9", "0"};
            string[] eng = { "A", "B", "V", "G", "D", "E", "E", "ZH", "Z", "I", "Y", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "KH", "TS",   
                                "CH", "SH", "SHCH", null, "Y", null, "E", "YU", "YA" , "_", "1" , "2", "3", "4", "5", "6", "7", "8", "9", "0"};

            for (int j = 0; j < s.Length; j++)
                for (int i = 0; i < rus.Length; i++)
                    if (s.Substring(j, 1) == rus[i]) ret.Append(eng[i]);
            return ret.ToString().ToLower();
        }


        public static string NAmetoUTF(string str)
        {
            return Tr2(str);
        }
    }
}
