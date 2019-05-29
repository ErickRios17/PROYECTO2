using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuChef
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //cierra la venta actual y te redirige a la que elija
            new Mesas().Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new Ordenar().Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            new Producto().Show();
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
