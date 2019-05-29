using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MenuChef.Controlar;
using MenuChef.Model;

namespace MenuChef.Controlar
{
    class ControlOrder
    {
        //objeto para llamar a la clase conexion
        Conexion conexion = new Conexion();
        public Boolean altaOrden(int monto)
        {

            int insertar = 0;
            bool respuesta = false;
            //ejecuta la base de datos y las accione que se van a realizar
            //con los parametros 
            SqlCommand comando = new SqlCommand("sp_Orden", conexion.OpenDataBase());
            //llama a los metodos de ejecucion de la base de datos
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //llama a los procedumientos de la base de datos 
            comando.Parameters.AddWithValue("@MontoTotal", monto);
            //captura los errores cometidos durante la ejecucion
            try
            {
                //sirve para consultar la estructura de una base de datos
                //o para cambiar los datos en una base de datos
                insertar = comando.ExecuteNonQuery();
                //sirve para 
                if (insertar < 0)
                {
                    respuesta = true;
                }
                //cierra la base de datos
                conexion.CerrarBaseDatos();
            }
            //muestra los errores cometidos durante la ejecucion de la base de datos
            catch (Exception)
            {
                conexion.CerrarBaseDatos();
                //sirve para lanzar un exepcion
                throw;

            }
            //retorna respuesta
            return respuesta;
        }
        public Boolean altaDetelleOrden(string nombreProducto)
        {
            int insertar = 0;
            bool respuesta = false;
            //objeto que ejecuta la base de datos con los parametros dados
            SqlCommand comando = new SqlCommand("sp_OrdenProductos", conexion.OpenDataBase());
            //llama a la ejecucion en la base de datos
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //llama a los procedimientos en la base de datos con los parametros
            //establecidos
            comando.Parameters.AddWithValue("@NombreProducto", nombreProducto);
            //atrapa los errores cometidos durabte la ejecucion
            try
            {
                //sirve para modificar los datatos dentro de una tabla con 
                //la instruccion que se le dio
                insertar = comando.ExecuteNonQuery();
                if (insertar < 0)
                {
                    respuesta = true;
                }
                //cierra la base de datos
                conexion.CerrarBaseDatos();
            }
            //muestra el error cometido durante la ejecucion
            catch (Exception)
            {
                conexion.CerrarBaseDatos();
                throw;

            }
            return respuesta;
        }
        public Boolean altaOrdenTipoMesaLocal(Mesa _mesa)
        {
            int insertar = 0;
            bool respuesta = false;
            //ejecuta la base de datoscon los parametros establecidos
            SqlCommand comando = new SqlCommand("sp_OrdenMesaLocal", conexion.OpenDataBase());
            //llama a los metodos de ejecucion de la base de datos
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //llama a los procedimientos en la base de datos con los parametros 
            //establecidos
            comando.Parameters.AddWithValue("@IdMesa ", _mesa.Id);
            //captura los errores cometidos durante la ejecucion
            try
            {
                //modifica los datos dentro de la base de datos con la instruccion dada
                insertar = comando.ExecuteNonQuery();
                if (insertar < 0)
                {
                    respuesta = true;
                }
                //cierra la  base de datos
                conexion.CerrarBaseDatos();
            }
            //muestra el error cometido durante la ejecucion
            catch (Exception)
            {
                //cierra la base de datos y muestra una exepcion
                conexion.CerrarBaseDatos();
                throw;

            }
            //retorna respuesta
            return respuesta;
        }

        public Boolean altaOrdenParaLlevar(string observacion)
        {

            int insertar = 0;
            bool respuesta = false;
            //ejecuta la base de datos con los parametros establecidos
            SqlCommand comando = new SqlCommand("sp_OrdenLLevar", conexion.OpenDataBase());
            //llama a los metodos de ejecucion de la base de datos
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //llama a los procedimientos en la base de datos con los parametros 
            //establecidos
            comando.Parameters.AddWithValue("@Observacion", observacion);
            //captura los errores cometidos en la ejecucion
            try
            {
                //modifica los datos de la base de datos con la instruccion dada
                insertar = comando.ExecuteNonQuery();
                if (insertar < 0)
                {
                    respuesta = true;
                }
                //cierra la base de datos
                conexion.CerrarBaseDatos();
            }
            //muestra los errores cometidos durante la ejecucion
            catch (Exception)
            {
                //cierra la base de datos y manda una exepcion
                conexion.CerrarBaseDatos();
                throw;

            }
            //retorna respuesta
            return respuesta;
        }
    }
}
