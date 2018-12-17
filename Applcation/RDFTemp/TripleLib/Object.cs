using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleLib
{
    /// <summary>
    /// Значение параметра
    /// </summary>
    public class Object
    {
        public string ID;
        public object Name;
    }

    public class ListObject
    {
        public List<Object> List = new List<Object>();

        public bool isAvaible(Object o)
        {
            bool r = false;
            foreach (var item in List)
            {
                if (item.Name == o.Name)
                {
                    r = true;
                    break;
                }
            }
            return r;
        }

        public Object getObject(string ID)
        {
            Object result = new Object();
            foreach (var item in List)
            {
                if (item.ID == ID)
                {
                    result = item;
                }
            }
            return result;
        }

        public void Load()
        {
            List = (Const.Load(Const.FILE_OBJECT, "Object") as List<Object>);
        }

        public void Save()
        {
            Const.Save(Const.FILE_OBJECT, List);
        }
    }

    public class Property
    {
        public string ID;
        public object Name;

        public Property()
        {

        }

        public Property(object _Name)
        {
            ID = Const.getId(_Name.ToString());
            Name = _Name;
        }
    }

    public class ListProperty
    {
        public List<Property> List = new List<Property>();



        public void Load()
        {
            List = (Const.Load(Const.FILE_PREDICAT, "Property") as List<Property>);
        }

        public void Save()
        {
            Const.Save(Const.FILE_PREDICAT, List);
        }
    }

    public class Resource
    {
        public string ID;
        public object Name;

        public Resource()
        {

        }

        public Resource(object _Name)
        {
            ID = Const.getId(_Name.ToString());
            Name = _Name;
        }
    }

    public class ListResource
    {
        public List<Resource> List = new List<Resource>();

        public void Load()
        {
            List = (Const.Load(Const.FILE_SUBJECT, "Resource") as List<Resource>);
        }

        public void Save()
        {
            Const.Save(Const.FILE_SUBJECT, List);
        }
    }
}
