//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationAseguradorasB.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    public partial class tbl_Aseguradoras
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Aseguradoras()
        {
            this.tbl_Productos = new HashSet<tbl_Productos>();
        }
    
        public int aseg_IdAseguradoraPk { get; set; }
        [Display(Name = "Nombre Aseguradora")]
        [Required(ErrorMessage = "{0} es requerido")]
        public string aseg_NombreAseguradora { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Productos> tbl_Productos { get; set; }
    }
}
