using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading;
using System.Data;

namespace Facade2GJBA.Logic
{
    public interface intFacade2GJBA
    {
        #region Operaciones

        ArrayList RunScriptAL();

        DataSet RunScriptDS();

        String GetQuery();

        void LoadDocXML();

        void GenerateScript();

        #endregion

        #region OperacionesTest

        String PingFacadeQry(String In_str);

        #endregion
    }
}