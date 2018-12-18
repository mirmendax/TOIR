using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Query;

namespace dotNetProject
{
    public class Predicat
    {
        public static string URIMain = "http://localhost/p#";
        
        public static Uri Name = UriFactory.Create(URIMain + "Name");
        public static Uri FamilyName = UriFactory.Create(URIMain + "FName");
        public static Uri Age = UriFactory.Create(URIMain + "Age");
        public static Uri Mother = UriFactory.Create(URIMain + "Mother");
        public static string _Host = "http://localhost/";
        public static string _FUSEKI = "http://localhost:3030/newdate/data";
        public static Uri URI_End_Point_QUERY = new Uri("http://localhost:3030/newdate/sparql");
        public static Uri URI_End_Point_UPDATE = new Uri("http://localhost:3030/newdate/update");


        public static SparqlParameterizedString Prefix()
        {
            SparqlParameterizedString sql = new SparqlParameterizedString();
            sql.Namespaces.AddNamespace("", new Uri(_Host));
            sql.Namespaces.AddNamespace("o", new Uri(_Host + "oborudovanie#"));
            sql.Namespaces.AddNamespace("prop", new Uri(_Host + "property#"));
            sql.Namespaces.AddNamespace("color", new Uri(_Host + "color#"));
            sql.Namespaces.AddNamespace("manufactory", new Uri(_Host + "manufactory#"));
            sql.Namespaces.AddNamespace("type", new Uri(_Host + "type#"));
            return sql;
        }

        public static string GetColorUri(string color)
        {
            SparqlParameterizedString sql = Predicat.Prefix();

            sql.CommandText = "SELECT ?a WHERE {?a prop:type type:color . ?a prop:title '"+color+"'}";

            SparqlQueryParser query = new SparqlQueryParser();
            SparqlQuery sparql = query.ParseFromString(sql);

            SparqlRemoteEndpoint ep = new SparqlRemoteEndpoint(Predicat.URI_End_Point_QUERY);
            SparqlResultSet result = ep.QueryWithResultSet(sparql.ToString());
            string res = string.Empty;
            foreach (var item in result)
            {
                INode u;
                
                if (item.TryGetValue("a", out u))
                {
                    if (u != null)
                    {
                        res = ((IUriNode)u).Uri.AbsoluteUri;
                    }
                }

                
            }
            return res;
        }
        public static string GetManufactoryUri(string manufactory)
        {
            SparqlParameterizedString sql = Predicat.Prefix();

            sql.CommandText = "SELECT ?a WHERE {?a prop:type type:manufactory . ?a prop:title '" + manufactory + "'}";

            SparqlQueryParser query = new SparqlQueryParser();
            SparqlQuery sparql = query.ParseFromString(sql);

            SparqlRemoteEndpoint ep = new SparqlRemoteEndpoint(Predicat.URI_End_Point_QUERY);
            SparqlResultSet result = ep.QueryWithResultSet(sparql.ToString());
            string res = string.Empty;
            foreach (var item in result)
            {
                INode u;

                if (item.TryGetValue("a", out u))
                {
                    if (u != null)
                    {
                        res = ((IUriNode)u).Uri.AbsoluteUri;
                    }
                }


            }
            return res;
        }
        public static string GetOUri(string o)
        {
            SparqlParameterizedString sql = Predicat.Prefix();

            sql.CommandText = "SELECT ?a WHERE {?a prop:type type:o . ?a prop:title '" + o + "'}";

            SparqlQueryParser query = new SparqlQueryParser();
            SparqlQuery sparql = query.ParseFromString(sql);

            SparqlRemoteEndpoint ep = new SparqlRemoteEndpoint(Predicat.URI_End_Point_QUERY);
            SparqlResultSet result = ep.QueryWithResultSet(sparql.ToString());
            string res = string.Empty;
            foreach (var item in result)
            {
                INode u;

                if (item.TryGetValue("a", out u))
                {
                    if (u != null)
                    {
                        res = ((IUriNode)u).Uri.AbsoluteUri;
                    }
                }


            }
            return res;
        }

        public static List<Dictionary<string, object>> GetQuery(string query)
        {
            List<Dictionary<string, object>> ret = new List<Dictionary<string, object>>();

            string[] variable = new string[] { };

            int sel = query.IndexOf("SELECT");
            int whe = query.IndexOf("WHERE");
            int b = sel + ("SELECT").Length;
            string v = query.Substring(b + 1, whe - b - 1);
            v = v.Replace(" ", "");
            variable = v.Split(new Char[] { '?' }, StringSplitOptions.RemoveEmptyEntries);//Список переменных
            
            SparqlParameterizedString sql = Prefix();
            sql.CommandText = query;

            SparqlQueryParser parse = new SparqlQueryParser();
            SparqlQuery q = parse.ParseFromString(sql);

            SparqlRemoteEndpoint ep = new SparqlRemoteEndpoint(URI_End_Point_QUERY);
            SparqlResultSet result = ep.QueryWithResultSet(q.ToString());

            if (result.Count != 0)
            {
                foreach (var item in result)
                {
                    Dictionary<string, object> oo = new Dictionary<string, object>();
                    for (int i = 0; i < variable.Length; i++)
                    {
                        INode n;
                        if (item.TryGetValue(variable[i], out n))
                        {
                            if (n !=null)
                                switch (n.NodeType)
                                {
                                    case NodeType.Blank:
                                        oo.Add(variable[i], ((IBlankNode)n));
                                        //oo.Key ((IBlankNode)n).InternalID;
                                        break;
                                    case NodeType.GraphLiteral:
                                        oo.Add(variable[i], ((ILiteralNode)n));
                                        break;
                                    case NodeType.Literal:
                                        oo.Add(variable[i], ((ILiteralNode)n));
                                        break;
                                    case NodeType.Uri:
                                        oo.Add(variable[i], ((IUriNode)n));
                                        break;
                                    case NodeType.Variable:
                                        oo.Add(variable[i], ((ITripleStore)n));
                                        break;

                                    default:
                                        oo.Add(variable[i], null);
                                        break;
                                }
                            else
                            {
                                oo.Add(variable[i], null);
                            }
                        }
                    }
                    ret.Add(oo);
                }
            }

            return ret;
        }

    }
}
