using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Xml;
using System.Data;
using Utilities;


namespace Facade2GJBA.Logic
{
    public class csQuerySQL : intFacade2GJBA
    {
        #region Attribs

        public String sScript;

        #endregion

        #region Constructors

        public csQuerySQL()
        {
            this.sScript = null;
        }

        #endregion

        #region Operations

        public ArrayList RunScriptAL()
        {
            return UtilSQL.ExecSQL(this.sScript, "NOMTABLA");
        }

        public DataSet RunScriptDS()
        {
            return UtilSQL.ExecSQLDataSet(this.sScript, "NOMTABLA");
        }

        public String GetQuery()
        {
            return this.sScript;
        }

        public virtual void LoadDocXML()
        {
        }
                        
        public virtual void GenerateScript()
        {
        }
                
        #endregion

        #region OperacionesTest

        public String PingFacadeQry(String In_str)
        {
            return "Ping csQuery successful " + In_str;
        }

        #endregion
    }
}