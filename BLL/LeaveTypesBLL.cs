using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public partial class LeaveTypesBLL
    {
        private readonly DAL.LeaveTypesDAL dal=new DAL.LeaveTypesDAL();
        public LeaveTypesBLL()
		{}
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
    }
}
