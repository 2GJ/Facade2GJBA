using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;

namespace Facade2GJBA.Logic
{
    public class csQueryColumn
    {
        #region Attrib

        private String sName;
        private String sAlias;
        private String sValue;

        #endregion

        #region Constructores

        public csQueryColumn()
        {
            
        }

        #endregion

        #region Operations

        public String GenerateColumn()
        {
            return sAlias + "." + sName + " '" + sValue + "'";
        }

        public void LoadQrDocXMLCol(String In_xml)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(In_xml);
            XmlNode NodoQrCol = xdoc.FirstChild;

            if (NodoQrCol.Name == "Column")
            {
                this.sValue = NodoQrCol.InnerText.ToString();
                foreach (XmlAttribute att in NodoQrCol.Attributes)
                {
                    String SlecAtt = att.Name;

                    switch (SlecAtt)
                    {
                        case "Name":
                            this.sName = att.InnerText.ToString();
                            break;
                        case "Alias":
                            this.sAlias = att.InnerText.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public String LoadQrValidateDocXMLCol(String In_xml)
        {
            String Answer = "";

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(In_xml);
            XmlNode NodoQrCol = xdoc.FirstChild;

            if (NodoQrCol.Name == "Column")
            {
                this.sValue = NodoQrCol.InnerText.ToString();
                foreach (XmlAttribute att in NodoQrCol.Attributes)
                {
                    String SlecAtt = att.Name;

                    switch (SlecAtt)
                    {
                        case "Name":
                            this.sName = att.InnerText.ToString();
                            break;
                        case "Alias":
                            this.sAlias = att.InnerText.ToString();
                            break;
                        default:
                            Answer += "Atributo " + SlecAtt + " no valido.";
                            break;
                    }
                }
            }
            else
            {
                Answer += "Nodo de columnas no valido.";
            }

            return Answer;
        }

        #endregion
    }
}