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

    public partial class tbl_Ventas
    {
        public int vent_IdVentasPk { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Venta")]
        [Required(ErrorMessage = "{0} es requerido")]
        public System.DateTime vent_FechaVenta { get; set; }
        //[Display(Name = "Cliente")]
        public int vent_IdClienteFk { get; set; }
        //[Display(Name = "Producto")]
        public int vent_IdProductoFk { get; set; }
    
        public virtual tbl_Clientes tbl_Clientes { get; set; }
        public virtual tbl_Productos tbl_Productos { get; set; }
    }
}
