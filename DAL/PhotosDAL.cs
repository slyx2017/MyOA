using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
namespace DAL
{
	/// <summary>
	/// 数据访问类:Photos
	/// </summary>
	public partial class PhotosDAL
	{
		public PhotosDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PhotoId", "Photos"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PhotoId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Photos");
			strSql.Append(" where PhotoId=@PhotoId");
			SqlParameter[] parameters = {
					new SqlParameter("@PhotoId", SqlDbType.Int,4)
			};
			parameters[0].Value = PhotoId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Photos model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Photos(");
			strSql.Append("AlbumId,PhotoName,PhotoPath,PhotoDesc,AddUser,AddTime,IsAlbumFace)");
			strSql.Append(" values (");
			strSql.Append("@AlbumId,@PhotoName,@PhotoPath,@PhotoDesc,@AddUser,@AddTime,@IsAlbumFace)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AlbumId", SqlDbType.Int,4),
					new SqlParameter("@PhotoName", SqlDbType.NVarChar,50),
					new SqlParameter("@PhotoPath", SqlDbType.NVarChar,100),
					new SqlParameter("@PhotoDesc", SqlDbType.Text),
					new SqlParameter("@AddUser", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@IsAlbumFace", SqlDbType.Bit,1)};
			parameters[0].Value = model.AlbumId;
			parameters[1].Value = model.PhotoName;
			parameters[2].Value = model.PhotoPath;
			parameters[3].Value = model.PhotoDesc;
			parameters[4].Value = model.AddUser;
			parameters[5].Value = model.AddTime;
            parameters[6].Value = model.IsAlbumFace;
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
		public bool Update(Model.Photos model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Photos set ");
			strSql.Append("AlbumId=@AlbumId,");
			strSql.Append("PhotoName=@PhotoName,");
			strSql.Append("PhotoPath=@PhotoPath,");
			strSql.Append("PhotoDesc=@PhotoDesc,");
			strSql.Append("AddUser=@AddUser,");
			strSql.Append("AddTime=@AddTime,");
            strSql.Append("IsAlbumFace=@IsAlbumFace");
            strSql.Append(" where PhotoId=@PhotoId");
			SqlParameter[] parameters = {
					new SqlParameter("@AlbumId", SqlDbType.Int,4),
					new SqlParameter("@PhotoName", SqlDbType.NVarChar,50),
					new SqlParameter("@PhotoPath", SqlDbType.NVarChar,100),
					new SqlParameter("@PhotoDesc", SqlDbType.Text),
					new SqlParameter("@AddUser", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@IsAlbumFace", SqlDbType.Bit,1),
                    new SqlParameter("@PhotoId", SqlDbType.Int,4)};
			parameters[0].Value = model.AlbumId;
			parameters[1].Value = model.PhotoName;
			parameters[2].Value = model.PhotoPath;
			parameters[3].Value = model.PhotoDesc;
			parameters[4].Value = model.AddUser;
			parameters[5].Value = model.AddTime;
            parameters[6].Value = model.IsAlbumFace;
            parameters[7].Value = model.PhotoId;

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
		public bool Delete(int PhotoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Photos ");
			strSql.Append(" where PhotoId=@PhotoId");
			SqlParameter[] parameters = {
					new SqlParameter("@PhotoId", SqlDbType.Int,4)
			};
			parameters[0].Value = PhotoId;

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
        /// 删除照片
        /// </summary>
        public int DeletePhoto(int PhotoId,int isface)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@PhotoId", SqlDbType.Int,4),
                    new SqlParameter("@IsAlbumFace", SqlDbType.Bit)
            };
            parameters[0].Value = PhotoId;
            parameters[1].Value = isface;
            int result = 0;
            return DbHelperSQL.RunProcedure("DeletePhoto", parameters,out result);

        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string PhotoIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Photos ");
			strSql.Append(" where PhotoId in ("+PhotoIdlist + ")  ");
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
		public Model.Photos GetModel(int PhotoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PhotoId,AlbumId,PhotoName,PhotoPath,PhotoDesc,AddUser,AddTime,IsAlbumFace from Photos ");
			strSql.Append(" where PhotoId=@PhotoId");
			SqlParameter[] parameters = {
					new SqlParameter("@PhotoId", SqlDbType.Int,4)
			};
			parameters[0].Value = PhotoId;

			Model.Photos model=new Model.Photos();
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
		public Model.Photos DataRowToModel(DataRow row)
		{
			Model.Photos model=new Model.Photos();
			if (row != null)
			{
				if(row["PhotoId"]!=null && row["PhotoId"].ToString()!="")
				{
					model.PhotoId=int.Parse(row["PhotoId"].ToString());
				}
				if(row["AlbumId"]!=null && row["AlbumId"].ToString()!="")
				{
					model.AlbumId=int.Parse(row["AlbumId"].ToString());
				}
				if(row["PhotoName"]!=null)
				{
					model.PhotoName=row["PhotoName"].ToString();
				}
				if(row["PhotoPath"]!=null)
				{
					model.PhotoPath=row["PhotoPath"].ToString();
				}
				if(row["PhotoDesc"]!=null)
				{
					model.PhotoDesc=row["PhotoDesc"].ToString();
				}
				if(row["AddUser"]!=null)
				{
					model.AddUser=row["AddUser"].ToString();
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
                if (row["IsAlbumFace"] != null && row["IsAlbumFace"].ToString() != "")
                {
                    if ((row["IsAlbumFace"].ToString() == "1") || (row["IsAlbumFace"].ToString().ToLower() == "true"))
                    {
                        model.IsAlbumFace = true;
                    }
                    else
                    {
                        model.IsAlbumFace = false;
                    }
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
			strSql.Append("select PhotoId,AlbumId,PhotoName,PhotoPath,PhotoDesc,AddUser,AddTime,IsAlbumFace ");
			strSql.Append(" FROM Photos ");
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
			strSql.Append(" PhotoId,AlbumId,PhotoName,PhotoPath,PhotoDesc,AddUser,AddTime,IsAlbumFace ");
			strSql.Append(" FROM Photos ");
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
			strSql.Append("select count(1) FROM Photos ");
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
				strSql.Append("order by T.PhotoId desc");
			}
			strSql.Append(")AS Row, T.*  from Photos T ");
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
			parameters[0].Value = "Photos";
			parameters[1].Value = "PhotoId";
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

