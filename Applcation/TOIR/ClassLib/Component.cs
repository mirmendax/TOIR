using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    [Serializable]
    public class AbsComponent
    {
        public string ID;
        public string Name;
    }
    [Serializable]
    public class SimpleComponent : AbsComponent
    {

        /// <summary>
        /// Владелец
        /// </summary>
        public AbsComponent OwnerComponent = new AbsComponent();
        public int Count;
        /// <summary>
        /// Список простых характеристик
        /// </summary>
        public List<SimpleCharacter> SmplCharacterList = new List<SimpleCharacter>();
    }

    public class ListSimpleComponent
    {
        public List<SimpleComponent> List = new List<SimpleComponent>();

        public void Load()
        {
            List = (Const.Load(Const.FILE_SMPLCOMPONENT, "SimpleComponent") as List<SimpleComponent>);
        }

        public void Save()
        {
            Const.Save(Const.FILE_SMPLCOMPONENT, List);
        }
    }

    [Serializable]
    public class Component : AbsComponent
    {
        /// <summary>
        /// Владелец
        /// </summary>
        public Device OwnerDevice = new Device();
        /// <summary>
        /// Список составных компонентов
        /// </summary>
        public List<AbsComponent> PartComponentList = new List<AbsComponent>();
        /// <summary>
        /// Место положение из списка мест.
        /// </summary>
        public PlacePosition Position = new PlacePosition();
        /// <summary>
        /// Список простых характеристик
        /// </summary>
        public List<SimpleCharacter> SipleCharacterList = new List<SimpleCharacter>();
    }

    public class ListComponent
    {
        public List<Component> List = new List<Component>();

        public void Load()
        {
            List = (Const.Load(Const.FILE_COMPONENT, "Component") as List<Component>);
        }

        public void Save()
        {
            Const.Save(Const.FILE_COMPONENT, List);
        }
    }
}
