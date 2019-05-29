using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using MenuChef.Model;
using System.Windows.Forms;



namespace MenuChef.Controlar
{

    //las clases control sirven para que gurden recuperen ejecuten
    //continuen con la ejecucion de la aplicacion y devuelvan la solucion
    //que el cliente quiere
    class ControlarMesas
    {
        Conexion conexion = new Conexion();


        //este metodo sirbe para saber si la mesa esta ocupada o esta
        //libre para poder utilizarla
        public string[] StatusMesa()
        {


            string[] numMesas = new string[12];
            //el sqlcommand es una instruccion que ejecuta la base de datos
            //aqui se crea un objeto para ejecutar la base de datos y dar
            //las instruccuiones que se decea
            SqlCommand Comando = new SqlCommand();

            //estos comandos sirven para conectarse al servidor y hacer lo que
            //se decea por ejemplo abrir la base de datos
            //en el comando text se selecciona la tabla que se quiere abrir o
            //la tabla que se decea ejecutar
            Comando.Connection = conexion.OpenDataBase();
            //este comando sirbe para llamar datos almacenados en la base de datos
            Comando.CommandType = CommandType.StoredProcedure;
            //manda a llamar los procedimientos en la base de datos
            Comando.CommandText = "sp_selecMesas";
            //creamos un objeto llamado mesa
            Mesa mesa = new Mesa();

            try
            {
                int i = 0;

            //el IDataReader permite procesar eficientemente los resultados
            //de una fuente de base de datos de forma secuencial.
                IDataReader lector = Comando.ExecuteReader();
                while (lector.Read())
                {
                    Mesa mesa1 = new Mesa();

                    numMesas[i] = lector[2].ToString();
                    i++;
                }
                numMesas[i + 1] = "Fin";
            }
            catch (Exception ex)
            {
                string m = ex.Message;

            //el metodo dispose se utiliza para liberar memoria
            //y para desacerse de los recursos no administrados
            //los archivos no aministrados en este caso seria la tabla
            //y la coneccion a la base de datos
                Comando.Dispose();
            }
            finally
            {
                //este metedo llama a la clase conexion y al metodo cerrar
                //base de datos, que hace como lo dice su nombre cerrrar la base 
                //de datos
                conexion.CerrarBaseDatos();
            }
            //retorna el numero de mesa
            return numMesas;
        }

        public List<Mesa> MesaDisponible()
        {
            //crea una lista para morstrar las mesas disponibles
            List<Mesa> listMesaDisponible = new List<Mesa>();
            //crea un objeto para ejecutar la base de datos
            SqlCommand Comando = new SqlCommand();
            //conecta a la base de datos y se abre
            Comando.Connection = conexion.OpenDataBase();
            //llama a los datos guardados en la base de datos, como las tablas
            Comando.CommandType = CommandType.StoredProcedure;
            //manda a llamar los procedimientos en la base de datos
            Comando.CommandText = "sp_selectMesasLibres";
            //crea un objeto llamado mesa
            Mesa mesa = new Mesa();
            //sirbe para atrapar errores
            try
            {
                //permite procesasr los resultados de una base de datos
                IDataReader lector = Comando.ExecuteReader();
                //este sirve para leer los datos que hay en la tabla y listar
                //las mesas, y le da valor a sus variables.
                while (lector.Read())
                {
                
                    Mesa mesa1 = new Mesa();
                    mesa1.Id = int.Parse(lector[0].ToString());
                    mesa1.NumeroMesa = int.Parse(lector[1].ToString());
                    listMesaDisponible.Add(mesa1);
                }
            }
            //es la exepcion que mandara un mensaje con el error cometido durante
            //la ejecucion 
            catch (Exception ex)
            {
                string m = ex.Message;
                Comando.Dispose();
            }
            finally
            //cierra la base de datos
            {
                conexion.CerrarBaseDatos();
            }
            return listMesaDisponible;
        }


        public List<Mesa> SelectMesasOcupadas()
        {
            //crea una lista para las mesas ocupadas
            List<Mesa> listMesasDisponibles = new List<Mesa>();
            //objeto para ejecutar la base de datos
            SqlCommand Comando = new SqlCommand();
            //abre la coneccion a la base de datos
            Comando.Connection = conexion.OpenDataBase();
            //llama a los datos almacenados en la base de datos
            Comando.CommandType = CommandType.StoredProcedure;
            //manda a llamar los procedimientos en la base de datos
            Comando.CommandText = "sp_selectMesasOcupadas";
            //objeto que llama a la clase mesa que contiene las variables
            //que se van a utilizar
            Mesa mesa = new Mesa(); 
            //captura los errores cometidos durante la ejecucion
            try
            {
                //procesa eficientemente loas resultados de la base de datos
                IDataReader lector = Comando.ExecuteReader();
                //da valores a las variables en la clase mesa 
                while (lector.Read())
                {
                    Mesa _mesa = new Mesa();
                    _mesa.Id = int.Parse(lector[0].ToString());
                    _mesa.NumeroMesa = int.Parse(lector[1].ToString());
                    listMesasDisponibles.Add(_mesa);
                }
            }
            //muestra los errores cometidos durante el proceso 
            catch (Exception ex)
            {
                string m = ex.Message;
                Comando.Dispose();
            }
            //cierra la base de datos
            finally
            {
                conexion.CerrarBaseDatos();
            }
            //retorna listar mesas disponibles
            return listMesasDisponibles;
        }

        public Boolean LiberarMesa(Mesa mesa)
        {
            int insertar = 0;
            bool respuesta = false;
            //crea un objeto con los parametros de la accion a ejecutar
            SqlCommand comando = new SqlCommand("sp_liberarMesa", conexion.OpenDataBase());
            //llama a los metodos de ejecucion en la base de datos
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            //manda a llamar los procedimientos en la base de datos
            comando.Parameters.AddWithValue("@IdMesa", mesa.Id);

            try
            {
                //sirve para modificar los datos dentro de la tabla con la instruccion 
                //que se le dio
                insertar = comando.ExecuteNonQuery();
                if(insertar<0)
                {
                    respuesta = true;
                }
                conexion.CerrarBaseDatos();
            }
            //cierra la base de datos
            catch(Exception)
            {
                conexion.CerrarBaseDatos();
                throw;
            }
            //devuleve respuesta
            return respuesta;

        }
    }
}
