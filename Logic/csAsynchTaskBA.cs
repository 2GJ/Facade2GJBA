using System;
using System.Collections.Generic;
using System.Web;
using BizAgi.BL;

namespace Facade2GJBA.Logic
{
    public class csAsynchTaskBA : intFacadeAsyn2GJBA
    {
        public void AsynchExecution(int IdCase, int IdWI, string User)
        {
            try
            {
                CBLWFES objBAAsyn = new CBLWFES();
                objBAAsyn.processAsynchExecution(IdCase, IdWI, User);
                //this.oBLWFES.processAsynchExecution(idCase, idWorkitem, this.oUser.sSAMAccount);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
 
        
        public void AsynchExecutionNew(int IdCase, long IdWI, string User)
        {
            try
            {
                //CBLWFES objBAAsyn = new CBLWFES();
                //objBAAsyn.processAsynchExecution(IdCase, IdWI, User);
                //this.oBLWFES.processAsynchExecution(idCase, idWorkitem, this.oUser.sSAMAccount);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
    }
}