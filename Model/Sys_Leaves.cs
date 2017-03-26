using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
	/// <summary>
	/// Sys_Leaves:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sys_Leaves
	{
		public Sys_Leaves()
		{}
		#region Model
		private int _id;
		private string _leavereason;
		private int? _leavetypeid;
		private DateTime? _applytime;
		private string _approvalperson;
		private DateTime? _begintime;
		private DateTime? _endtime;
		private int? _leavestatus;
		private DateTime? _cancelleavetime;
		private string _applyperson;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LeaveReason
		{
			set{ _leavereason=value;}
			get{return _leavereason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LeaveTypeID
		{
			set{ _leavetypeid=value;}
			get{return _leavetypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ApplyTime
		{
			set{ _applytime=value;}
			get{return _applytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApprovalPerson
		{
			set{ _approvalperson=value;}
			get{return _approvalperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BeginTime
		{
			set{ _begintime=value;}
			get{return _begintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LeaveStatus
		{
			set{ _leavestatus=value;}
			get{return _leavestatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CancelLeaveTime
		{
			set{ _cancelleavetime=value;}
			get{return _cancelleavetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApplyPerson
		{
			set{ _applyperson=value;}
			get{return _applyperson;}
		}
		#endregion Model

	}
}
