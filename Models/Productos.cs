using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPedidosBlazor.Models
{
    public class Productos
    {
        [Key]
        public int ProductoID { get; set; }

        public string Descripcion { get; set; }

        public float Costo { get; set; }

        public float Inventario { get; set; }
    }
}
