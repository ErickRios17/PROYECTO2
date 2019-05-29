using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuChef.Model
{
    //las clases modelos sirven para guardar las variables y los datos
    //que se van a utilizar en el controlador del programa
    class Productos
    {
        private int id;
        private string nombreProducto;
        private string descripcion;
        private int precio;
        private int idCatProduct;
        private bool respuesta = false;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public string NombreProducto
        {
            get { return nombreProducto; }
            set { nombreProducto = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public int IdCatProduct
        {
            get { return idCatProduct; }
            set { idCatProduct = value; }
        }


        public bool Respuesta
        {
            get { return respuesta; }
            set { respuesta = value; }
        }



    }
}
