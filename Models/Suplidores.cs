using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPedidosBlazor.Models
{
    public class Suplidores
    {
        [Key]
        public int SuplidorID { get; set; }

        public string Nombres { get; set; }

        [ForeignKey("SuplidorID")]
        public virtual List<Ordenes> Ordenes { get; set; }
    }
}
