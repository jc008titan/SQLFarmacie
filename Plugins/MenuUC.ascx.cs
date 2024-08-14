using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Farmacie1.Plugins
{
    public partial class MenuUC : System.Web.UI.UserControl
    {
        public string id="";
        public string cont = "";
        public bool Authenticated=false;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Context.User.Identity.GetUserId();
            cont += Context.User.Identity.GetUserName();
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
        }
        protected void SignOut(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/Login.aspx");
        }

    }
}