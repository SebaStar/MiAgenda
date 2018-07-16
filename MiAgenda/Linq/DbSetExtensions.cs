using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MiAgenda.Linq {
    public static class DbSetExtensions {

        static AgendaDBEntities db = new AgendaDBEntities();

        /// <summary>
        /// Elimina un listado de horarios de la base de datos.
        /// </summary>
        /// <param name="list">Base de datos.</param>
        public static void RemoveHorariosFromDB(this DbSet<Horario> list, Asignatura a) {
            List<Horario> horarios = (from hs in list.ToList()
                                      where hs.Asistencia.Id == a.Asistencia.Id
                                      select hs).ToList();
            foreach (Horario h in horarios) {
                list.Remove(h);
            }
            db.SaveChanges();
        }

        public static void RemoveAsistenciaFromDB(this DbSet<Asistencia> list, Asignatura a) {
            Asistencia asistencia = list.Find(a.Asistencia.Id);
            list.Remove(asistencia);
            db.SaveChanges();
        }

        public static void RemoveNotasFromDB(this DbSet<Notas> list, Asignatura a) {
            List<Notas> notas = (from ns in list.ToList()
                                 where ns.Asignatura.Id == a.Id
                                 select ns).ToList();
            foreach (Notas n in notas) {
                list.Remove(n);
            }
            db.SaveChanges();
        }

        public static void RemoveExamenFromDB(this DbSet<Examen> list, Asignatura a) {
            Examen e = list.Find(a.Examen.Id);
            list.Remove(e);
            db.SaveChanges();
        }
    }
}