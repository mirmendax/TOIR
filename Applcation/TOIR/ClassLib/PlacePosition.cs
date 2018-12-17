using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    [Serializable]
    public class PlacePosition
    {
        public string ID;
        public string Name;
        public string Position;
        public string SubPosition;

    }
    [Serializable]
    public class ListPlacePositions
    {
        public List<PlacePosition> List = new List<PlacePosition>();

        public void Save()
        {
            Const.Save(Const.FILE_PLCPOSITION, List);
        }

        public void Load()
        {
            List = (Const.Load(Const.FILE_PLCPOSITION, "PlacePositions") as List<PlacePosition>);
        }

    }
}
