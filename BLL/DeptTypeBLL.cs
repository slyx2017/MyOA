using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class DeptTypeBLL
    {
        private readonly DAL.DeptTypeDAL dal = new DAL.DeptTypeDAL();
        public DeptTypeBLL()
        { }

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddDeptType(Model.DeptType model)
        {
            return dal.AddDeptType(model);
        }
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ModifyDept(Model.DeptType model)
        {
            return dal.ModifyDept(model);
        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int DeleteDept(int Id)
        {
            return dal.DeleteDept(Id);
        }
        /// <summary>
        /// 获取部门数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDeptList(string strWhere)
        {
            return dal.GetDeptList(strWhere);
        }
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.DeptType GetModel(int ID)
        {
            return dal.GetModel(ID);
        }
    }
}
