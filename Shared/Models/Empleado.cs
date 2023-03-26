using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnjoyOnline.Shared.Models
{
    public class Empleado
    {
        [Key]
        public int Nro_Funcionario { get; set; }
        [Required] 
        public string Nombre { get; set; }
        [Required]

        public string  Apellido { get; set; }
        [Required]

        public string Departamento { get; set; }
        [Required]

        public string Sector { get; set; }
        [Required]

        public string Cargo { get; set; }
        [Required]

        public string Estado { get; set; }
        [Required]

        public string Contrato { get; set; }

        [Required]

        public string Condicion { get; set; }
        [Required]

        public string Fecha_de_ultimo_ingreso { get; set; }
        [Required]

        public string Fecha_de_Egreso { get; set; }

        public string? Url_Foto { get; set; } 


    }
}
