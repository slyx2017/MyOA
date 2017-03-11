using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class DeptTypeDAL
    {
        public DeptTypeDAL()
        { }

        /// <summary>
        /// 添加部门
        /// </summary>
        public int AddDeptType(Model.DeptType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_DepartmentInfo(");
            strSql.Append("DeptName,SortNum)");
            strSql.Append(" values (");
            strSql.Append("@DeptName,@SortNum)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@DeptName", SqlDbType.NVarChar,50),
                    new SqlParameter("@SortNum", SqlDbType.NChar,10)};
            parameters[0].Value = model.DeptName;
            parameters[1].Value = model.SortNum;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDeptList(string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@strWhere", SqlDbType.NVarChar,1000),
                    };
            parameters[0].Value = strWhere;
            return DbHelperSQL.RunProcedure("GetDeptList", parameters, "ds");
        }
    }
}
