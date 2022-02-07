using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithDB
{
    static public class ReadXML
    {
        static public DataSet Read(string path)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(path);

            return dataSet;
        } 
    }
}
