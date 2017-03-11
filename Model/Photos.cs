using System;
namespace Model
{
	/// <summary>
	/// Photos:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Photos
	{
		public Photos()
		{}
		#region Model
		private int _photoid;
		private int? _albumid;
		private string _photoname;
		private string _photopath;
		private string _photodesc;
		private string _adduser;
		private DateTime? _addtime;
        private bool _isalbumface;
        /// <summary>
        /// 
        /// </summary>
        public int PhotoId
		{
			set{ _photoid=value;}
			get{return _photoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AlbumId
		{
			set{ _albumid=value;}
			get{return _albumid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PhotoName
		{
			set{ _photoname=value;}
			get{return _photoname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PhotoPath
		{
			set{ _photopath=value;}
			get{return _photopath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PhotoDesc
		{
			set{ _photodesc=value;}
			get{return _photodesc;}
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
        /// <summary>
        /// 0：未设为封面；1：设为封面
        /// </summary>
        public bool IsAlbumFace
        {
            get
            {
                return _isalbumface;
            }

            set
            {
                _isalbumface = value;
            }
        }
        #endregion Model

    }
}

