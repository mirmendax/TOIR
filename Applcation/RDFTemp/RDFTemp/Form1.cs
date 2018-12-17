using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TripleLib;

namespace RDFTemp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Triple t = new Triple();
            TripleLib.Object o = new TripleLib.Object();
            Property p = new Property();
            Resource r = new Resource();
            
        }
    }
}
