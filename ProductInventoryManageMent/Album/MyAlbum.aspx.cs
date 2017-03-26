using ProductInventoryManagement.comm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductInventoryManagement.Album
{
    public partial class MyAlbum : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isSessionNull = SessionIsNull();
            if (isSessionNull)
            {
                return;
            }
            if (!IsPostBack)
            {
                string currenPath = Request.FilePath.Substring(1);
                bool isValide = ValidateUserPemiss(currenPath);
                if (isValide)
                {
                    this.rpt_AlbumList.DataSource = GetInfoDS();
                    this.rpt_AlbumList.DataBind();
                }
                else
                {
                    return;
                }
            }
        }
        string strWhere = " 1=1 ";
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetInfoDS()
        {
            BLL.AlbumsBLL bll_a = new BLL.AlbumsBLL();
            int AlbumId = 0;
            DataSet ds = bll_a.GetAlbumList(strWhere, AlbumId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }
        int i = 0;
        protected void rpt_AlbumList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (i % 8 == 0)
            {
                e.Item.Controls.Add(new LiteralControl("<tr></tr>"));
            }
            i++;
        }
    }
}