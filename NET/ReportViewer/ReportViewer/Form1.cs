using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;


namespace ReportViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“nsDs.T_MeterAssembly”中。您可以根据需要移动或删除它。
            this.T_MeterAssemblyTableAdapter.Fill(this.nsDs.T_MeterAssembly);
            ReportParameter rp = new ReportParameter("SelectDate", "aaaa");
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] {rp});              
            this.reportViewer1.RefreshReport();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //取得数据集

            string connstring = "Data Source=.;Persist Security Info=True;Password=sa;User ID=sa;Initial Catalog=Barcode";

            System.Data.SqlClient.SqlConnection conn1 = new System.Data.SqlClient.SqlConnection(connstring);

            conn1.Open();

            System.Data.SqlClient.SqlCommand command1 = new System.Data.SqlClient.SqlCommand("select * from t_meterassembly", conn1);

            System.Data.SqlClient.SqlDataAdapter ada1 = new System.Data.SqlClient.SqlDataAdapter(command1);

            DataSet c_ds = new DataSet();

            try

            {

              //  conn1.Open();

                ada1.Fill(c_ds);

            }

            finally

            {

                conn1.Close();

                command1.Dispose();

                conn1.Dispose();

            }

 

            //为报表浏览器指定报表文件

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportViewer.Report1.rdlc";

            //指定数据集,数据集名称后为表,不是DataSet类型的数据集
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter rp = new ReportParameter("SelectDate", "aaaa");
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });  
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("msDS", c_ds.Tables[0]));

            //显示报表

            this.reportViewer1.RefreshReport();

        }        
    }
}
