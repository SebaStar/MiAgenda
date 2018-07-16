using System;
using System.Collections.Generic;
using System.Linq;
using MiAgenda.Linq;

namespace MiAgenda {
    public partial class Asignatura {

        AgendaDBEntities db = new AgendaDBEntities();

        public string EstadoText {
            get { return Estado == 1 ? "Cerrado" : "Sin cerrar"; }
        }

        public string DocenteText {
            get { return Docente.IsEmpty() ? "---" : Docente; }
        }

        public string SeccionText {
            get { return Seccion.IsEmpty() ? "---" : Seccion; }
        }

        private float Promedio {
            get {
                float promedio = 0.0f, promNormal = 0.0f;
                int porcentaje = 0;
                List<Notas> notas = (from ns in db.Notas.ToList()
                                     where ns.Asignatura.Id == Id
                                     select ns).ToList();
                if (notas.Count == 0)
                    return -1.0f;
                foreach (Notas n in notas) {
                    promNormal += (float)n.Nota;
                    promedio += (float)(n.Nota * (n.Porcentaje / 100.0));
                    porcentaje += n.Porcentaje;
                }
                porcentaje = 100 - porcentaje;
                promNormal /= notas.Count;
                PromedioPorcentajeMomento = promedio;
                PromedioPorcentajeRestante = porcentaje;
                if (porcentaje > 0)
                    promedio += (promNormal * (porcentaje / 100.0f));
                return (float)Math.Round(promedio, 1);
            }
        }

        private float PromedioPorcentajeMomento { get; set; }

        private int PromedioPorcentajeRestante { get; set; }

        private List<Horario> Horarios {
            get {
                return (from hs in db.Horario.ToList()
                        where hs.Asistencia.Id == Asistencia.Id
                        select hs).ToList();
            }
        }

        private int AsistenciaPorcentaje {
            get {
                int asistidas = 0, momento = 0;
                if (Asistencia == null)
                    return -1;
                List<Horario> horarios = Horarios;
                foreach (Horario h in horarios) {
                    momento += h.Bloques;
                    asistidas += h.Estado == 1 ? h.Bloques : 0;
                }
                HorasMomento = momento;
                HorasIdas = asistidas;
                return (int)Math.Round((100.0f / Asistencia.HorasTotales) * asistidas);
            }
        }

        private int HorasMomento { get; set; }

        private int HorasIdas { get; set; }

        public string PromedioText {
            get { return Promedio == -1 ? "---" : Promedio.ToString(); }
        }

        public string AsistenciaPorcentajeText {
            get { return AsistenciaPorcentaje == -1 ? "---" : AsistenciaPorcentaje.ToString() + "%"; }
        }

        public string Situacion {
            get {
                if (Promedio == -1 || AsistenciaPorcentaje == -1) {
                    if (Promedio >= 4)
                        return "Aprobado por nota";
                    else {
                        if (AsistenciaPorcentaje >= Asistencia.PorcentajeMinimo)
                            return "Aprobado por asistencia";
                        else
                            return "Sin situación";
                    }
                }
                else {
                    if (Estado == 1) {
                        if (Promedio >= 4 && AsistenciaPorcentaje >= Asistencia.PorcentajeMinimo)
                            return "Aprobado";
                        else
                            return "Reprobado";
                    }
                    else {
                        if (Promedio >= 4) {
                            if (PorcentajeMomento < Asistencia.PorcentajeMinimo) {
                                if (PorcentajeUltimaInstancia < Asistencia.PorcentajeMinimo)
                                    return "Reprobado por inasistencia";
                                else
                                    return "Riesgo por asistencia";
                            }
                            else
                                return "Sin riesgo";
                        }
                        else {
                            if (PromedioUltimaInstancia < 4) {
                                if (PorcentajeUltimaInstancia < Asistencia.PorcentajeMinimo)
                                    return "Reprobado por nota e inasistencia";
                                else
                                    return "Reprobado por nota";
                            }
                            else {
                                if (PorcentajeMomento < Asistencia.PorcentajeMinimo) {
                                    if (PorcentajeUltimaInstancia < Asistencia.PorcentajeMinimo)
                                        return "Reprobado por inasistencia";
                                    else
                                        return "Riesgo por nota y asistencia";
                                }
                                else
                                    return "Riesgo por nota";
                            }
                        }
                    }
                }
            }
        }

        private int PorcentajeMomento {
            get { return (int)Math.Round((100.0f / HorasMomento) * HorasIdas, 0); }
        }

        private int PorcentajeUltimaInstancia {
            get { return (int)Math.Round((100.0f / Asistencia.HorasTotales) * (HorasIdas + Asistencia.HorasTotales - HorasMomento)); }
        }

        private float PromedioUltimaInstancia {
            get { return (float)Math.Round((7.0f + (PromedioPorcentajeRestante / 100.0f)) + PromedioPorcentajeMomento, 1); }
        }
    }
}