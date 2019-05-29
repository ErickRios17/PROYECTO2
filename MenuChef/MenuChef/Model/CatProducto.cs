using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuChef.Model
{
    //las clases modelos sirven para guardar las variables y los datos
    //que se van a utilizar en el controlador del programa
    class CatProducto
    {
        private int id;
        private string categoria;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
    }
}
