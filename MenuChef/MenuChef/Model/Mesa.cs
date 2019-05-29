using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuChef.Model
{
    //las clases modelos sirven para guardar las variables y los datos
    //que se van a utilizar en el controlador del programa
    class Mesa
    {
        private int id;
        private int numeroMesa;
        private int idStatus;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int NumeroMesa
        {
            get { return numeroMesa; }
            set { numeroMesa = value; }
        }
        public int Idstatus
        {
            get { return idStatus; }
            set { idStatus = value; }
        }
    }
}
