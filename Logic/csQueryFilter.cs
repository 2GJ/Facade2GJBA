using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;

namespace Facade2GJBA.Logic
{
    public class csQueryFilter
    {
        #region Attrib

        private String sUnion;
        private String sPr1;
        private String sAliasL;
        private String sOnLeft;
        private String sOpe;
        private String sAliasR;
        private String sOnRight;
        private String sPr2;    
        private String sValue;

        #endregion

        #region Constructores

        public csQueryFilter()
        {
            
        }

        #endregion

        #region Operations

        public String GenerateFilter()
        {
            String Res = "";

            switch (this.sUnion)
            {
                case "W":
                    Res += "WHERE ";
                    break;

                case "A":
                    Res += "AND ";
                    break;

                case "O":
                    Res += "OR ";
                    break;

                default:
                    break;
            }

            if (this.sPr1 != null && this.sPr1 != "")
            {
                Res += this.sPr1 + " ";
            }

            if (this.sAliasL != null && this.sAliasL != "")
                Res += this.sAliasL + "." + this.sOnLeft + " ";
            else
                Res += this.sOnLeft + " ";


            switch (this.sOpe)
            {
                case "I":
                    Res += "= ";
                    break;
                case "D":
                    Res += "<> ";
                    break;
                case "M":
                    Res += "> ";
                    break;
                case "N":
                    Res += "< ";
                    break;
                default:
                    break;
            }

            if (this.sAliasR != null && this.sAliasR != "")
                Res += this.sAliasR + "." + this.sOnRight + " ";
            else
                Res += this.sOnRight + " ";

            if (this.sPr2 != null && this.sPr2 != "")
            {
                Res += this.sPr2 + " ";
            }

            return Res;
        }

        public void LoadQrDocXMLCol(String In_xml)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(In_xml);
            XmlNode NodoQrCol = xdoc.FirstChild;

            if (NodoQrCol.Name == "Filter")
            {
                this.sValue = NodoQrCol.InnerText.ToString();
                foreach (XmlAttribute att in NodoQrCol.Attributes)
                {
                    String SlecAtt = att.Name;

                    switch (SlecAtt)
                    {
                        case "Union":
                            this.sUnion = att.InnerText.ToString();
                            break;
                        case "Pr1":
                            this.sPr1 = att.InnerText.ToString();
                            break;
                        case "AliasL":
                            this.sAliasL = att.InnerText.ToString();
                            break;
                        case "OnLeft":
                            this.sOnLeft = att.InnerText.ToString();
                            break;
                        case "Ope":
                            this.sOpe = att.InnerText.ToString();
                            break;
                        case "AliasR":
                            this.sAliasR = att.InnerText.ToString();
                            break;
                        case "OnRight":
                            this.sOnRight = att.InnerText.ToString();
                            break;
                        case "Pr2":
                            this.sPr2 = att.InnerText.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        #endregion
    }
}