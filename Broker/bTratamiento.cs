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
    public class bTratamiento
    {
        //Utilizamos la conexion a la base de datos
        readonly SQLiteAsyncConnection _connection;
        public string Error { get; set; }
        public bTratamiento(string rutaDB)
        {
            //Asignamos la conexion
            _connection = new SQLiteAsyncConnection(rutaDB);
        }

        public Task<List<Tratamiento>> GetAll()
        {
            return _connection.Table<Tratamiento>().ToListAsync();
        }

        public Task<Tratamiento> Consultar(int id)
        {
            return _connection.Table<Tratamiento>()
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<int> GrabarTratamiento(Tratamiento tratamiento)
        {
            try
            {
                Tratamiento _tratamiento = await (_connection.Table<Tratamiento>()
                        .Where(p => p.Id == tratamiento.Id)
                        .FirstOrDefaultAsync());
                if (_tratamiento == null)
                {
                    //Se va a grabar
                    return _connection.InsertAsync(tratamiento).Result;
                }
                else
                {
                    //Se va a actualizar
                    return _connection.UpdateAsync(tratamiento).Result;
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
                Tratamiento _tratamiento = await (_connection.Table<Tratamiento>()
                        .Where(p => p.Id == id)
                        .FirstOrDefaultAsync());
                return _connection.DeleteAsync(_tratamiento).Result;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return -1;
            }
        }

    }
}
