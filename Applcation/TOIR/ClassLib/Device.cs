using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    [Serializable]
    public class Device
    {
        public string ID;
        public string Name;
        public string TypeDevice;
        /// <summary>
        /// Положение устройства 
        /// </summary>
        public PlacePosition Position = new PlacePosition();
        public List<Functional> ListFunctional = new List<Functional>();

        /// <summary>
        /// Дата ввода в эксплуатацию
        /// </summary>
        public DateTime DateEntry;
        /// <summary>
        /// Список компонентов входящих в устройство
        /// </summary>
        public List<AbsComponent> ListComponent = new List<AbsComponent>();

        public List<SimpleCharacter> ListSimpleCharacters = new List<SimpleCharacter>();


    }

    public class ListDevice
    {
        public List<Device> List = new List<Device>();

        public void Save()
        {
            Const.Save(Const.FILE_DEVICE, List);
        }

        public void Load()
        {
            List = (Const.Load(Const.FILE_DEVICE, "Device") as List<Device>);
        }
    }
}
