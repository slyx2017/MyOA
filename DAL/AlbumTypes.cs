using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
namespace DAL
{
	/// <summary>
	/// 数据访问类:AlbumTypes
	/// </summary>
	public partial class AlbumTypes
	{
		public AlbumTypes()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AlbumTypeId", "AlbumTypes"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AlbumTypeId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AlbumTypes");
			strSql.Append(" where AlbumTypeId=@AlbumTypeId");
			SqlParameter[] parameters = {
					new SqlParameter("@AlbumTypeId", SqlDbType.Int,4)
			};
			parameters[0].Value = AlbumTypeId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.AlbumTypes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AlbumTypes(");
			strSql.Append("AlbumTypeName,AddUser,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@AlbumTypeName,@AddUser,@AddTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AlbumTypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@AddUser", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.AlbumTypeName;
			parameters[1].Value = model.AddUser;
			parameters[2].Value = model.AddTime;

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
		/// 增加一条数据
		/// </summary>
		public int AddAlbumType(Model.AlbumTypes model)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@AlbumTypeName", SqlDbType.NVarChar,50),
                    new SqlParameter("@AddUser", SqlDbType.NVarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime)};
            parameters[0].Value = model.AlbumTypeName;
            parameters[1].Value = model.AddUser;
            parameters[2].Value = model.AddTime;
            int result = 0;
            return DbHelperSQL.RunProcedure("AddAlbumType", parameters,out result);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.AlbumTypes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AlbumTypes set ");
			strSql.Append("AlbumTypeName=@AlbumTypeName,");
			strSql.Append("AddUser=@AddUser,");
			strSql.Append("AddTime=@AddTime");
			strSql.Append(" where AlbumTypeId=@AlbumTypeId");
			SqlParameter[] parameters = {
					new SqlParameter("@AlbumTypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@AddUser", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@AlbumTypeId", SqlDbType.Int,4)};
			parameters[0].Value = model.AlbumTypeName;
			parameters[1].Value = model.AddUser;
			parameters[2].Value = model.AddTime;
			parameters[3].Value = model.AlbumTypeId;

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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int AlbumTypeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AlbumTypes ");
			strSql.Append(" where AlbumTypeId=@AlbumTypeId");
			SqlParameter[] parameters = {
					new SqlParameter("@AlbumTypeId", SqlDbType.Int,4)
			};
			parameters[0].Value = AlbumTypeId;

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
		public bool DeleteList(string AlbumTypeIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AlbumTypes ");
			strSql.Append(" where AlbumTypeId in ("+AlbumTypeIdlist + ")  ");
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
		public Model.AlbumTypes GetModel(int AlbumTypeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AlbumTypeId,AlbumTypeName,AddUser,AddTime from AlbumTypes ");
			strSql.Append(" where AlbumTypeId=@AlbumTypeId");
			SqlParameter[] parameters = {
					new SqlParameter("@AlbumTypeId", SqlDbType.Int,4)
			};
			parameters[0].Value = AlbumTypeId;

			Model.AlbumTypes model=new Model.AlbumTypes();
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
		public Model.AlbumTypes DataRowToModel(DataRow row)
		{
			Model.AlbumTypes model=new Model.AlbumTypes();
			if (row != null)
			{
				if(row["AlbumTypeId"]!=null && row["AlbumTypeId"].ToString()!="")
				{
					model.AlbumTypeId=int.Parse(row["AlbumTypeId"].ToString());
				}
				if(row["AlbumTypeName"]!=null)
				{
					model.AlbumTypeName=row["AlbumTypeName"].ToString();
				}
				if(row["AddUser"]!=null)
				{
					model.AddUser=row["AddUser"].ToString();
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
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
			strSql.Append("select AlbumTypeId,AlbumTypeName,AddUser,AddTime ");
			strSql.Append(" FROM AlbumTypes ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 获得相册类别列表
        /// </summary>
        public DataSet GetAlbumType()
        {
            SqlParameter[] parameters = {
                    };
            return DbHelperSQL.RunProcedure("GetAlbumType", parameters, "ds");
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
			strSql.Append(" AlbumTypeId,AlbumTypeName,AddUser,AddTime ");
			strSql.Append(" FROM AlbumTypes ");
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
			strSql.Append("select count(1) FROM AlbumTypes ");
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
				strSql.Append("order by T.AlbumTypeId desc");
			}
			strSql.Append(")AS Row, T.*  from AlbumTypes T ");
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
			parameters[0].Value = "AlbumTypes";
			parameters[1].Value = "AlbumTypeId";
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

