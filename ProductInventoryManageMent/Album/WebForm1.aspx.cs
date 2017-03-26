using DBUtility;
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
    public partial class WebForm1 : BasePage
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
                    GetAlbumTypeList();
                    GetInfoDS();
                }
                else
                {
                    return;
                }
            }
        }
        /// <summary>
        /// 获取数据库列表
        /// </summary>
        /// <returns></returns>
        public void GetAlbumTypeList()
        {
            BLL.AlbumTypesBLL bll_pl = new BLL.AlbumTypesBLL();
            DataSet ds = bll_pl.GetAlbumType();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_AlbumTypeList.DataSource = ds;
                ddl_AlbumTypeList.DataTextField = "AlbumTypeName";
                ddl_AlbumTypeList.DataValueField = "ID";
                ddl_AlbumTypeList.DataBind();
                ddl_AlbumTypeList.Items.Insert(0, new ListItem("--请选择--","-1"));
            }

        }
        string strWhere = " uIsDel!=1 ";
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public void GetInfoDS()
        {
            BLL.UsersBLL bll_u = new BLL.UsersBLL();
            DataSet ds = bll_u.GetUserList(strWhere);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.rpt_UserList.DataSource = ds;
                this.rpt_UserList.DataBind();
            }

        }

        protected void ddl_AlbumTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dbName = ddl_AlbumTypeList.SelectedValue;
            switch (dbName)
            {
                case "1":
                    DbHelperSQL.connectionString = PubConstant.SetConnName(0);
                    GetInfoDS();
                    break;
                case "2":
                  DbHelperSQL.connectionString=  PubConstant.SetConnName(1);
                    GetInfoDS();
                    break;
                default:
                    break;
            }
        }
    }
}