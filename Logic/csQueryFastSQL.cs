using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Text;
using Tools2GJ;


namespace Facade2GJBA.Logic
{
    public class csQueryFastSQL : csQuerySQL
    {
        #region Constructor

        public csQueryFastSQL(String InStr)
        {
            this.sScript = InStr;
        }

        #endregion

        #region Operations

        public override void GenerateScript()
        {
            String2GJ Obj2GJ = new String2GJ();
            this.sScript = Obj2GJ.ConvBase64UTF8ToString(this.sScript);
        }

        #endregion
    }
}