using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testIS
{
    class Program
    {
        static object ar;
        static void Main(string[] args)
        {
            ar = 12.2d;
            if (ar is int) Console.WriteLine("Int");
            if (ar is string) Console.WriteLine("String");
            if (ar is Single) Console.WriteLine("Single");
            if (ar is float) Console.WriteLine("Float");
            if (ar is bool) Console.WriteLine("bool");
            if (ar is double) Console.WriteLine("double");
            Console.ReadKey();
        }
    }
}
