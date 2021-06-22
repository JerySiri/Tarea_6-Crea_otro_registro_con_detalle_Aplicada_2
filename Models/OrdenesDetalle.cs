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

        public float cantidad { get; set; } =  0f;

        public float costo { get; set; } = 0f;
    }
}
