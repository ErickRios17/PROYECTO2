using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MenuChef.Model;
using MenuChef.Controlar;

namespace MenuChef
{
    public partial class TipoOrden : Form
    {
        public TipoOrden()
        {
            InitializeComponent();
        }
        private void tipoOrden_Load(object sender, EventArgs e)
        {
            //crea un objeto con la clase seleccionada
            ControlarMesas _mesa = new ControlarMesas();
            //utiliza los metodos de mesay y sus variables 
            cbMesa.DataSource = _mesa.MesaDisponible();
            cbMesa.DisplayMember = "NumeroMesa";
            cbMesa.ValueMember = "Id";


        }
        private void BtlOpcion1_Click(object sender, EventArgs e)
        {
            //avilita los paneles si se selecciona
            panel1.Enabled = true;
            panel2.Enabled = false;
        }

        private void BtnOpcion2_Click(object sender, EventArgs e)
        {
            //avilita los paneles si se selecciona
            panel2.Enabled = true;
            panel1.Enabled = false;
        }

        private void BtnListo_Click(object sender, EventArgs e)
        {
            //crea un objeto con la clase seleccionada
            Mesa mesa = new Mesa();
            ControlOrder controlOrder = new ControlOrder();
            //utiliza los metodos para seleccionar la mesa que este 
            //desocupada
            mesa.Id = int.Parse(cbMesa.SelectedValue.ToString());
            //desavilita los paneles y botones
            panel1.Enabled = false;
            panel2.Enabled = false;
            btnOpcion2.Enabled = false;
            btlOpcion1.Enabled = false;
            //manda mensaje que se registro la orden
            MessageBox.Show("Se ha registrado la orden");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //crea un obejto con la clase seleccionada
            Mesa mesa = new Mesa();
            ControlOrder controlOrder = new ControlOrder();
            //utiliza los metodos para seleccionar la mesa que este 
            //desocupada
            mesa.Id = int.Parse(cbMesa.SelectedValue.ToString());
            //inavilita los paneles y botones
            panel1.Enabled = false;
            panel2.Enabled = false;
            btnOpcion2.Enabled = false;
            btlOpcion1.Enabled = false;
            //manda mensaje que se registro la orden
            MessageBox.Show("Se ha registrado la orden");
        }
        private void CbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Cbresponsable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CbMesa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }



        private void TipoOrden_Load_1(object sender, EventArgs e)
        {
            //crea un objeto con la clase seleccionada
            ControlarMesas _mesa = new ControlarMesas();
            //usa los metodos del objeto creado y le da los valores a las 
            //variables
            cbMesa.DataSource = _mesa.MesaDisponible();
            cbMesa.DisplayMember = "NumeroMesa";
            cbMesa.ValueMember = "Id";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //cierra la ventana actual y te manda al inicio
            new Inicio().Show();
            this.Hide();
        }
    }
}
