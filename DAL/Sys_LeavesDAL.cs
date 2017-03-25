using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
namespace DAL
{
	/// <summary>
	/// 数据访问类:Sys_Leaves
	/// </summary>
	public partial class Sys_LeavesDAL
	{
		public Sys_LeavesDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Leaves");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Sys_Leaves model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_Leaves(");
			strSql.Append("LeaveReason,LeaveTypeID,ApplyTime,ApprovalPerson,BeginTime,EndTime,LeaveStatus,CancelLeaveTime,ApplyPerson)");
			strSql.Append(" values (");
			strSql.Append("@LeaveReason,@LeaveTypeID,@ApplyTime,@ApprovalPerson,@BeginTime,@EndTime,@LeaveStatus,@CancelLeaveTime,@ApplyPerson)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@LeaveReason", SqlDbType.NVarChar,200),
					new SqlParameter("@LeaveTypeID", SqlDbType.Int,4),
					new SqlParameter("@ApplyTime", SqlDbType.DateTime),
					new SqlParameter("@ApprovalPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@LeaveStatus", SqlDbType.Bit,1),
					new SqlParameter("@CancelLeaveTime", SqlDbType.DateTime),
					new SqlParameter("@ApplyPerson", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.LeaveReason;
			parameters[1].Value = model.LeaveTypeID;
			parameters[2].Value = model.ApplyTime;
			parameters[3].Value = model.ApprovalPerson;
			parameters[4].Value = model.BeginTime;
			parameters[5].Value = model.EndTime;
			parameters[6].Value = model.LeaveStatus;
			parameters[7].Value = model.CancelLeaveTime;
			parameters[8].Value = model.ApplyPerson;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public int Update(Model.Sys_Leaves model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Leaves set ");
			strSql.Append("LeaveReason=@LeaveReason,");
			strSql.Append("LeaveTypeID=@LeaveTypeID,");
			strSql.Append("ApplyTime=@ApplyTime,");
			strSql.Append("ApprovalPerson=@ApprovalPerson,");
			strSql.Append("BeginTime=@BeginTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("LeaveStatus=@LeaveStatus,");
			strSql.Append("CancelLeaveTime=@CancelLeaveTime,");
			strSql.Append("ApplyPerson=@ApplyPerson");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@LeaveReason", SqlDbType.NVarChar,200),
					new SqlParameter("@LeaveTypeID", SqlDbType.Int,4),
					new SqlParameter("@ApplyTime", SqlDbType.DateTime),
					new SqlParameter("@ApprovalPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@LeaveStatus", SqlDbType.Bit,1),
					new SqlParameter("@CancelLeaveTime", SqlDbType.DateTime),
					new SqlParameter("@ApplyPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.LeaveReason;
			parameters[1].Value = model.LeaveTypeID;
			parameters[2].Value = model.ApplyTime;
			parameters[3].Value = model.ApprovalPerson;
			parameters[4].Value = model.BeginTime;
			parameters[5].Value = model.EndTime;
			parameters[6].Value = model.LeaveStatus;
			parameters[7].Value = model.CancelLeaveTime;
			parameters[8].Value = model.ApplyPerson;
			parameters[9].Value = model.ID;

			return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Leaves ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Leaves ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Sys_Leaves GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,LeaveReason,LeaveTypeID,ApplyTime,ApprovalPerson,BeginTime,EndTime,LeaveStatus,CancelLeaveTime,ApplyPerson from Sys_Leaves ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Model.Sys_Leaves model=new Model.Sys_Leaves();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public Model.Sys_Leaves DataRowToModel(DataRow row)
		{
			Model.Sys_Leaves model=new Model.Sys_Leaves();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["LeaveReason"]!=null)
				{
					model.LeaveReason=row["LeaveReason"].ToString();
				}
				if(row["LeaveTypeID"]!=null && row["LeaveTypeID"].ToString()!="")
				{
					model.LeaveTypeID=int.Parse(row["LeaveTypeID"].ToString());
				}
				if(row["ApplyTime"]!=null && row["ApplyTime"].ToString()!="")
				{
					model.ApplyTime=DateTime.Parse(row["ApplyTime"].ToString());
				}
				if(row["ApprovalPerson"]!=null)
				{
					model.ApprovalPerson=row["ApprovalPerson"].ToString();
				}
				if(row["BeginTime"]!=null && row["BeginTime"].ToString()!="")
				{
					model.BeginTime=DateTime.Parse(row["BeginTime"].ToString());
				}
				if(row["EndTime"]!=null && row["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(row["EndTime"].ToString());
				}
				if(row["LeaveStatus"]!=null && row["LeaveStatus"].ToString()!="")
				{
					if((row["LeaveStatus"].ToString()=="1")||(row["LeaveStatus"].ToString().ToLower()=="true"))
					{
						model.LeaveStatus=true;
					}
					else
					{
						model.LeaveStatus=false;
					}
				}
				if(row["CancelLeaveTime"]!=null && row["CancelLeaveTime"].ToString()!="")
				{
					model.CancelLeaveTime=DateTime.Parse(row["CancelLeaveTime"].ToString());
				}
				if(row["ApplyPerson"]!=null)
				{
					model.ApplyPerson=row["ApplyPerson"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,LeaveReason ,");
            strSql.Append("LeaveName=(select LeaveName from LeaveTypes lt where lt.ID=l.LeaveTypeID ), ");
            strSql.Append("ApplyTime,ApprovalPerson,BeginTime,EndTime,LeaveStatus,CancelLeaveTime,ApplyPerson ");
			strSql.Append(" FROM Sys_Leaves l ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,LeaveReason,LeaveTypeID,ApplyTime,ApprovalPerson,BeginTime,EndTime,LeaveStatus,CancelLeaveTime,ApplyPerson ");
			strSql.Append(" FROM Sys_Leaves ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Sys_Leaves ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_Leaves T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Sys_Leaves";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


