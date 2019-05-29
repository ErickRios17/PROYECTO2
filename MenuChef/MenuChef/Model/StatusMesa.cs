using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuChef.Model
{
    //las clases modelos sirven para guardar las variables y los datos
    //que se van a utilizar en el controlador del programa
    class StatusMesa
    {
        private int id;

        private string descripcion;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

    }
}
