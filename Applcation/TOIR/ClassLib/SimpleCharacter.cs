using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    [Serializable]
    public class SimpleCharacter
    {
        public enum MetaType
        {
            String,
            Int,
            Bool,
            Double
        }
        /// <summary>
        /// Уникальный идентификатор Hash 
        /// </summary>
        public string ID;
        /// <summary>
        /// Название аттрибута (Длина, масса, давлние...)
        /// </summary>
        public string Name;


        /// <summary>
        /// Размерность аттрибута (метр, килограмм, кг/см2...)
        /// </summary>
        public string Dimension;
        
        private object Value1;

        /// <summary>
        /// Значение атрибута
        /// </summary>
        public object Value
        {
            get { return Value1; }
            set
            {
                if (value is string)
                {
                    MetaValueType = MetaType.String;
                    Value1 = new string(' ', 0);
                    
                }
                if (value is int)
                {
                    MetaValueType = MetaType.Int;
                    Value1 = new int();
                    
                }
                if (value is bool)
                {
                    MetaValueType = MetaType.Bool;
                    Value1 = new bool();
                    
                }
                if (value is Double)
                {
                    MetaValueType = MetaType.Double;
                    Value1 = new Double();
                }
                Value1 = value;
            }
        }

        
        /// <summary>
        /// Множитель (10^2, 10^3, 10^)
        /// </summary>
        public byte Factor = 1;
        /// <summary>
        /// Тип данных поля Value(string, int, bool, float...)
        /// </summary>
        public MetaType MetaValueType;



        public SimpleCharacter()
        {
            ID = Const.getId();
        }
    }

    public class ListSimpleCharacter
    {
        public List<SimpleCharacter> List = new List<SimpleCharacter>();

        public bool isDoubleCharacters(string Name)
        {
            bool result = false;
            foreach (var item in List)
            {
                if (Name == item.Name)
                {
                    result = true;
                }
            }
            return result;
        }

        public void AddSimpleCharacter(SimpleCharacter s_c)
        {
            s_c.ID = Const.getId(s_c.Name);
            if (!isDoubleCharacters(s_c.Name))
            {
                List.Add(s_c);
            }
        }
        public void AddSimpleCharacter(string Name, string Dimension, object value, byte factor = 1)
        {
            SimpleCharacter temp = new SimpleCharacter();
            temp.Name = Name;
            temp.Dimension = Dimension;
            temp.Value = value;
            temp.Factor = factor;
            temp.ID = Const.getId(Name);
            List.Add(temp);
        }

        public void Load()
        {
            List = (Const.Load(Const.FILE_SMPLCHAR, "SimpleCharacter") as List<SimpleCharacter>);
        }

        public void Save()
        {
            Const.Save(Const.FILE_SMPLCHAR, List);
        }
    }

}
