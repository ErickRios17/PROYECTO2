using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MenuChef.Model;
using MenuChef.Properties;
using MenuChef.Controlar;

namespace MenuChef.Controlar
{
    class ControlCatProductos
    {
        //objeto para llamar a la coneccion de base de datos
        Conexion conexion = new Conexion();

        public List<CatProducto> seleccionarCatProducto()
        {
            //obejeto para listar un producto 
            List<CatProducto> listaCtProducto = new List<CatProducto>();
            //objeto para ejecutar la base de datos
            SqlCommand Comando = new SqlCommand();
            //conecta con la base de datos 
            Comando.Connection = conexion.OpenDataBase();
            //llama a los datos de la base de datos
            Comando.CommandType = CommandType.StoredProcedure;
            //manda a llamar los procedimientos en la base de datos
            Comando.CommandText = "sp_catProduct";
            //captura los errores cometidos en la ejecucion
            try
            {
                //procesa eficasmente  los resultado de la base de datos
                IDataReader lector = Comando.ExecuteReader();
                //mientras lee los resultados evalua los valores dados a las
                //variables
                while (lector.Read())
                {
                    CatProducto _catProduto = new CatProducto();
                    _catProduto.Id = int.Parse(lector[0].ToString());
                    _catProduto.Categoria = lector[1].ToString();
                    listaCtProducto.Add(_catProduto);
                }
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
            //retorna listactproducto
            return listaCtProducto;
        }
    }
}

