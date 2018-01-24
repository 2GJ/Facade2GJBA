using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
//using Utilities;
using Facade2GJBA.Logic;
using System.Data;
using System.Collections;
//using BizAgi.BL;

namespace Facade2GJBA
{
    /// <summary>
    /// Descripción breve de Facade2GJBA
    /// </summary>
    [WebService(Namespace = "Facade2GJ")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Facade2GJBA : System.Web.Services.WebService
    {
        #region Qry

        [WebMethod]
        public ArrayList QryXMLStrByAL(string InStr)
        {
            intFacade2GJBA oFacade;

            try
            {
                oFacade = new csQueryXMLSQL(InStr);
                oFacade.LoadDocXML();
                oFacade.GenerateScript();
                return oFacade.RunScriptAL();
            }
            catch (Exception e)
            {
                csRespon csRe = new csRespon();
                csRe.SetResponOFF(1001, e.Message.ToString());
                return csRe.GetResponInArrayList();
            }
        }

        [WebMethod]
        public DataSet QryXMLStrByDS(string InStr)
        {
            intFacade2GJBA oFacade;

            try
            {
                oFacade = new csQueryXMLSQL(InStr);
                oFacade.LoadDocXML();
                oFacade.GenerateScript();
                return oFacade.RunScriptDS();
            }
            catch (Exception e)
            {
                csRespon csRe = new csRespon();
                csRe.SetResponOFF(1001, e.Message.ToString());
                return csRe.GetResponInDataSet();
            }
        }

        [WebMethod]
        public String QryXMLStr(string InStr)
        {
            intFacade2GJBA oFacade;

            try
            {
                oFacade = new csQueryXMLSQL(InStr);
                oFacade.LoadDocXML();
                oFacade.GenerateScript();
                return oFacade.GetQuery();
            }
            catch (Exception e)
            {
                csRespon csRe = new csRespon();
                csRe.SetResponOFF(1001, e.Message.ToString());
                return csRe.GetResponInXmlString();
            }
        }

        [WebMethod]
        public String QryFastStr(String InStr)
        {
            intFacade2GJBA oFacade;

            try
            {
                oFacade = new csQueryFastSQL(InStr);
                oFacade.GenerateScript();
                return oFacade.GetQuery();
            }
            catch (Exception e)
            {
                csRespon csRe = new csRespon();
                csRe.SetResponOFF(1001, e.Message.ToString());
                return csRe.GetResponInXmlString();
            }

        }

        [WebMethod]
        public DataSet QryFastStrByDS(string InStr)
        {
            intFacade2GJBA oFacade;

            try
            {
                oFacade = new csQueryFastSQL(InStr);
                oFacade.GenerateScript();
                return oFacade.RunScriptDS();
            }
            catch (Exception e)
            {
                csRespon csRe = new csRespon();
                csRe.SetResponOFF(1001, e.Message.ToString());
                return csRe.GetResponInDataSet();
            }
        }

        #endregion

        #region Asyn

        [WebMethod(Description = "[Asincronas] - Ejecuta o reintenta una actividad asíncrona. (Version 2015)")]
        public String EjectAsync(int In_IdCase, int In_IdWI, string In_User)
        {
            intFacadeAsyn2GJBA oFacade;

            try
            {
                oFacade = new csAsynchTaskBA();
                oFacade.AsynchExecution(In_IdCase, In_IdWI, In_User);
                return "1-Reintento de asíncrona ejecutado.";
            }
            catch (Exception e)
            {
                csRespon csRe = new csRespon();
                csRe.SetResponOFF(1001, e.Message.ToString());
                return csRe.GetResponInXmlString();
            }
        }


        [WebMethod(Description = "[Asincronas] - Ejecuta o reintenta una actividad asíncrona. (Version 2016)")]
        public String EjectAsyncNew(int In_IdCase, long In_IdWI, string In_User)
        {
            intFacadeAsyn2GJBA oFacade;

            try
            {
                //oFacade = new csAsynchTaskBA();
                //oFacade.AsynchExecutionNew(In_IdCase, In_IdWI, In_User);
                return "Version NO ACTIVA..."; //"1-Reintento de asíncrona ejecutado.";
            }
            catch (Exception e)
            {
                csRespon csRe = new csRespon();
                csRe.SetResponOFF(1001, e.Message.ToString());
                return csRe.GetResponInXmlString();
            }
        }

        #endregion

        #region TestService

        [WebMethod(Description = "[Test] - Prueba básica de funcionamiento del servicio.")]
        public string Ping(string InStr)
        {
            return "Hello " + InStr + " from the facade...";
        }

        [WebMethod(Description = "[Test] - Prueba básica de funcionamiento interface QuerySQL en el servicio.")]
        public string PingFacadeQry(string InStr)
        {
            intFacade2GJBA oFacade;
            oFacade = new csQuerySQL();
            return oFacade.PingFacadeQry(InStr);
        }

        #endregion
    }
}
