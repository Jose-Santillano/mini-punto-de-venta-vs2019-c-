using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Punto_Venta
{
    public partial class frmRegistroUsuarios : Form
    {
        //Declaramos variables básicas.
        public string usuario, password;

        List<string> usuarios = new List<string>();
        List<string> passwords = new List<string>();

        public frmRegistroUsuarios()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Verificamos si los campos estan vacios.
            if (txtUsuario.Text == "" && txtPassword.Text == "")
            {
                //Como esta vacio mostramos mensaje de error.
                MessageBox.Show("Verifica que ambos campos esten llenos.", "Rellena los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                usuario = txtUsuario.Text;
                usuarios.Add(usuario);
                password = txtPassword.Text;
                passwords.Add(password);

                if (MessageBox.Show("¿Desea registrar otro usuario?", "Usuario registrado", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Information) == DialogResult.No)
                {
                    frmLogin login = new frmLogin(usuarios, passwords);
                    this.Hide();
                    login.Show();
                }

                //Limpiamos los campos.
                txtPassword.Clear();
                txtUsuario.Clear();
            }   
        }

        private void frmRegistroUsuarios_Load(object sender, EventArgs e)
        {
            //Evento de carga del formulario "Login"
        }
    }
}
