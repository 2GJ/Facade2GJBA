using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;

namespace Facade2GJBA.Logic
{
    public class csQueryEntity
    {
        #region Attrib

        private String sUnion;
        private String sName;
        private String sAlias;
        private String sAliasL;
        private String sOnLeft;
        private String sOpe;
        private String sAliasR;
        private String sOnRight;
        private String sValue;

        #endregion

        #region Constructores

        public csQueryEntity()
        {
            
        }

        #endregion

        #region Operations

        public String GenerateEntity()
        {
            String Res = "";

            switch (this.sUnion)
            {
                case "F":
                    Res += "FROM ";
                    break;
                
                case "IJ":
                    Res += "INNER JOIN ";
                    break;
                
                case "LOJ":
                    Res += "LEFT OUTER JOIN ";
                    break;

                case "ROJ":
                    Res += "RIGHT OUTER JOIN ";
                    break;

                case "FOJ":
                    Res += "RIGHT OUTER JOIN ";
                    break;

                default:
                    break;
            }

            Res += this.sName + " ";

            Res += this.sAlias + " ";

            if (this.sAliasL != null && this.sAliasL != "")
            {
                Res += " ON ";
                Res += this.sAliasL + "." + this.sOnLeft + " ";
                                
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

                Res += this.sAliasR + "." + this.sOnRight + " ";
                
            }
            return Res;
        }

        public void LoadQrDocXMLCol(String In_xml)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(In_xml);
            XmlNode NodoQrCol = xdoc.FirstChild;

            if (NodoQrCol.Name == "Entity")
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
                        case "Name":
                            this.sName = att.InnerText.ToString();
                            break;
                        case "Alias":
                            this.sAlias = att.InnerText.ToString();
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
                        default:
                            break;
                    }
                }
            }
        }

        #endregion
    }
}