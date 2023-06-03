using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions;

namespace ClientMobileHospital.Models
{
    [Table("tblMedicamento")]

    public class Medicamento
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        [MaxLength(100)] public string Nombre { get; set; }
        [MaxLength(100)] public string Descripcion { get; set; }
        [MaxLength(100)] public string Tipo { get; set; }
        public int Cantidad { get; set; }

    }
}
