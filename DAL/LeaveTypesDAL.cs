using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBUtility;

namespace DAL
{
    /// <summary>
    /// 数据访问类:LeaveTypes
    /// </summary>
    public partial class LeaveTypesDAL
    {
        public LeaveTypesDAL()
        { }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,LeaveName ");
            strSql.Append(" FROM LeaveTypes ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
