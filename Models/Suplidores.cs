using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OtroRegistroConDetalle.Models
{
    public class Suplidores
    {
        [Key]
        public int suplidorId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el nombre.")]
        [MinLength(4, ErrorMessage = "El Nombre debe tener por lo menos 4 caracteres.")]
        public string nombre { get; set; }

    }
}
