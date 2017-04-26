using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace Bank_ID
{
    public class BanksDataset: System.Data.DataSet
    {
        public BanksDataset(string TemplateFile)
        {

            this.ReadXmlSchema(TemplateFile);

        }

        public int ColumId()
        {
            int idDb = -1;
            var dataTable = new DataTable();           
            foreach (DataRow row in dataTable.Rows)
            {                
                var columId = row["id"];
                idDb = Convert.ToInt32(columId);
            }
            return idDb;
        }   
          
    }   
}
