using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DotLiquid;

namespace GoldArch.DotLiquidTest.Drops
{
    public static class DataRowDropHelper
    {
        /// <summary>
        /// 关键，把dataTable转化为DataRowDrop List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<DataRowDrop> GetDataRowDropList(DataTable dt)
        {
            //private readonly System.Data.DataTable _dataTable;
            List<DataRowDrop> list = new List<DataRowDrop>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new DataRowDrop(dr));
            }

            return list;
        }

        public static string ToSqlWithDataTableTemplate(string templateString,DataTable dt)
        {
            var template = Template.Parse(templateString);

            var list = GetDataRowDropList(dt);

            var str = template.Render(Hash.FromAnonymousObject(new { tb = list }));

            return str;
        }
    }
    public class DataRowDrop : Drop
    {
        private readonly System.Data.DataRow _dataRow;

        public DataRowDrop(System.Data.DataRow dataRow)
        {
            _dataRow = dataRow;
        }

        public override object BeforeMethod(string method)
        {
            if (_dataRow.Table.Columns.Contains(method))
            {
                //dx,这里做了进一步整理
                //return SqlHelperForSqlString.FormatSqlValue(_dataRow[method]);
                //在处理这样的语句时，遇到问题：SET @notePre='2022.07.08 V01 NO:{{ row.序号 | left_pad_zero:10}}'
                //这里的row.序号带''号后，后续处理会出问题！附加上的引号，也不符合一般习惯，把加引号的部分做成过滤器
                return _dataRow[method];
            }

            return null;
        }
    }
}