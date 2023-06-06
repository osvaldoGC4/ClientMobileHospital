﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ClientMobileHospital.Models;


namespace ClientMobileHospital.BaseDatos
{
    public class clsBaseDatos
    {
        //Definimos los atributos de la base de datos
        private readonly SQLiteAsyncConnection _connection;
        private bool bMedicamento, bPaciente, bTratamiento;
        private const SQLiteOpenFlags Flags =
          SQLiteOpenFlags.ReadWrite |
          SQLiteOpenFlags.Create |
          SQLiteOpenFlags.SharedCache;
        public clsBaseDatos(string Ruta) 
        {
            //Recibe la ruta donde se va a crear la base de datos
            _connection = new SQLiteAsyncConnection(Ruta, Flags);
            bMedicamento = true;
            bPaciente = true;
            bTratamiento = true;

        }

        public void CrearTabla()
        {
            if(bMedicamento) { _connection.CreateTableAsync<Medicamento>().Wait(); }
            if(bPaciente) { _connection.CreateTableAsync<Paciente>().Wait(); }
            if(bTratamiento) { _connection.CreateTableAsync<Tratamiento>().Wait(); }
        }
    }
}
