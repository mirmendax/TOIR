﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VDS.RDF;
using VDS.RDF.Query;
using VDS.RDF.Parsing;
using VDS.RDF.Writing;
using VDS.RDF.Writing.Formatting;
using VDS.RDF.Storage;

namespace dotNetProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SparqlParameterizedString sql = Predicat.Prefix();

            sql.CommandText = "SELECT ?s ?p ?o ?k ?rr WHERE { ?a prop:type type:o . ?a prop:title ?s . ?a prop:color ?t . ?t prop:title ?p . ?a prop:place ?d . ?d prop:title ?o . OPTIONAL { ?a prop:control ?f . ?f prop:title ?k } OPTIONAL {?a prop:powered ?ss . ?ss prop:title ?rr} } ORDER BY ?k ";
            //sql.CommandText = "SELECT DISTINCT ?Concept WHERE {[] a ?Concept}";
            //textBox1.Text = sql.ToString();
//
            SparqlQueryParser sqlp = new SparqlQueryParser();
            SparqlQuery sparql = sqlp.ParseFromString(sql);
            SparqlRemoteEndpoint Send = new SparqlRemoteEndpoint(Predicat.URI_End_Point_QUERY);
            SparqlResultSet result = Send.QueryWithResultSet(sparql.ToString());
            List<string> rr = new List<string>();
            foreach (var item in result)
            {
                INode n;
                String data = "";
                String data2 = "";
                String data3 = "";
                String data4 = "";
                String data5 = "";

                if (item.TryGetValue("s", out n))
                {
                    if (n != null)
                        switch (n.NodeType)
                        {
                            case NodeType.Blank:
                                data = ((IBlankNode)n).InternalID;
                                break;
                            case NodeType.GraphLiteral:
                                data = ((ILiteralNode)n).Value;
                                break;
                            case NodeType.Literal:
                                data = ((ILiteralNode)n).Value;
                                break;
                            case NodeType.Uri:
                                data = ((IUriNode)n).Uri.AbsoluteUri;
                                
                                break;
                            default:
                                break;
                        }
                }
                else { data = string.Empty; }
                //rr.Add(data);
                if (item.TryGetValue("p", out n))
                {
                    if (n != null)
                        switch (n.NodeType)
                        {
                            case NodeType.Blank:
                                data2 = ((IBlankNode)n).InternalID;
                                break;
                            case NodeType.GraphLiteral:
                                data2 = ((ILiteralNode)n).Value;
                                break;
                            case NodeType.Literal:
                                data2 = ((ILiteralNode)n).Value;
                                break;
                            case NodeType.Uri:
                                data2 = ((IUriNode)n).Uri.AbsoluteUri;
                                break;
                            default:
                                break;
                        }
                }
                else { data2 = string.Empty; }
                if (item.TryGetValue("o", out n))
                {
                    if (n != null)
                        switch (n.NodeType)
                        {
                            case NodeType.Blank:
                                data3 = ((IBlankNode)n).InternalID;
                                break;
                            case NodeType.GraphLiteral:
                                data3 = ((ILiteralNode)n).Value;
                                break;
                            case NodeType.Literal:
                                data3 = ((ILiteralNode)n).Value;
                                break;
                            case NodeType.Uri:
                                data3 = ((IUriNode)n).Uri.AbsoluteUri;
                                break;
                            default:
                                break;
                        }
                }
                else { data3 = string.Empty; }
                if (item.TryGetValue("k", out n))
                {
                    if (n != null)
                        switch (n.NodeType)
                        {
                            case NodeType.Blank:
                                data4 = ((IBlankNode)n).InternalID;
                                break;
                            case NodeType.GraphLiteral:
                                data4 = ((ILiteralNode)n).Value;
                                break;
                            case NodeType.Literal:
                                data4 = ((ILiteralNode)n).Value;
                                break;
                            case NodeType.Uri:
                                data4 = ((IUriNode)n).Uri.AbsoluteUri;
                                break;
                            default:
                                break;
                        }
                }
                else { data4 = string.Empty; }
                if (item.TryGetValue("rr", out n))
                {
                    if (n != null)
                        switch (n.NodeType)
                        {
                            case NodeType.Blank:
                                data5 = ((IBlankNode)n).InternalID;
                                break;
                            case NodeType.GraphLiteral:
                                data5 = ((ILiteralNode)n).Value;
                                break;
                            case NodeType.Literal:
                                data5 = ((ILiteralNode)n).Value;
                                break;
                            case NodeType.Uri:
                                data5 = ((IUriNode)n).Uri.AbsoluteUri;
                                break;
                            default:
                                break;
                        }
                }
                else { data4 = string.Empty; }
                rr.Add(data+" имеет цвет: "+data2+" находится в цеху "+data3);
                if (data4 != string.Empty) rr.Add("управляет " +data4);
                if (data5 != string.Empty) rr.Add("питается от " + data5);
            }
            textBox2.Lines = rr.ToArray();
            textBox1.Text = sparql.ToString();
            //SparqlTsvWriter r = new
            SparqlTsvWriter res = new SparqlTsvWriter();
            res.Save(result, "resuly.txt");
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Добавить оборудование
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            SparqlParameterizedString sql = Predicat.Prefix();
            string name = Tools.Translate(textBox3.Text);
            sql.CommandText = @"INSERT DATA { o:" + name + " prop:type type:o; prop:title '" + textBox3.Text + "' ";
            if (label9.Text == "OK!")
                sql.CommandText += @"; prop:color <" + Predicat.GetColorUri(textBox5.Text) + ">";
            if (label8.Text == "OK!")
                sql.CommandText += @"; prop:place <" + Predicat.GetManufactoryUri(textBox4.Text)+">";
            if (label10.Text == "OK!")
                sql.CommandText += @"; prop:control <"+Predicat.GetOUri(textBox6.Text)+">";
            if (label12.Text == "OK!")
                sql.CommandText += @"; prop:powered <"+Predicat.GetOUri(textBox12.Text)+">";
            if (label5.Text == "OK!")
                sql.CommandText += @"; prop:DCpowered <" + Predicat.GetOUri(textBox7.Text) + ">";

            sql.CommandText += " } ";
            //sql.CommandText += " prop:title '"+textBox8.Text+"' }";
            textBox2.Text = sql.ToString();

            FusekiConnector conn = new FusekiConnector(Predicat._FUSEKI);
            conn.Update(sql.ToString());
        }
        /// <summary>
        /// Список цехов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            SparqlParameterizedString sql = Predicat.Prefix();

            sql.CommandText = "SELECT ?c WHERE {?a prop:type type:manufactory . ?a prop:title ?c}";

            SparqlQueryParser query = new SparqlQueryParser();
            SparqlQuery sparql = query.ParseFromString(sql);

            SparqlRemoteEndpoint ep = new SparqlRemoteEndpoint(Predicat.URI_End_Point_QUERY);
            SparqlResultSet result = ep.QueryWithResultSet(sparql.ToString());
            List<string> list = new List<string>();
            foreach (var item in result)
            {
                INode n;
                if (item.TryGetValue("c", out n))
                {
                    if (n != null)
                    {
                        list.Add(((ILiteralNode)n).Value);
                    }
                }
            }
            textBox2.Lines = list.ToArray();

        }
        /// <summary>
        /// Добавить цех
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            SparqlParameterizedString sql = Predicat.Prefix();
            string name = Tools.Translate(textBox8.Text);
            sql.CommandText = @"INSERT DATA { manufactory:" + name + " prop:type type:manufactory ; prop:title '"+textBox8.Text+"'}";
            //sql.CommandText += " prop:title '"+textBox8.Text+"' }";
            //textBox2.Text = @"INSERT DATA { <" + Predicat._Host + "manufactory#" + name + "> <" + Predicat._Host + "prop#type> <" + Predicat._Host + "type#manufactory> }";

            FusekiConnector conn = new FusekiConnector(Predicat._FUSEKI);
            conn.Update(sql.ToString());
             
        }

        /// <summary>
        /// Добавить цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click_1(object sender, EventArgs e)
        {
            SparqlParameterizedString sql = Predicat.Prefix();
            string name = Tools.Translate(textBox9.Text);
            sql.CommandText = @"INSERT DATA { color:" + name + " prop:type type:color ; prop:title '" + textBox9.Text + "'}";
            //sql.CommandText += " prop:title '"+textBox8.Text+"' }";
            FusekiConnector conn = new FusekiConnector(Predicat._FUSEKI);
            conn.Update(sql.ToString());
        }
        /// <summary>
        /// Список цветов
        /// /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            
            string sql = "SELECT ?c WHERE { ?a prop:type type:color . ?a prop:title ?c }";

            List<Dictionary<string, object>> result = Predicat.SQuery(sql);

            List<string> list = new List<string>();
            foreach (var item in result)
            {
                foreach (var r in item)
                {
                    if (r.Key == "c") list.Add(r.Value.ToString());
                }
            }
            textBox2.Lines = list.ToArray();
        }
        /// <summary>
        /// Check manufactory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {

            string sql = "ASK { ?a prop:type type:manufactory . ?a prop:title '" + textBox4.Text + "' }";
            bool result = Predicat.SAsk(sql);
            if (result)
            {
                label8.Text = "OK!";
            }
            else label8.Text = "null";

        }
        /// <summary>
        /// Проверить цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            
            string sql = "ASK { ?a prop:type type:color . ?a prop:title '" + textBox5.Text + "' }";
            bool result = Predicat.SAsk(sql);
            if (result)
            {
                label9.Text = "OK!";
            }
            else label9.Text = "null";
        }
        /// <summary>
        /// Список оборудования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            SparqlParameterizedString sql = Predicat.Prefix();
            sql.CommandText = "SELECT ?c WHERE { ?a prop:type type:o . ?a prop:title ?c}";

            SparqlQueryParser query = new SparqlQueryParser();
            SparqlQuery sparql = query.ParseFromString(sql);

            SparqlRemoteEndpoint ep = new SparqlRemoteEndpoint(Predicat.URI_End_Point_QUERY);
            SparqlResultSet result = ep.QueryWithResultSet(sparql.ToString());
            List<string> rr = new List<string>();
            foreach (var item in result)
            {
                INode n;
                if (item.TryGetValue("c", out n))
                {
                    if (n != null)
                    {
                        rr.Add(((ILiteralNode)n).Value);
                    }
                }
            }
            textBox2.Lines = rr.ToArray();
        }
        /// <summary>
        /// проверить оборудование
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            
            string sql = "ASK { ?a prop:type type:o . ?a prop:title '" + textBox6.Text + "' }";
            bool result = Predicat.SAsk(sql);

            if (result)
            {
                label10.Text = "OK!";
            }
            else label10.Text = "null";
        }

        private void button11_Click(object sender, EventArgs e)
        {

            List<Dictionary<string, object>> result = Predicat.SQuery("SELECT ?title ?f ?color ?place ?control ?powered WHERE { ?f prop:type type:o . ?f prop:title ?title FILTER regex(?title, '" + textBox10.Text + "', 'i') . ?f prop:color ?l . ?l prop:title ?color  . ?f prop:place ?d . ?d prop:title ?place OPTIONAL {?f prop:control ?g . ?g prop:title ?control } OPTIONAL { ?f prop:powered ?pp . ?pp prop:title ?powered } }");

            if (result.Count != 0)
            {
                if (result.Count < 2)
                {
                    foreach (var item in result[0])
                    {
                        if ((item.Key == "title") && (item.Value != null)) textBox3.Text = item.Value.ToString();
                        if ((item.Key == "place") && (item.Value != null)) textBox4.Text = item.Value.ToString();
                        if ((item.Key == "color") && (item.Value != null)) textBox5.Text = item.Value.ToString();
                        if ((item.Key == "control") && (item.Value != null)) textBox6.Text = item.Value.ToString();
                        if ((item.Key == "powered") && (item.Value != null)) textBox12.Text = item.Value.ToString();
                        
                    }
                }
                else
                {
                    List<string> str = new List<string>();
                    foreach (var item in result)
                    {
                        foreach (var dic in item)
                        {
                            if ((dic.Key == "title") && (dic.Value != null)) str.Add(dic.Value.ToString());
                            if ((dic.Key == "powered") && (dic.Value != null)) str.Add(dic.Value.ToString());
                        }
                    }
                    textBox2.Lines = str.ToArray();
                }
            }

           
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string text = string.Empty;
            string[] s = textBox11.Lines;
            foreach (var item in s)
            {
                text += item;
            }
            List<Dictionary<string, object>> rr = new List<Dictionary<string, object>>();
            rr = Predicat.SQuery(text);
            List<string> r = new List<string>();
            foreach (var item in rr)
            {
                string str = string.Empty;
                foreach (var dic in item)
                {
                    
                    if (dic.Value != null)
                        str += string.Format("{0}={1}\t", dic.Key, dic.Value.ToString());
                }
                r.Add(str);
            }
            textBox2.Lines = r.ToArray();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            string sql = "ASK { ?a prop:type type:o . ?a prop:title '" + textBox12.Text + "' }";
            bool result = Predicat.SAsk(sql);

            if (result)
            {
                label12.Text = "OK!";
            }
            else label12.Text = "null";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string sql = "ASK { ?a prop:type type:o . ?a prop:title '" + textBox7.Text + "' }";
            bool result = Predicat.SAsk(sql);

            if (result)
            {
                label5.Text = "OK!";
            }
            else label5.Text = "null";
        }
    }
}
