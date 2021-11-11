using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Models
{
    public class Vuelo
    {
        public int ID { get; set; }

        [Column(TypeName ="date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Is Required")]
        [Column(TypeName ="varchar")]
        [MaxLength(50)]
        public string Destino { get; set; }

        [Required(ErrorMessage = "Is Required")]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Origen { get; set; }

        [Range(100,1000)]
        [Column(TypeName = "int")]
        public int Matricula { get; set; }
    }
}