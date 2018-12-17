using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLib;

namespace TOIR
{
    public partial class Form1 : Form
    {
        ListSimpleCharacter SC_List = new ListSimpleCharacter();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "String":
                    SC_List.AddSimpleCharacter(textBox1.Text, textBox2.Text, textBox3.Text);
                    break;
                case "Int":
                    SC_List.AddSimpleCharacter(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text));
                    break;
                case "Double": 
                    SC_List.AddSimpleCharacter(textBox1.Text, textBox2.Text, Double.Parse(textBox3.Text));
                    break;
                case "Bool":
                    SC_List.AddSimpleCharacter(textBox1.Text, textBox2.Text, Boolean.Parse(textBox3.Text));
                    break;
                default:
                    break;
            }
            SC_List.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ListMetaType = Enum.GetValues(typeof(SimpleCharacter.MetaType)).Cast<SimpleCharacter.MetaType>().ToList();
            foreach (var item in ListMetaType)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SC_List.Load();
            listBox1.Items.Clear();
            foreach (var item in SC_List.List)
            {
                string str = string.Format("{0} - [{1}] [{2}]", item.Name, item.Dimension, item.MetaValueType.ToString());
                listBox1.Items.Add(str);
            }
        }
    }
}
