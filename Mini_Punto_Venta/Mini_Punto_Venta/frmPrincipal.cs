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
    public partial class frmPrincipal : Form
    {
        //Declaramos variables globales.
        public string id, producto, datosCompra;
        public double valor, total;

        //Declaramos las listas.
        List<string> usuarios = new List<string>();

        public frmPrincipal(List<string> getUsuarios)
        {
            InitializeComponent();

            //Obtenemos datos por parametros.
            usuarios = getUsuarios;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //Evento carga del formulario.

            foreach (var usuario in usuarios)
            {
                //Llevamos el dataGridView de los usuarios que tengamos.
                dgvUsuarios.Rows.Add(usuario.ToString());
            }
        }

        //Boton para cancelar la compra.
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Evento click del btnCancelar.

            //Si se cancela limpiamos el DataGridView. (Limpiamos los productos)
            dgvVistaProductos.Rows.Clear();
            txtAuxiliar.Clear();
        }

        //Boton para generar la compra.
        private void btnComprar_Click(object sender, EventArgs e)
        {
            //Evento click del btnCancelar.

            //Guardamos informacion temporal del txtAuxiliar (este nos ayuda a almacenar la informacion para el ticket)
            datosCompra = txtAuxiliar.Text;

            //Verificamos que el txtAuxiliar no este vacio. (Si lo esta es que no hay ningun producto que comprar)
            if (txtAuxiliar.Text != "")
            {
                //Mostramos mensaje de exito.
                MessageBox.Show("Compra realizada exisotamente, procesando ticket...", "Compra exitosa", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                //Generamos el ticket y limpiamos.
                frmTicket ticket = new frmTicket(datosCompra, total);
                ticket.Show();

                //Limpiamos los campos.
                txtId.Clear();
                txtProducto.Clear();
                txtValor.Clear();
                txtAuxiliar.Clear();
                dgvVistaProductos.Rows.Clear();

                //Reiniciamos el total.
                total = 0;
            }
            else
            {
                //Mostramos mensaje de error.
                MessageBox.Show("Porfavor introduzca productos a la lista...", "Productos no elegidos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //Boton para agregar los productos.
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Evento click del btnAgregar.

            //Validamos que los campos no esten vacios.
            if (txtId.Text != "" && txtProducto.Text != "" && txtValor.Text != "")
            {
                //Obtenemos los datos de los textBox y los almacenamos.
                id = txtId.Text;
                producto = txtProducto.Text;
                valor = Convert.ToDouble(txtValor.Text);
                total += valor;

                //Agregamos los datos obtenidos a el DataGridView (Productos)
                dgvVistaProductos.Rows.Add(id, producto, valor.ToString());

                //Guardamos en el txtAuxiliar para generar el ticket.
                txtAuxiliar.Text += producto + " \t\t$" + valor.ToString() + Environment.NewLine;
            }
            else
            {
                //Mostramos mensaje de error.
                MessageBox.Show("Favor de rellenar todos los campos.", "Rellene campos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            //Limpiamos los campos.
            txtId.Clear();
            txtProducto.Clear();
            txtValor.Clear();
        }
    }
}
