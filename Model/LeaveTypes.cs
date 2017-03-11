using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// LeaveTypes:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class LeaveTypes
    {
        public LeaveTypes()
        { }
        #region Model
        private int _id;
        private string _leavename;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LeaveName
        {
            set { _leavename = value; }
            get { return _leavename; }
        }
        #endregion Model

    }
}
