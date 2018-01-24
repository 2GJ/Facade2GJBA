using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;

namespace Facade2GJBA.Logic
{
    public class csQueryXMLSQL : csQuerySQL
    {
        #region Attrib

        private XmlDocument docxml;
        private List<csQueryColumn> Cols;
        private List<csQueryEntity> Ents;
        private List<csQueryFilter> Fill;

        #endregion

        #region Constructor

        public csQueryXMLSQL(String In_XML)
        {
            try
            {
                this.docxml = new XmlDocument();
                this.docxml.LoadXml(In_XML);
                this.Cols = new List<csQueryColumn>();
                this.Ents = new List<csQueryEntity>();
                this.Fill = new List<csQueryFilter>();
            }
            catch (Exception e)
            {
                Console.WriteLine("Facade Excepcion: " + e.Message.ToString());
                throw e;
            }
        }

        #endregion

        #region Operations

        public override void LoadDocXML()
        {
            XmlNode NodoQr = this.docxml.SelectSingleNode("/Facade2GJBA/Facade2GJBAQry");
            foreach (XmlNode xn in NodoQr)
            {
                string Atributo = xn.Name;

                switch (Atributo)
                {
                    case "Facade2GJBAColumns":
                        if (xn.ChildNodes.Count > 0)
                        {
                            foreach (XmlNode xnCol in xn.ChildNodes)
                            {
                                csQueryColumn NewCol = new csQueryColumn();
                                NewCol.LoadQrDocXMLCol(xnCol.OuterXml.ToString());
                                this.Cols.Add(NewCol);
                            }
                        }
                        break;

                    case "Facade2GJBAEntities":
                        if (xn.ChildNodes.Count > 0)
                        {
                            foreach (XmlNode xnEnt in xn.ChildNodes)
                            {
                                csQueryEntity NewEnt = new csQueryEntity();
                                NewEnt.LoadQrDocXMLCol(xnEnt.OuterXml.ToString());
                                this.Ents.Add(NewEnt);
                            }
                        }
                        break;

                    case "Facade2GJBAFilters":
                        if (xn.ChildNodes.Count > 0)
                        {
                            foreach (XmlNode xnFill in xn.ChildNodes)
                            {
                                csQueryFilter NewFill = new csQueryFilter();
                                NewFill.LoadQrDocXMLCol(xnFill.OuterXml.ToString());
                                this.Fill.Add(NewFill);
                            }
                        }
                        break;
                }
            }
        }

        public override void GenerateScript()
        {
            this.sScript = "SELECT ";
            foreach (csQueryColumn Col in this.Cols)
            {
                this.sScript += Col.GenerateColumn() + ", ";
            }
            this.sScript = this.sScript.Remove(this.sScript.Length - 2, 2) + " ";

            foreach (csQueryEntity Ent in this.Ents)
            {
                this.sScript += Ent.GenerateEntity();
            }

            foreach (csQueryFilter Fil in this.Fill)
            {
                this.sScript += Fil.GenerateFilter();
            }
        }
        
        #endregion
    }
}