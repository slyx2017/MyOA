using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductInventoryManagement.Album
{
    public partial class PhotoDetail : System.Web.UI.Page
    {
        public string imgurl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            imgurl = Request.Params["imgurl"];
        }
    }
}