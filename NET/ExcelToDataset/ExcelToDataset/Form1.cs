using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Odbc;

namespace ExcelToDataset
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataSet1=doImport(openFileDialog1.FileName, "demo");
                dataGridView1.DataSource = dataSet1.Tables[0];
            }
        }


        private DataSet doImport(string nsFileName,string nsTableName)
        {
            if (nsFileName == " ") return null;

            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+nsFileName+";Extended Properties=Excel 8.0;";
            OleDbConnection excelDc = new OleDbConnection(@strConn);


           // string strConn = "Dsn=dd;dbq=D:\01.xls;defaultdir=D:;driverid=790;fil=excel 8.0;maxbuffersize=2048;pagetimeout=5";
            //   "Provider=Microsoft.Jet.OLEDB.4.0; " +
            //"Data   Source= " + nsFileName + "; " +
            //"Extended   Properties=Excel   8.0; ";
            //  OleDbConnection excelDc = new OleDbConnection(strConn);
           excelDc.Open();
           if (excelDc != null)
           {


               OleDbDataAdapter ExcelDA = new OleDbDataAdapter("SELECT   a,b,'' as c  FROM   [demo] ", excelDc);
               // ExcelDA.SelectCommand.Connection = excelDc;

               DataSet ExcelDs = new DataSet();

               try
               {
                   ExcelDA.Fill(ExcelDs, "ExcelInfo ");
               }
               catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                //System.Console.WriteLine(err.ToString());
            }
               return ExcelDs;
           }
           else return null;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“dataSet11.demo”中。您可以根据需要移动或删除它。
            //this.demoTableAdapter.Fill(this.dataSet11.demo);

        }

    }
     

   

}
