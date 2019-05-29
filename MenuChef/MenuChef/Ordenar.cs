using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MenuChef.Model;
using MenuChef.Controlar;


namespace MenuChef
{
    public partial class Ordenar : Form
    {
        //es un constructor
        public Ordenar()
        {
            //metodo que define en el Designer.cs 
            //los controles que has definido en el diseñador del formulario
            InitializeComponent();
        }

        private void DgwOrden_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgwMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dara el numero de filas que tendra la tabla que se mostrara
            string fila1 = Convert.ToString(dgwMenu.CurrentRow.Cells[0].Value);
            string fila2 = Convert.ToString(dgwMenu.CurrentRow.Cells[1].Value);
            string fila3 = Convert.ToString(dgwMenu.CurrentRow.Cells[2].Value);

            string[] row = new string[] { fila1, fila2, fila3 };
            dgwOrden.Rows.Add(row);

            int sumatoria = 0;
            //seleciona la celda que tiene el precio y lo suma para motrarlo
            foreach (DataGridViewRow rows in dgwOrden.Rows)
            {
                sumatoria += Convert.ToInt32(rows.Cells[1].Value);


            }

            txtTotalOrden.Text = Convert.ToString(sumatoria);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ControlOrder _venta = new ControlOrder();

            _venta.altaOrden(int.Parse(txtTotalOrden.Text));
            //da de alta la orden 
            foreach (DataGridViewRow rowss in dgwOrden.Rows)
            {

                string c = Convert.ToString(rowss.Cells[0].Value);
                if (c != "")
                {
                    _venta.altaDetelleOrden(c);
                }
            }
            //cierra la ventana actual y abre tipo de orden
            new TipoOrden().Show();

            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //cierra la ventana y te lleva a l inicio
            new Inicio().Show();
            this.Hide();
        }

        private void CbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            //usa el metodo llenargrig
            llenarGrig();
        }


        public void llenarGrig()
        {
            //crea objetos que llaman a ciertas clases
            ControlProducto _Cproducto = new ControlProducto();
            CatProducto _categoriaproducto = new CatProducto();
            //muestra las categorias de los productos con utilizando las variables establecidas
            if (cbCategoria.SelectedValue.ToString() != "MenuChef.Model.CatProducto")
            {
                _categoriaproducto.Id = int.Parse(cbCategoria.SelectedValue.ToString());

                dgwMenu.DataSource = _Cproducto.SelectProductoByCattegoria(_categoriaproducto).Tables[0];
                dgwMenu.Visible = true;
            }
        }

        private void Ordenar_Load(object sender, EventArgs e)
        {
            //utiliza el metodo llamado
            CargarGrigOrden();
            //crea un objeto con la clase elejida
            ControlCatProductos _catPro = new ControlCatProductos();
            //seleciona la categoria del producto y utiliza los metodos
            //de las clases llamadas para entrar a la base de datos
            cbCategoria.DataSource = _catPro.seleccionarCatProducto();
            cbCategoria.DisplayMember = "Categoria";
            cbCategoria.ValueMember = "Id";
        }
        //se utiliza para que muestre lo escrito 
        public void CargarGrigOrden()
        {
            dgwOrden.ColumnCount = 4;
            dgwOrden.Columns[0].Name = "Nombre";
            dgwOrden.Columns[1].Name = "$Precio";
            dgwOrden.Columns[2].Name = "Categoria Producto";
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
