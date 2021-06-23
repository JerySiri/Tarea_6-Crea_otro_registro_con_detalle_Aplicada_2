using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtroRegistroConDetalle.Models
{
    public class Ordenes
    {
        [Key]
        public int ordenId { get; set; }

        public DateTime fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Debe seleccionar un Suplidor.")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccionar un Suplidor valido.")]
        public int suplidorId { get; set; } = 0;
        public virtual Suplidores suplidor { get; set; }

        public float monto { get; set; } = 0f;

        [ForeignKey("ordenId")]
        public virtual List<OrdenesDetalle> OrdenesDetalle { get; set; } = new List<OrdenesDetalle>();
    }
}
