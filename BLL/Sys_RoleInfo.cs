﻿using System;
using System.Data;
using System.Collections.Generic;
using Common;
using Model;
namespace BLL
{
	/// <summary>
	/// Sys_RoleInfo
	/// </summary>
	public partial class Sys_RoleInfo
	{
		private readonly DAL.Sys_RoleInfo dal=new DAL.Sys_RoleInfo();
		public Sys_RoleInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RoleID)
		{
			return dal.Exists(RoleID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.Sys_RoleInfo model)
		{
			return dal.Add(model);
		}
        /// <summary>
        /// 新增角色
        /// </summary>
        public int AddNewRole(Model.Sys_RoleInfo model)
        {
            return dal.AddNewRole(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Sys_RoleInfo model)
		{
			return dal.Update(model);
		}
        /// <summary>
        /// 编辑角色
        /// </summary>
        public int EditRole(Model.Sys_RoleInfo model)
        {
            return dal.EditRole(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RoleID)
		{
			
			return dal.Delete(RoleID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string RoleIDlist )
		{
			return dal.DeleteList(RoleIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Sys_RoleInfo GetModel(int RoleID)
		{
			
			return dal.GetModel(RoleID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Model.Sys_RoleInfo GetModelByCache(int RoleID)
		{
			
			string CacheKey = "Sys_RoleInfoModel-" + RoleID;
			object objModel = Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(RoleID);
					if (objModel != null)
					{
						int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
						Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Model.Sys_RoleInfo)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获得角色列表 "roleId=0":查询角色表;"roleId=-1":查询角色菜单映射表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="roleId">"roleId=0":查询角色表;"roleId=-1":查询角色菜单映射表</param>
        /// <returns></returns>
        public DataSet GetRoleList(string strWhere,int roleId)
        {
            return dal.GetRoleList(strWhere, roleId);
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
		public List<Model.Sys_RoleInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Sys_RoleInfo> DataTableToList(DataTable dt)
		{
			List<Model.Sys_RoleInfo> modelList = new List<Model.Sys_RoleInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.Sys_RoleInfo model;
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

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

