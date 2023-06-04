using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ClientMobileHospital.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClientMobileHospital.Broker
{
    public class bMedicamento
    {
        //Utilizamos la coneccion a la base de datos
        readonly SQLiteAsyncConnection _connection;
        public string Error { get; set; }
        public bMedicamento(string rutaDB)
        {
            //Asignamos la conexion
            _connection = new SQLiteAsyncConnection(rutaDB);
        }

        public Task<List<Medicamento>> GetAll()
        {
            return _connection.Table<Medicamento>().ToListAsync();
        }

        public Task<Medicamento> Consultar(int id)
        {
            return _connection.Table<Medicamento>()
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<int> GrabarMedicamento(Medicamento medicamento)
        {
            try
            {
                Medicamento _medicamento = await (_connection.Table<Medicamento>()
                        .Where(p => p.Id == medicamento.Id)
                        .FirstOrDefaultAsync());
                if (_medicamento == null)
                {
                    //Se va a grabar
                    return _connection.InsertAsync(medicamento).Result;
                }
                else
                {
                    //Se va a actualizar
                    return _connection.UpdateAsync(medicamento).Result;
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
                Medicamento _medicamento = await (_connection.Table<Medicamento>()
                        .Where(p => p.Id == id)
                        .FirstOrDefaultAsync());
                return _connection.DeleteAsync(_medicamento).Result;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return -1;
            }
        }
    }
    
}
