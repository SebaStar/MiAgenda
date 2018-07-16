using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiAgenda.Linq;

namespace MiAgenda {
    public partial class Default : Page {

        AgendaDBEntities db = new AgendaDBEntities();

        protected void Page_Load(object sender, EventArgs e) {
            if (Page.User.Identity.IsAuthenticated)
                Response.Redirect("Asignaturas.aspx");
        }

        protected void loginForm_Authenticate(object sender, AuthenticateEventArgs e) {
            string nombre = loginForm.UserName;
            string password = loginForm.Password.EncryptPassword();
            Usuario u = db.Usuario.Where(us => us.Nombre == nombre && us.Password == password).First();

            if (u != null) {
                Session["usuario"] = u;
                FormsAuthentication.RedirectFromLoginPage(nombre, loginForm.RememberMeSet);
            }
        }
    }
}