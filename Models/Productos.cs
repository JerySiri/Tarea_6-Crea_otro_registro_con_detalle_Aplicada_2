using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OtroRegistroConDetalle.Models
{
    public class Productos
    {
        [Key]
        public int productoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir una descripcion.")]
        public string descripcion { get; set; }

        public float costo { get; set; }

        public float inventario { get; set; }
    }
}
