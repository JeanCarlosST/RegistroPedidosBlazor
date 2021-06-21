using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPedidosBlazor.Models
{
    public class Ordenes
    {
        [Key]
        public int OrdenID { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Seleccione un suplidor")]
        public int SuplidorID { get; set; }

        public float Monto { get; set; }

        [ForeignKey("OrdenID")]
        public virtual List<OrdenesDetalle> Detalle { get; set; } = new List<OrdenesDetalle>();
    }

    public class OrdenesDetalle
    {
        [Key]
        public int OrdenDetalleID { get; set; }

        public int OrdenID { get; set; }

        [Required(ErrorMessage = "Seleccione un producto")]
        public int ProductoID { get; set; }

        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Seleccine una cantidad")]
        public float Cantidad { get; set; }

        public float Costo { get; set; }
    }
}
