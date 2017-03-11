using System;
using System.Data;
using System.Collections.Generic;
namespace BLL
{
    /// <summary>
    /// Albums
    /// </summary>
    public partial class Albums
	{
		private readonly DAL.Albums dal=new DAL.Albums();
		public Albums()
		{}
		#region  BasicMethod
        /// <summary>
		/// 新增相册
		/// </summary>
		public int AddAlbum(Model.Albums model)
        {
            return dal.AddAlbum(model);
        }
        /// <summary>
        /// 修改相册信息
        /// </summary>
        public int ModifyAlbum(Model.Albums model)
        {
            return dal.ModifyAlbum(model);
        }
        /// <summary>
        /// 设置相册封面
        /// </summary>
        public int SetAlbumFace(int AlbumId,string path,int photoid)
        {
            return dal.SetAlbumFace(AlbumId, path, photoid);
        }
        /// <summary>
        /// 删除相册以及相册下的照片
        /// </summary>
        public int DeleteAlbum(int AlbumId)
        {
            return dal.DeleteAlbum(AlbumId);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        /// <summary>
        /// 获得相册列表
        /// </summary>
        public DataSet GetAlbumList(string strWhere, int AlbumId)
        {
            return dal.GetAlbumList(strWhere,AlbumId);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Albums> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Albums> DataTableToList(DataTable dt)
		{
			List<Model.Albums> modelList = new List<Model.Albums>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.Albums model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

