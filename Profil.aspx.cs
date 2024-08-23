using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using FunctiiSQL;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Farmacie1
{
    public partial class Profil : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
        }
        protected void DeleteAccount(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            if (User.Identity.IsAuthenticated)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                authenticationManager.SignOut();
                var userIdentity = userManager.DeleteAsync(userManager.FindById(User.Identity.GetUserId()));
                Response.Redirect("~/Login.aspx");
            }
        }
    }

}