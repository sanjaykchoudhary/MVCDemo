using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace ImportExcelToSQLServerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //the datetime and Log folder will be used for error log file in the case error occured.
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string logFolder = @"C:\Log\";
            try
            {
                //provide the database name.
                string DatabaseName = "AspNetDemo";
                //provide the sql server name.
                string SQLServerName = "(local)";
                //Provide the table name where you want to load excel's data.
                string tableName = @"tblCustomer";
                //Provide the schema of the table.
                string schemaname = @"dbo";

                //Provide Excel file path
                string fileFullPath = @"C:\Source\ExcelImportDemo.xlsx";
                //Provide Sheet Name you like to read
                string SheetName = "Customer";


                //Create Connection to SQL Server Database 
                SqlConnection SQLConnection = new SqlConnection();
                SQLConnection.ConnectionString = "Data Source = " + SQLServerName + "; Initial Catalog =" + DatabaseName + "; " + "Integrated Security=true;";
                //Create Excel Connection
                string ConStr;
                string HDR;
                HDR = "YES";
                ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileFullPath + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";
                OleDbConnection cnn = new OleDbConnection(ConStr);

                //Get data from Excel Sheet to DataTable
                OleDbConnection Conn = new OleDbConnection(ConStr);
                Conn.Open();
                OleDbCommand oconn = new OleDbCommand("select * from [" + SheetName + "$]", Conn);
                OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                Conn.Close();

                SQLConnection.Open();
                //Load data from datatable to SQL Server table.
                using (SqlBulkCopy sbk = new SqlBulkCopy(SQLConnection))
                {
                    sbk.DestinationTableName = schemaname + "." + tableName;
                    foreach(var column in dt.Columns)
                    {
                        sbk.ColumnMappings.Add(column.ToString(), column.ToString());
                    }
                    sbk.WriteToServer(dt);
                }
                SQLConnection.Close();

            }
            catch (Exception ex) {
                //Create log file for Errors.
                using (StreamWriter sw = File.CreateText(logFolder + "\\" + "ErrorLog_" + datetime + ".log"))
                {
                    sw.WriteLine(ex.ToString());
                }
            }
        }
    }
}
