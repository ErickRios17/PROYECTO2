using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuChef.Controlar;
using MenuChef.Model;
using System.Windows.Forms;

namespace MenuChef
{
    public partial class Producto : Form
    {
        public Producto()
        {
            InitializeComponent();
        }


        
        private void agregarProducto_Load(object sender, EventArgs e)
        {
            //crea un objeto con la clase seleccionada
            ControlCatProductos _catPro = new ControlCatProductos();
            //captura los productos deceados
            //guardandolos en la base de datos con loe metodos de la
            //clase que se llama
            cbCat.DataSource = _catPro.seleccionarCatProducto();
            cbCat.DisplayMember = "Categoria";
            cbCat.ValueMember = "Id";

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            //crea un objeto con la calse seleccionada
            Productos _producto = new Productos();
            CatProducto cPr = new CatProducto();
            ControlProducto cProdu = new ControlProducto();
            //le da los valores a cada variable seleccionada 
            _producto.NombreProducto = txtNombre.Text;
            _producto.Precio = int.Parse(txtPrecio.Text);
            cPr.Id = int.Parse(cbCat.SelectedValue.ToString());
            _producto.Respuesta = cProdu.altaProducto(_producto, cPr);
            //si se guardo el platillo saldra el mensaje
            if (_producto.Respuesta == true)
            {
                MessageBox.Show("Se ha agregado el platillo");


            }
            //si no se guarda el platillo mostrara el mensaje
            else
            {
                MessageBox.Show("Error al insertar");
            }

            //borra lo escrito en esos texbox
            txtNombre.Text = "";
            txtPrecio.Text = "";

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //te envia al inicio y cierra la ventana actual
            new Inicio().Show();
            this.Hide();
        }

        private void Producto_Load(object sender, EventArgs e)
        {
            //crea un objeto con la clase seleccionada
            ControlProducto _Pro = new ControlProducto();
            //llama a los metodos de la clase y hace los procedimientos
            cbProducto.DataSource = _Pro.seleccionarProductoComb();
            cbProducto.DisplayMember = "NombreProducto";
            cbProducto.ValueMember = "Id";


            //crea un objeto con la clase deceada
            ControlCatProductos _catPro = new ControlCatProductos();
            //usa los metodos de la clase y evalua
            cbCat.DataSource = _catPro.seleccionarCatProducto();
            cbCat.DisplayMember = "Categoria";
            cbCat.ValueMember = "Id";

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //muestra el mensaje de que el producto se elimino
            MessageBox.Show("Producto Eliminado");
            //crea un objeto con la clase seleccionada
            Productos objCF = new Productos();
            ControlProducto _cf = new ControlProducto();
            //utiliza los metodos de las clases para eliminar los productos 
            //seleccionados
            objCF.Id = int.Parse(cbProducto.SelectedValue.ToString());
            _cf.eliminarProducto(objCF);

        }

        private void CbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
 
        }

        private void CbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
 
        }
    }
}
