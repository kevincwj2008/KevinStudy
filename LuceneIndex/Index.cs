using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XFCompany.CIPnetWeb.DBOper;

namespace LuceneIndex
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void CreateIndexBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ConnectionString.Text))
            {
                MessageBox.Show("请填写数据库的链接字符串！");
                ConnectionString.Focus();
                return;
            }

            if (String.IsNullOrEmpty(tableName.Text))
            {
                MessageBox.Show("请填写需要索引的表名！");
                tableName.Focus();
                return;
            }

            if (String.IsNullOrEmpty(SelectField.Text))
            {
                MessageBox.Show("请填写文件保存的表字段！");
                SelectField.Focus();
                return;
            }

            if (String.IsNullOrEmpty(SegField.Text))
            {
                MessageBox.Show("请填写需要分词的字段名！");
                SegField.Focus();
                return;
            }

            BaseDBOper.InitDBParams("SQLServer", ConnectionString.Text);
            DataTable InfoDt = new DataTable();
            InfoDt = GetCdsDt(1,1,SelectField.Text,tableName.Text);
            if (InfoDt == null)
            {
                MessageBox.Show("请检查您的链接字符串、表名、查询字段是否正确！");
                ConnectionString.Focus();
                return;
            }

            int tempPage = 1;
            InfoDt = GetCdsDt(1,1000,SelectField.Text,tableName.Text);
            while (InfoDt != null)
            { 
                
            }
        }

        private void Index_Load(object sender, EventArgs e)
        {
            ConnectionString.Focus();
            ConnectionString.Text = "user id=dbuser_forpiii;data source=58.83.194.150;persist security info=True;initial catalog=DB_CDS_SCSC;password=user_piiipsd;Connect Timeout=180;Max Pool Size=150;";
            tableName.Text = "cds_bid";
            SelectField.Text = "id,areaid,catalogid,industryid,description,status,name,imagepath,pubdate,createtime";
            SegField.Text = "name,description";
        }

        private DataTable GetCdsDt(int thisPage, int pageSize, string SelectFiled, string tableName)
        {
            return BaseDBOper.DoQuery("SELECT * FROM (SELECT row_number() over (order by ID) as RowId," + SelectFiled + " FROM " + tableName + ") TEMP WHERE RowID Between " + ((thisPage - 1) * pageSize + 1) + " and " + thisPage * pageSize);
        }
    }
}
