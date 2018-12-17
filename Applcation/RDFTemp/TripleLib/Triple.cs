using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleLib
{
    public class Triple
    {
        public string ID;
        private Resource _Resource;
        private Property _Property;
        private Object _Object;
        
        
        public Triple()
        {

        }

        public Property getProperty()
        {
            
            return _Property;
        }

        public Resource getResource()
        {
            return _Resource;
        }

        public Object getObject()
        {
            return _Object;
        }

    }

    public class ListTriple
    {
        public List<Triple> List = new List<Triple>();

        public List<Triple> getTriplebyResource(string idResource)
        {
            List<Triple> result = new List<Triple>();
            
            foreach (var item  in List)
            {
                if (item.getResource().ID == idResource)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public List<Resource> getResource(string idResource)
        {
            List<Resource> result = new List<Resource>();

            foreach (var item in List)
            {
                if (item.getResource().ID == idResource)
                    result.Add(item.getResource());
            }

            return result;
        }

        public List<Triple> getTriplebyProperty(string idProperty)
        {
            List<Triple> result = new List<Triple>();

            foreach (var item in List)
            {
                if (item.getProperty().ID == idProperty) {
                    result.Add(item);
                }
            }
            return result;
        }

        public List<Property> getProperty(string idProperty)
        {
            List<Property> result = new List<Property>();

            foreach (var item in List)
            {
                if (item.getProperty().ID == idProperty)
                    result.Add(item.getProperty());
            }
            return result;
        }

        public List<Triple> getTriplebyProperty(string idObject)
        {
            List<Triple> result = new List<Triple>();
            foreach (var item in List)
            {
                if (item.getObject().ID == idObject)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public List<Object> getObject(string idObject)
        {
            List<Object> result = new List<Object>();

            foreach (var item in List)
            {
                if (item.getObject().ID == idObject)
                    result.Add(item.getObject());
            }
            return result;
        }





        public void Load()
        {
            List = (Const.Load(Const.FILE_TRIPLET, "Triple") as List<Triple>);
        }

        public void Save()
        {
            Const.Save(Const.FILE_TRIPLET, List);
        }
    }
}
