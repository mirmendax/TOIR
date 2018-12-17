using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VDS.RDF;
using VDS.RDF.Writing;
using VDS.RDF.Parsing;

namespace dotNetProject
{
    public partial class Form1 : Form
    {
        IGraph graph = new Graph();
        public Form1()
        {
            InitializeComponent();
            graph.NamespaceMap.AddNamespace("g", new Uri("http://localshot/"));
            //graph.LoadFromFile("rdf.txt", new RdfXmlParser());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IGraph graph = new Graph();

            
            textBox1.Clear();
            List<string> str = new List<string>();
            foreach (var item in graph.Triples)
            {
                str.Add(item.ToString());

            }
            textBox1.Lines = str.ToArray();

        }

        private void button2_Click(object sender, EventArgs e)
        {


            IUriNode name = graph.CreateUriNode(UriFactory.Create("http://localhost/" + Tools.NAmetoUTF(textBox2.Text)));
            
            graph.Assert(new Triple(name, graph.CreateUriNode(Predicat.Name), graph.CreateLiteralNode(textBox2.Text)));
            if (textBox3.Text != "")
                graph.Assert(new Triple(name, graph.CreateUriNode(Predicat.FamilyName), graph.CreateLiteralNode(textBox3.Text)));
            if (textBox4.Text != "")
                graph.Assert(new Triple(name, graph.CreateUriNode(Predicat.Age), graph.CreateLiteralNode(textBox4.Text)));

            if (textBox5.Text != "")
            {
                IGraph g = new Graph();
                
                IUriNode b =  graph.GetUriNode("g:" + Tools.NAmetoUTF(textBox5.Text));
                textBox6.Text = b.ToString();
                /*
                IUriNode mother = g.CreateUriNode(UriFactory.Create("http://localhost/" + Tools.NAmetoUTF(textBox5.Text)));
                //Uri r = UriFactory.Create();
                IEnumerable<Triple> result = graph.GetTriplesWithObject(mother);
               foreach (var item in result)
               {
                   if (item.Object.ToString() == textBox5.Text)
                   {
                       //graph.Assert(new Triple(name, graph.CreateUriNode(Predicat.Mother), item.Subject));
                       break;
                   }
               }
                 * */
            }


            

            graph.SaveToFile("rdf.txt", new RdfXmlWriter());

        }
    }
}
