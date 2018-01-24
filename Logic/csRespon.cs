using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Data;

namespace Facade2GJBA.Logic
{
    public class csRespon
    {
        #region Attrib

        private Boolean bResponExecution;
        private Int16 iResponCode;
        private String sResponDescription;

        #endregion

        #region Builder

        public csRespon()
        {
            this.bResponExecution = false;
            this.iResponCode = -1;
            this.sResponDescription = null;
        }

        #endregion

        #region Set

        public void SetResponON()
        {
            this.bResponExecution = true;
            this.iResponCode = 0;
            this.sResponDescription = null;
        }

        public void SetResponOFF(Int16 In_i, String In_s)
        {
            this.bResponExecution = false;
            this.iResponCode = In_i;
            this.sResponDescription = In_s;
        }

        #endregion

        #region Get

        public String GetResponInXmlString()
        {
            String str = "<Facade2GJBA><Facade2GJBARespon><bResponExecution>" + this.bResponExecution.ToString() + "</bResponExecution><iResponCode>"
                    + this.iResponCode.ToString() + "</iResponCode><sResponDescription>";
            if (this.sResponDescription != null)
                    str += this.sResponDescription.ToString();
            str += "</sResponDescription></Facade2GJBARespon></Facade2GJBA>";
            return str;
        }

        public ArrayList GetResponInArrayList()
        {
            ArrayList MyArr = new ArrayList();
            MyArr.Add(this.bResponExecution.ToString());
            MyArr.Add(this.iResponCode.ToString());
            MyArr.Add(this.sResponDescription.ToString());
            return MyArr;
        }

        public DataSet GetResponInDataSet()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);
            dt.Columns.Add("Execution", typeof(Boolean));
            dt.Columns.Add("Code", typeof(Int16));
            dt.Columns.Add("Description", typeof(String));
            dt.Rows.Add(this.bResponExecution, this.iResponCode, this.sResponDescription);

            return ds;
        }

        #endregion
    }
}