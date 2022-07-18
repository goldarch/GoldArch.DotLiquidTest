using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldArch.DotLiquidTest.AboutMe;
using GoldArch.DotLiquidTest.Drops;

namespace GoldArch.DotLiquidTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = @"
--头部参数定义
DECLARE @no VARCHAR(MAX);
DECLARE @str1 VARCHAR(MAX);
DECLARE @str2 VARCHAR(MAX);

{% for row in tb -%}

{% capture warpIncrementDotNotPrint %}
{% increment currentRowIndex -%}
{% endcapture %}
--当前是第{{currentRowIndex}}行
--这里是每行参数赋值
SET @no='NO:{{ row.Column0 | left_pad_zero:3}}'
SET @str1={{row.Column1 | format_sql}}
SET @str2={{row.Column2 | format_sql}}

insert into tb_test
{
    id,no,str1,str2
}
values
{   
    newid(),@no,@str1,@str2
}

{% endfor -%}
";
        }
        DataTable GetDataTable()
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable.Columns.Add("Column0");
            dataTable.Columns.Add("Column1");
            dataTable.Columns.Add("Column2");

            System.Data.DataRow dataRow = dataTable.NewRow();
            dataRow["Column0"] = "1";
            dataRow["Column1"] = "Hello";
            dataRow["Column2"] = "World";
            dataTable.Rows.Add(dataRow);

            //
            dataRow = dataTable.NewRow();
            dataRow["Column0"] = "2";
            dataRow["Column1"] = "Hello02";
            dataRow["Column2"] = "World02";
            dataTable.Rows.Add(dataRow);

            dataRow = dataTable.NewRow();
            dataRow["Column0"] = "3";
            dataRow["Column1"] = "Hello03";
            dataRow["Column2"] = "World03";
            dataTable.Rows.Add(dataRow);

            return dataTable;
        }

        private void button处理表循环模板_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = DataRowDropHelper.ToSqlWithDataTableTemplate(richTextBox1.Text, GetDataTable());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FormAbout().ShowDialog(this);
        }
    }
}
