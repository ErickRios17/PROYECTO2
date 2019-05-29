using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MenuChef
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        string contrasena;
        private void Button1_Click(object sender, EventArgs e)
        {
            //variables para guardar los caracteres utilizados en las boxtext
            string user=boxUser.Text;
            string password=Boxpassword.Text;
            //direccion donde se buscara el documento para  
            //comparar los datos en los textbox
            string direccion = "C:\\Users\\kakit\\Documents\\Usuarios" + user + ".txt";
            //aqui verifica si el documento existe
            if (File.Exists(direccion))
            {
                //la variable 
                contrasena=File.ReadAllText(direccion);
                //si lo escrito en el texboxt es el mismo que lo que esta
                //en el documento entonces axede
                if(password.Equals(contrasena))
                {
                    MessageBox.Show("Acceso correcto");

                    SqlCommand Comando = new SqlCommand();
                  //cierra la ventana y abre una nueva
                    new Inicio().Show();
                    this.Hide();
                }

            }
            else
            {
                //si uno de los textbox es diferente muestra este mensaje
                MessageBox.Show("La contraseña o usuario no son correctos");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string user = BoxUser2.Text;
            string password = BoxPass2.Text;
            //direccion donde se guardara el documento y creara
            string direccion= "C:\\Users\\kakit\\Documents\\Usuarios" + user + ".txt";
            //comparara los caracteres escritos en los texbox de usuario
            //si este ya esta registrado mandara el mensaje
            if (File.Exists(direccion))
            {
                MessageBox.Show("Este usuario ya esta registrado");
            }
            //si aun no esta registrado lo guardara
            //y limpiara los texbox
            else
            {
                File.WriteAllText(direccion, password);
                MessageBox.Show("Registro Exitoso");
                boxUser.Text = "";
                Boxpassword.Text = "";
            }
        }
    }
}
