using System;
using System.Web.UI;
using MiAgenda.Linq;

namespace MiAgenda {
    public partial class Registrar : Page {

        AgendaDBEntities db = new AgendaDBEntities();

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void registrarBtn_Click(object sender, EventArgs e) {
            string nombre = nombreTxt.Text.Trim();
            string password = passwordTxt.Text.Trim();
            string repetirPassword = rpasswordTxt.Text.Trim();
            mensajeLbl.Attributes.Remove("class");

            if (nombre.IsEmpty() || password.IsEmpty() || repetirPassword.IsEmpty()) {
                mensajeLbl.Attributes.Add("class", "alert alert-danger");
                mensajeLbl.InnerText = "¡Hay campos en blanco!";
            }
            else {
                if (password != repetirPassword) {
                    mensajeLbl.Attributes.Add("class", "alert alert-danger");
                    mensajeLbl.InnerText = "Las contraseñas no coinciden";
                }
                else {
                    Usuario u = new Usuario {
                        Nombre = nombre,
                        Password = password.EncryptPassword()
                    };
                    db.Usuario.Add(u);
                    db.SaveChanges();
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }
}