using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiAgenda.Linq;

namespace MiAgenda {
    public partial class Asignaturas : Page {

        AgendaDBEntities db = new AgendaDBEntities();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Session["usuario"] != null)
                    usuarioLbl.InnerText = "Hola, " + ((Usuario)Session["usuario"]).Nombre;
                CargarDatos();
            }
        }

        protected void filtrarBtn_Click(object sender, EventArgs e) {
            int semestre = int.Parse(filtrarTxt.Text.Trim());
            int estado = estadoCb.SelectedIndex;

            List<Asignatura> asignaturas = (from asigs in db.Asignatura.ToList()
                                            where asigs.Semestre == semestre && asigs.Estado == estado
                                            select asigs).ToList();
            CargarDatos(asignaturas);
        }

        protected void agregarBtn_Click(object sender, EventArgs e) {
            Response.Redirect("AgregarAsignatura.aspx");
        }

        protected void asignaturasTable_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "Editar") {
                Session["asignatura_id"] = e.CommandArgument;
                Response.Redirect("EditarAsignatura.aspx");
            }
            else if (e.CommandName == "Eliminar") {
                Asignatura a = db.Asignatura.Find(int.Parse(e.CommandArgument.ToString()));
                if (a.Asistencia != null) {
                    db.Horario.RemoveHorariosFromDB(a);
                    db.Asistencia.RemoveAsistenciaFromDB(a);
                }
                if (a.Notas.Count == 0)
                    db.Notas.RemoveNotasFromDB(a);
                if (a.Examen != null)
                    db.Examen.RemoveExamenFromDB(a);
                db.Asignatura.Remove(a);
                db.SaveChanges();
                mensajeLbl.InnerText = "Asignatura eliminada correctamente";
                CargarDatos();
            }
        }

        private void CargarDatos() {
            CargarDatos(db.Asignatura.ToList());
        }

        private void CargarDatos(List<Asignatura> asignaturas) {
            asignaturasTable.DataSource = asignaturas;
            asignaturasTable.DataBind();
        }
    }
}