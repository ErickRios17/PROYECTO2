using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MenuChef.Controlar;
using MenuChef.Model;
using MenuChef.Properties;

namespace MenuChef
{
    public partial class Mesas : Form
    {
        public Mesas()
        {
            InitializeComponent();
        }


        int libres = 0;
        int ocupadas = 0;

        public void ComboDisponible()
        {
            //objeto para llamar a la clase controlarmesas
            ControlarMesas _mesa = new ControlarMesas();

            //muestra las mesas ocupadas con el metodo llamado
            cbLiberarMesas.DataSource = _mesa.SelectMesasOcupadas();
            //muestra las mesas con los valores de las variables
            cbLiberarMesas.DisplayMember = "NumeroMesa";
            cbLiberarMesas.ValueMember = "Id";
        }
        private void mesas_Load(object sender, EventArgs e)
        {
            //establece el color en que se pintaran
            btncolor1.BackColor = Color.Lime;
            btncolor2.BackColor = Color.Red;
            //sera el numero total de mesas
            txtTotalMesas.Text = "12";

            //llama al metodo pintar mesas
            PintarMesas();
            txtlibres.Text = libres + "";
            txtOcupadas.Text = ocupadas + "";

        }
        public void PintarMesas()
        {
            //contador de las mesas 
            string[] arraymesas = new string[12];
            //objeto para llamar a la clase controlmesas
            ControlarMesas mesa = new ControlarMesas();
            //variable que toma el metodo statusmesa
            arraymesas = mesa.StatusMesa();


            //mesas y sus acciones a tomar



            //mesa 1
            if (arraymesas[0] == "Libre")
            {
                m1.BackColor = Color.Lime;
                libres++;

            }
            if (arraymesas[0] == "Ocupada")
            {
                m1.BackColor = Color.Red;
                ocupadas++;
            }

            //mesa 2
            if (arraymesas[1] == "Libre")
            {
                m2.BackColor = Color.Lime;
                libres++;
            }
            if (arraymesas[1] == "Ocupada")
            {
                m2.BackColor = Color.Red;
                ocupadas++;
            }


            //mesa 3
            if (arraymesas[2] == "Libre")
            {
                m3.BackColor = Color.Lime;
                libres++;
            }
            if (arraymesas[2] == "Ocupada")
            {
                m3.BackColor = Color.Red;
                ocupadas++;
            }

            //mesa 4
            if (arraymesas[3] == "Libre")
            {
                m4.BackColor = Color.Lime;
                libres++;
            }
            if (arraymesas[3] == "Ocupada")
            {
                m4.BackColor = Color.Red;
                ocupadas++;
            }

            //mesa 5
            if (arraymesas[4] == "Libre")
            {
                m5.BackColor = Color.Lime;
                libres++;
            }
            if (arraymesas[4] == "Ocupada")
            {
                m5.BackColor = Color.Red;
                ocupadas++;
            }


            //mesa 6
            if (arraymesas[5] == "Libre")
            {
                m6.BackColor = Color.Lime;
                libres++;
            }
            if (arraymesas[5] == "Ocupada")
            {
                m6.BackColor = Color.Red;
                ocupadas++;
            }


            //mesa 7
            if (arraymesas[6] == "Libre")
            {
                m7.BackColor = Color.Lime;
                libres++;
            }
            if (arraymesas[6] == "Ocupada")
            {
                m7.BackColor = Color.Red;
                ocupadas++;
            }

            //mesa 8
            if (arraymesas[7] == "Libre")
            {
                m8.BackColor = Color.Lime;
                libres++;
            }
            if (arraymesas[7] == "Ocupada")
            {
                m8.BackColor = Color.Red;
                ocupadas++;
            }
            //mesa 9
            if (arraymesas[8] == "Libre")
            {
                m9.BackColor = Color.Lime;
                libres++;
            }
            if (arraymesas[8] == "Ocupada")
            {
                m9.BackColor = Color.Red;
                ocupadas++;
            }

            //mesa 10
            if (arraymesas[9] == "Libre")
            {
                m10.BackColor = Color.Lime;
                libres++;
            }
            if (arraymesas[9] == "Ocupada")
            {
                m10.BackColor = Color.Red;
                ocupadas++;

            }
            //mesa 11
            if (arraymesas[10] == "Libre")
            {
                m11.BackColor = Color.Lime;
                libres++;
            }
            if (arraymesas[10] == "Ocupada")
            {
                m11.BackColor = Color.Red;
                ocupadas++;
            }


            //  mesa 12
            if (arraymesas[11] == "Libre")
            {
                m12.BackColor = Color.Lime;
                libres++;
            }
            if (arraymesas[11] == "Ocupada")
            {
                m12.BackColor = Color.Red;
                ocupadas++;

            }
        }

        private void M1_Click(object sender, EventArgs e)
        {

        }

        private void M1_Click_1(object sender, EventArgs e)
        {

        }

        private void BtnLiberar_Click(object sender, EventArgs e)
        {

            libres = 0;
            ocupadas = 0;
            //crea un objeto para llamar a la clase mesa
            Mesa mesa = new Mesa();
            
            //crea un objeto para llamar a la clase controlarmesas
            ControlarMesas cm = new ControlarMesas();
            //
            mesa.Id = int.Parse(cbLiberarMesas.SelectedValue.ToString());
            cm.LiberarMesa(mesa);
            PintarMesas();
            ComboDisponible();
            txtlibres.Text = libres + "";
            txtOcupadas.Text = ocupadas + "";

        }

        private void PnlLiberar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CbLiberarMesas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //cierra la ventana actual y abre la selecionada 
            new Inicio().Show();
            this.Hide();
        }


       
        private void Mesas_Load_1(object sender, EventArgs e)
        {
            //color del boton que se muestra
            btncolor1.BackColor = Color.Lime;
            btncolor2.BackColor = Color.Red;
            txtTotalMesas.Text = "12";

            //metodo pintar mesas
            PintarMesas();
            txtlibres.Text = libres + "";
            txtOcupadas.Text = ocupadas + "";
          
        }
    }
}
