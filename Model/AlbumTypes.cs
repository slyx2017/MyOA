using System;
namespace Model
{
	/// <summary>
	/// AlbumTypes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AlbumTypes
	{
		public AlbumTypes()
		{}
		#region Model
		private int _albumtypeid;
		private string _albumtypename;
		private string _adduser;
		private DateTime? _addtime;
		/// <summary>
		/// 
		/// </summary>
		public int AlbumTypeId
		{
			set{ _albumtypeid=value;}
			get{return _albumtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AlbumTypeName
		{
			set{ _albumtypename=value;}
			get{return _albumtypename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AddUser
		{
			set{ _adduser=value;}
			get{return _adduser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

