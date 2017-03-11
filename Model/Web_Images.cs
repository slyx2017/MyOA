using System;
namespace Model
{
	/// <summary>
	/// Web_Images:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Web_Images
	{
		public Web_Images()
		{}
		#region Model
		private int _id;
		private string _imagename;
		private string _imagefullname;
		private string _imageurl;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 图片名称 没有后缀名
		/// </summary>
		public string ImageName
		{
			set{ _imagename=value;}
			get{return _imagename;}
		}
		/// <summary>
		/// 图片名称 有后缀名
		/// </summary>
		public string ImageFullName
		{
			set{ _imagefullname=value;}
			get{return _imagefullname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImageURL
		{
			set{ _imageurl=value;}
			get{return _imageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

