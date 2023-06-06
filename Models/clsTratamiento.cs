﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ClientMobileHospital.Models
{
    [Table("tblTratamiento")]

    public class Tratamiento
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        [MaxLength(100)] public string Nombre { get; set; }
        [MaxLength(100)] public string Descripcion { get; set; }
        public decimal Costo { get; set; }

    }
}
