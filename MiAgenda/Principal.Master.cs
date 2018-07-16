using System;
using System.Web.Security;
using System.Web.UI;

namespace MiAgenda {
    public partial class Principal : MasterPage {

        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.User.Identity.IsAuthenticated)
                FormsAuthentication.RedirectToLoginPage();
        }

        protected void cerrarSesionBtn_Click(object sender, EventArgs e) {
            Session.Remove("usuario");
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}