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
    public partial class frmLogin : Form
    {
        //Declaramos el usuario root (Superusuario)
        public string usuarioRoot, passwordRoot;

        //Declaramos variables básicas.
        public string usuario, password;

        //Declaramos banderas.
        public bool flagUser = false;
        public bool flagPass = false;

        //Declaramos las listas.
        List<string> usuarios = new List<string>();
        List<string> passwords = new List<string>();

        public frmLogin(List<string> getUsuarios, List<string> getPasswords)
        {
            InitializeComponent();

            //Obtenemos los usuarios y contraseñas por parametros.
            usuarios = getUsuarios;
            passwords = getPasswords;
        }


        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            //Evento click del btnIniciarSesion.

            //Verificamos si los campos estan vacios.
            if (txtUsuario.Text == "" && txtPassword.Text == "")
            {
                //Como esta vacio mostramos mensaje de error.
                MessageBox.Show("Verifica que ambos campos esten llenos.", "Rellena los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Como no esta vacio ejecutamos el login

                //Verificamos si es un SuperUsuario.
                if (txtUsuario.Text == "root" && txtPassword.Text == "root")
                {
                    MessageBox.Show("Sesión iniciada como ROOT", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Redirigimos al usuario a la aplicación principal.
                    frmPrincipal principal = new frmPrincipal(usuarios);
                    this.Hide();
                    principal.Show();
                }
                else
                {
                    usuario = txtUsuario.Text;
                    password = txtPassword.Text;

                    foreach (var user in usuarios)
                    {
                        if (usuario == user)
                        {
                            flagUser = true;
                        }   
                    }
                    foreach (var pass in passwords)
                    {
                        if (password == pass)
                        {
                            flagPass = true;
                        }
                    }

                    if (flagUser && flagPass)
                    {
                        MessageBox.Show("Sesión iniciada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        frmPrincipal principal = new frmPrincipal(usuarios);
                        this.Hide();
                        principal.Show();
                    }
                    else
                    {
                        MessageBox.Show("Verifica tus credenciales por favor.", "Información", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //Evento de carga del formulario "Login"

            //Asignamos las credenciales del usuario root.
            usuarioRoot = "root";
            passwordRoot = "root";
        }
    }
}
