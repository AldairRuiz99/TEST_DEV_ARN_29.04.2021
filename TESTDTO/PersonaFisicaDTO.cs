using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTDTO
{
    public class PersonaFisicaDTO
    {
        public int IdPersonaFisica { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string RFC { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime FechaNacimiento { get; set; }
        public int UsuarioAgrega { get; set; }
        public bool Activo { get; set; }

        public Response ResponseCode { get; set; }
        public string ResponseText { get; set; }
    }
}
