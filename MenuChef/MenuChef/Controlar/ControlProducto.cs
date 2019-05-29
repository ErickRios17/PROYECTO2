using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MenuChef.Model;
using MenuChef.Controlar;


namespace MenuChef.Controlar
{
    class ControlProducto
    {
        Conexion conexion = new Conexion();
        
        public DataSet SelectProductoByCattegoria(CatProducto _catPr)
        {
            //conjunto de datos, en este caso las tablas
            DataSet productDataSet = new DataSet();
            //objeto para ejecutar la base de datos
            SqlCommand Comando = new SqlCommand();
            //conecta con el servidor y abre la base de datos
            Comando.Connection = conexion.OpenDataBase();
            //llama a los datos almacenados en la base de datos
            Comando.CommandType = CommandType.StoredProcedure;
            //llama a los procedimientos en la base de datos
            Comando.CommandText = "sp_selectAllProducts";
            //llama a los procedimientos de ejecucion en la base de datos
            //utilizaando sus parametros
            Comando.Parameters.AddWithValue("@IdCategoria", _catPr.Id);
            try
            {
                //se usa para actualizar la base de datos y llenar el Dataset
                SqlDataAdapter myAdapter = new SqlDataAdapter(Comando);
                //
                productDataSet = new DataSet();
                //llena un objeto, es una sobrecarga
                myAdapter.Fill(productDataSet);

            }
            //muestra los errores cometidos durante la ejecucion
            catch (Exception ex)
            {
                string m = ex.Message;
                //librea memoria de recursos no administrados
                //los recursos que estan en la base de datos
                Comando.Dispose();
            }
            //cierra la base de datos
            finally
            {
                conexion.CerrarBaseDatos();
            }
            //retorna productaset
            return productDataSet;
        }


        public List<Productos> seleccionarProductoComb()
        {
            //crea una lista 
            List<Productos> listaCtProducto = new List<Productos>();
            //objeto que ejecuta la base de datos
            SqlCommand Comando = new SqlCommand();
            //abre la base de datos
            Comando.Connection = conexion.OpenDataBase();
            //llama los datos almacenados ne la base de datos
            Comando.CommandType = CommandType.StoredProcedure;
            //ejecuta los procedimientos en la base de datos
            Comando.CommandText = "sp_selectProductosCombo";
            //crea un objeto de la clase producto
            Productos _catP = new Productos();

            _catP.NombreProducto = "Seleccione";
            //manda a la listar el producto
            listaCtProducto.Add(_catP);
            //captura los errores cometidos durante la ejecucion
            try
            {
                //procesa eficientemente los resultados de la base de datos
                IDataReader lector = Comando.ExecuteReader();
                //mientras lee los resultados guarda los datos del producto
                while (lector.Read())
                {
                    Productos _catProduto = new Productos();
                    _catProduto.Id = int.Parse(lector[0].ToString());
                    _catProduto.NombreProducto = lector[1].ToString();
                    listaCtProducto.Add(_catProduto);
                }
            }
            //muestra los errores cometidos durante la ejecucion
            catch (Exception ex)
            {
                //muestra el error y librea memoria de recursos no administrados
                string m = ex.Message;
                Comando.Dispose();
            }
            //cierra la base de datos
            finally
            {
                conexion.CerrarBaseDatos();
            }
            //retorna la lista 
            return listaCtProducto;
        }

        public Boolean altaProducto(Productos _producto, CatProducto _CatProduc)
        {

            int insertar = 0;
            bool respuesta = false;
            //objeto que ejecuta la base de datos con los parametros establecidos
            SqlCommand comando = new SqlCommand("sp_altaProducto", conexion.OpenDataBase());
            //ejecuta los procedimientos en la base de datos
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //manda a llamar los procedimientos en la base de datos
            //y da los valores a las variables
            comando.Parameters.AddWithValue("@Nombre", _producto.NombreProducto);
            comando.Parameters.AddWithValue("@Precio", _producto.Precio);
            comando.Parameters.AddWithValue("@IdCat", _CatProduc.Id);

            //captura los errores cometidos durante la ejecucion
            try
            {
                //modifica los datos en la bas de datos con las instrucciones dadas 
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
                //cierra la base de datos y lanza una exepcion
                conexion.CerrarBaseDatos();
                throw;

            }
            //retorna una respuesta
            return respuesta;



        }

        public Boolean eliminarProducto(Productos _producto)
        {

            int elininar = 0;
            bool respuesta = false;
            //ejecuta la base de datos con los parametros establecidos
            SqlCommand comando = new SqlCommand("sp_deleteProducto", conexion.OpenDataBase());
            //ejecuta los procedimientos de la base de datos
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            //define los parametros y evita llamar a los metodos
            comando.Parameters.AddWithValue("@IdProducto", _producto.Id);

            //captura los errores cometidos durante la ejecution
            try
            { 
                //modifica los datos de la base de datos con las instrucciones dadas
                elininar = comando.ExecuteNonQuery();
                if (elininar < 0)
                {
                    respuesta = true;
                }
                //cierra la base de datos
                conexion.CerrarBaseDatos();
            }
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