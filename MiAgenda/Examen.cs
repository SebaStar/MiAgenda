//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiAgenda
{
    using System;
    using System.Collections.Generic;
    
    public partial class Examen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Examen()
        {
            this.Asignatura = new HashSet<Asignatura>();
        }
    
        public int Id { get; set; }
        public double Nota { get; set; }
        public int Porcentaje { get; set; }
        public int Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asignatura> Asignatura { get; set; }
    }
}
