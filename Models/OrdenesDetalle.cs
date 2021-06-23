using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OtroRegistroConDetalle.Models
{
    public class OrdenesDetalle
    {
        [Key]
        public int id { get; set; }

        public int ordenId { get; set; } = 0;

        [Range(1, int.MaxValue, ErrorMessage = "Seleccionar un producto valido.")]
        public int productoId { get; set; }
        public virtual Productos producto { get; set; }

        public float cantidad { get; set; } =  0f;

        public float costo { get; set; } = 0f;
    }
}
