using System;
namespace Model
{
	/// <summary>
	/// Albums:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Albums
	{
		public Albums()
		{}
		#region Model
		private int _albumid;
		private string _albumname;
		private string _adduser;
		private DateTime? _addtime;
		private int? _albumtypeid;
        private string _coverphotopath;
        private string _albumdesc;
        private string _albumpath;

        /// <summary>
        /// 
        /// </summary>
        public int AlbumId
		{
			set{ _albumid=value;}
			get{return _albumid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AlbumName
		{
			set{ _albumname=value;}
			get{return _albumname;}
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
		/// 
		/// </summary>
		public int? AlbumTypeId
		{
			set{ _albumtypeid=value;}
			get{return _albumtypeid;}
		}
        /// <summary>
        /// 相册封面图片地址
        /// </summary>
        public string CoverPhotoPath
        {
            get { return _coverphotopath; }
            set { _coverphotopath = value; }
        }
        /// <summary>
        /// 相册简介
        /// </summary>
        public string AlbumDesc
        {
            get { return _albumdesc; }
            set { _albumdesc = value; }
        }
        /// <summary>
        /// 相册文件夹路径
        /// </summary>
        public string AlbumPath
        {
            get
            {
                return _albumpath;
            }

            set
            {
                _albumpath = value;
            }
        }

        #endregion Model

    }
}

