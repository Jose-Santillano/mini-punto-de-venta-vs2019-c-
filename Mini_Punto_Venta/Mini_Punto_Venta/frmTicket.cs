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
    public partial class frmTicket : Form
    {
        //Declaramos las variables globales.
        public string datosCompra;
        public double total;

        public frmTicket(string datos, double valor)
        {
            InitializeComponent();

            //Recibimos los datos por parametros para generar el ticket.
            datosCompra = datos;
            total = valor;
        }

        private void frmTicket_Load(object sender, EventArgs e)
        {
            //Evento carga del formulario.

            txtCarrito.Text = datosCompra;
            lblFechaHora.Text = DateTime.Now.ToString(); ;
            lblTotalPagar.Text = total.ToString();
        }
    }
}
