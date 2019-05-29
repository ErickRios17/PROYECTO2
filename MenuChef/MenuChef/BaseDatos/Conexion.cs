using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace MenuChef
{
    class Conexion
    {
        //variable para conectar a la base datos
        private String ConexionBaseDeDatos;
        //metodo para conectarse a la base de datos
        public String CadenaDeConexion()
        {
            //variable en donde se guardara la direccion de la base de datos
            ConexionBaseDeDatos = "Data Source=DESKTOP-HAED82E;Initial Catalog=Resta;Integrated Security=True";
            return ConexionBaseDeDatos;
        }
        //variable para conectarse al servidor de sql server
        private SqlConnection ConectarBase;

        //constructor para crear un objeto sql conection
        public   Conexion()
        {
            ConectarBase = new SqlConnection(CadenaDeConexion());
        }

        //metodo para abrri la base de datos 
        public SqlConnection OpenDataBase()
        {
            //se agrega la bariable que conecta con la base de datos
            //seguido de un punto y la palabra open
            ConectarBase.Open();
            //este if sirve para cerrar la base de datos en caso que no tenga
            //contenido
            if(ConectarBase==null)
            {
                ConectarBase.Close();
            }
            return ConectarBase;
        }

        public void CerrarBaseDatos()
        {
            //este try catch sirbe para cerrar la base de datos 
            try
            {
                ConectarBase.Close();
            }
            catch(Exception ex)
            {
                string mje = ex.Message;
            }
        }
    }
}
