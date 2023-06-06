using ClientMobileHospital.Models;
using Microsoft.Maui.Graphics;
using Newtonsoft.Json;
using SQLite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMobileHospital.Broker
{
    internal class bPaciente
    {
        readonly SQLiteAsyncConnection _connection;
        private string baseService = "http://andreiflorez-001-site1.btempurl.com/";
        private string serviceRouter = "Api/Paciente";
        public string Error { get; set; }
        public bPaciente(string rutaDB)
        {
            //Asignamos la conexion
            _connection = new SQLiteAsyncConnection(rutaDB);
        }

        public Task<List<Paciente>> GetAll()
        {
            return _connection.Table<Paciente>().ToListAsync();
        }

        public Task<Paciente> Consultar(int id)
        {
            return _connection.Table<Paciente>()
                    .Where(p => p.ID == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<int> GrabarPaciente(Paciente paciente)
        {
            try
            {
                Paciente _paciente = await (_connection.Table<Paciente>()
                        .Where(p => p.ID == paciente.ID)
                        .FirstOrDefaultAsync());
                if (_paciente == null)
                {
                    //Se va a grabar
                    return _connection.InsertAsync(paciente).Result;
                }
                else
                {
                    //Se va a actualizar
                    return _connection.UpdateAsync(paciente).Result;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return -1;
            }
        }

        public async Task<int> Eliminar(int id)
        {
            try
            {
                Paciente _paciente = await (_connection.Table<Paciente>()
                        .Where(p => p.ID == id)
                        .FirstOrDefaultAsync());
                return _connection.DeleteAsync(_paciente).Result;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return -1;
            }
        }

        public List<Paciente> getAllServicio()
        {
            try
            {
                string url = baseService + serviceRouter + "/GetAll";
                var client = new HttpClient();
                var request = new HttpRequestMessage();
                var response = client.GetStringAsync(url).Result;
                List<Paciente> pacientes = JsonConvert.DeserializeObject< List<Paciente>> (response);
                return pacientes;
            }
            catch(Exception e)
            {
                string Error = e.Message;
                return null;
            }
        }

        public List<Paciente> InsertarPacientesServicio()
        {
            List<Paciente> paciente = getAllServicio();
            var patientMapping = new TableMapping(typeof(Paciente));
            _connection.DeleteAllAsync(patientMapping) ;
            _connection.InsertAllAsync(paciente);
            return paciente;
        }
    }
}
