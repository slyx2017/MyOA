using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// DeptType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class DeptType
    {
        public DeptType()
        { }
        #region Model
        private int? _id;
        private string _deptname;
        private string _sortnum;

        /// <summary>
		/// 
		/// </summary>
		public int? ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DeptName
        {
            set { _deptname = value; }
            get { return _deptname; }
        }

        public string SortNum
        {
            get { return _sortnum;}
            set{ _sortnum = value;}
        }
        #endregion Model
    }
}
