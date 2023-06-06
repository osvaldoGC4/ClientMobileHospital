using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMobileHospital.Models
{
    [Table("tblPaciente")]

    public class Paciente
    {
        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        [MaxLength(100)] public string Nombre { get; set; }
        [MaxLength(100)] public string Apellido { get; set; }
        [MaxLength(100)] public string Fecha_Nacimiento { get; set; }
        public string Teléfono { get; set; }
        public string Dirección { get; set; }
        public string Tipo_Documento { get; set; }
        public string Documento { get; set; }
    }
}
