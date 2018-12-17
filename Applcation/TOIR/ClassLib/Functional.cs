using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    [Serializable]
    public class Functional
    {
        public string ID;
        public string Name;

        public List<Functional> ListFunctional = new List<Functional>();

    }

    public class ListFunctional
    {
        public List<Functional> List = new List<Functional>();


    }
}
