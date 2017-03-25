using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
namespace DAL
{
    /// <summary>
    /// 数据访问类:Albums
    /// </summary>
    public partial class AlbumsDAL
    {
        public AlbumsDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("AlbumId", "Albums");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AlbumId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Albums");
            strSql.Append(" where AlbumId=@AlbumId");
            SqlParameter[] parameters = {
                    new SqlParameter("@AlbumId", SqlDbType.Int,4)
            };
            parameters[0].Value = AlbumId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Albums model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Albums(");
            strSql.Append("AlbumName,AddUser,AddTime,AlbumTypeId,CoverPhotoPath,AlbumDesc,AlbumPath)");
            strSql.Append(" values (");
            strSql.Append("@AlbumName,@AddUser,@AddTime,@AlbumTypeId,@CoverPhotoPath,@AlbumDesc,@AlbumPath)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@AlbumName", SqlDbType.NVarChar,50),
                    new SqlParameter("@AddUser", SqlDbType.NVarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@AlbumTypeId", SqlDbType.Int,4),
                    new SqlParameter("@CoverPhotoPath", SqlDbType.NVarChar,100),
                    new SqlParameter("@AlbumDesc", SqlDbType.NVarChar,200),
                    new SqlParameter("@AlbumPath", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.AlbumName;
            parameters[1].Value = model.AddUser;
            parameters[2].Value = model.AddTime;
            parameters[3].Value = model.AlbumTypeId;
            parameters[4].Value = model.CoverPhotoPath;
            parameters[5].Value = model.AlbumDesc;
            parameters[6].Value = model.AlbumPath;
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
		/// 新增相册
		/// </summary>
		public int AddAlbum(Model.Albums model)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@AlbumName", SqlDbType.NVarChar,50),
                    new SqlParameter("@AddUser", SqlDbType.NVarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@AlbumTypeId", SqlDbType.Int,4),
                    new SqlParameter("@CoverPhotoPath", SqlDbType.NVarChar,100),
                    new SqlParameter("@AlbumDesc", SqlDbType.NVarChar,200),
                    new SqlParameter("@AlbumPath", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.AlbumName;
            parameters[1].Value = model.AddUser;
            parameters[2].Value = model.AddTime;
            parameters[3].Value = model.AlbumTypeId;
            parameters[4].Value = model.CoverPhotoPath;
            parameters[5].Value = model.AlbumDesc;
            parameters[6].Value = model.AlbumPath;
            int result = 0;
            return DbHelperSQL.RunProcedure("AddAlbum", parameters, out result);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Albums model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Albums set ");
            strSql.Append("AlbumName=@AlbumName,");
            strSql.Append("AddUser=@AddUser,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("AlbumTypeId=@AlbumTypeId,");
            strSql.Append("CoverPhotoPath=@CoverPhotoPath,");
            strSql.Append("AlbumDesc=@AlbumDesc,");
            strSql.Append("AlbumPath=@AlbumPath");
            strSql.Append(" where AlbumId=@AlbumId");
            SqlParameter[] parameters = {
                    new SqlParameter("@AlbumName", SqlDbType.NVarChar,50),
                    new SqlParameter("@AddUser", SqlDbType.NVarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@AlbumTypeId", SqlDbType.Int,4),
                    new SqlParameter("@CoverPhotoPath", SqlDbType.NVarChar,100),
                    new SqlParameter("@AlbumDesc", SqlDbType.NVarChar,200),
                    new SqlParameter("@AlbumPath", SqlDbType.NVarChar,50),
                    new SqlParameter("@AlbumId", SqlDbType.Int,4)};
            parameters[0].Value = model.AlbumName;
            parameters[1].Value = model.AddUser;
            parameters[2].Value = model.AddTime;
            parameters[3].Value = model.AlbumTypeId;
            parameters[4].Value = model.CoverPhotoPath;
            parameters[5].Value = model.AlbumDesc;
            parameters[6].Value = model.AlbumPath;
            parameters[7].Value = model.AlbumId;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 修改相册信息
        /// </summary>
        public int ModifyAlbum(Model.Albums model)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@AlbumName", SqlDbType.NVarChar,50),
                    new SqlParameter("@AlbumTypeId", SqlDbType.Int,4),
                    new SqlParameter("@AlbumDesc", SqlDbType.NVarChar,200),
                    new SqlParameter("@AlbumId", SqlDbType.Int,4)};
            parameters[0].Value = model.AlbumName;
            parameters[1].Value = model.AlbumTypeId;
            parameters[2].Value = model.AlbumDesc;
            parameters[3].Value = model.AlbumId;
            int result = 0;
            return DbHelperSQL.RunProcedure("ModifyAlbum", parameters,out result);
        }
        /// <summary>
        /// 设置相册封面
        /// </summary>
        public int SetAlbumFace(int AlbumId, string path,int photoid)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@CoverPhotoPath", SqlDbType.NVarChar,100),
                    new SqlParameter("@AlbumId", SqlDbType.Int,4),
                    new SqlParameter("@PhotoId", SqlDbType.Int,4)};
            parameters[0].Value = path;
            parameters[1].Value = AlbumId;
            parameters[2].Value = photoid;
            int result = 0;
            return DbHelperSQL.RunProcedure("SetAlbumFace", parameters, out result);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AlbumId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Albums ");
            strSql.Append(" where AlbumId=@AlbumId");
            SqlParameter[] parameters = {
                    new SqlParameter("@AlbumId", SqlDbType.Int,4)
            };
            parameters[0].Value = AlbumId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
		/// 删除相册以及相册下的照片
		/// </summary>
		public int DeleteAlbum(int AlbumId)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@AlbumId", SqlDbType.Int,4)
            };
            parameters[0].Value = AlbumId;
            int rows = 0;
            return DbHelperSQL.RunProcedure("DeleteAlbum", parameters, out rows);

        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string AlbumIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Albums ");
            strSql.Append(" where AlbumId in (" + AlbumIdlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Model.Albums GetModel(int AlbumId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AlbumId,AlbumName,AddUser,AddTime,AlbumTypeId,CoverPhotoPath,AlbumDesc,AlbumPath from Albums ");
            strSql.Append(" where AlbumId=@AlbumId");
            SqlParameter[] parameters = {
                    new SqlParameter("@AlbumId", SqlDbType.Int,4)
            };
            parameters[0].Value = AlbumId;

            Model.Albums model = new Model.Albums();
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
        public Model.Albums DataRowToModel(DataRow row)
        {
            Model.Albums model = new Model.Albums();
            if (row != null)
            {
                if (row["AlbumId"] != null && row["AlbumId"].ToString() != "")
                {
                    model.AlbumId = int.Parse(row["AlbumId"].ToString());
                }
                if (row["AlbumName"] != null)
                {
                    model.AlbumName = row["AlbumName"].ToString();
                }
                if (row["AddUser"] != null)
                {
                    model.AddUser = row["AddUser"].ToString();
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
                }
                if (row["AlbumTypeId"] != null && row["AlbumTypeId"].ToString() != "")
                {
                    model.AlbumTypeId = int.Parse(row["AlbumTypeId"].ToString()); 
                }
                if (row["CoverPhotoPath"] != null)
                {
                    model.CoverPhotoPath = row["CoverPhotoPath"].ToString();
                }
                if (row["AlbumDesc"] != null)
                {
                    model.AlbumDesc = row["AlbumDesc"].ToString();
                }
                if (row["AlbumPath"] != null)
                {
                    model.AlbumPath = row["AlbumPath"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AlbumId,AlbumName,AddUser,AddTime,AlbumTypeId,CoverPhotoPath,AlbumDesc,AlbumPath ");
            strSql.Append(" FROM Albums ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得相册列表
        /// </summary>
        public DataSet GetAlbumList(string strWhere,int AlbumId)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@strWhere", SqlDbType.NVarChar,50),
                    new SqlParameter("@AlbumId", SqlDbType.Int,4)
            };
            parameters[0].Value = strWhere;
            parameters[1].Value = AlbumId;
            return DbHelperSQL.RunProcedure("GetAlbumList",parameters,"ds");
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" AlbumId,AlbumName,AddUser,AddTime,AlbumTypeId,CoverPhotoPath,AlbumDesc,AlbumPath ");
            strSql.Append(" FROM Albums ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Albums ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.AlbumId desc");
            }
            strSql.Append(")AS Row, T.*  from Albums T ");
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
			parameters[0].Value = "Albums";
			parameters[1].Value = "AlbumId";
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

