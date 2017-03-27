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
                    new SqlParameter("@SortNum", SqlDbType.Int,4)};
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
        /// 修改部门
        /// </summary>
        public int ModifyDept(Model.DeptType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_DepartmentInfo set ");
            strSql.Append(" DeptName=@DeptName,");
            strSql.Append(" SortNum=@SortNum");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@DeptName", SqlDbType.NVarChar,50),
                    new SqlParameter("@SortNum", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.DeptName;
            parameters[1].Value = model.SortNum;
            parameters[2].Value = model.ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除部门
        /// </summary>
        public int DeleteDept(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_DepartmentInfo ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.DeptType GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Sys_DepartmentInfo ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            Model.DeptType model = new Model.DeptType();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.DeptType DataRowToModel(DataRow row)
        {
            Model.DeptType model = new Model.DeptType();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["DeptName"] != null)
                {
                    model.DeptName = row["DeptName"].ToString();
                }
                if (row["SortNum"] != null && row["SortNum"].ToString() != "")
                {
                    model.SortNum = int.Parse(row["SortNum"].ToString());
                }
            }
            return model;
        }
    }
}
