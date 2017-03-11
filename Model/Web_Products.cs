using System;
namespace Model
{
	/// <summary>
	/// Web_Products:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Web_Products
	{
		public Web_Products()
		{}
		#region Model
		private int _id;
		private string _price;
		private string _amount;
		private string _productname;
		private string _productunit;
		private string _total;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductUnit
		{
			set{ _productunit=value;}
			get{return _productunit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Total
		{
			set{ _total=value;}
			get{return _total;}
		}
		#endregion Model

	}
}

