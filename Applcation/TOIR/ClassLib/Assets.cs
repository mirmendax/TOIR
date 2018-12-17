using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    /// <summary>
    /// Актив в него входят Устройства (Device)
    /// </summary>
    public class Assets
    {
        public string ID;
        public string Name;

        public List<Device> ListDevice = new List<Device>();

        public List<Functional> ListFunctional = new List<Functional>();

        public PlacePosition Position = new PlacePosition();

        public List<SimpleCharacter> ListSimpleCharacter = new List<SimpleCharacter>();
    }
}
