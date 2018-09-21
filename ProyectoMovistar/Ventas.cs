using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaPojos;
using System.Windows.Forms;

namespace ProyectoMovistar
{
    public partial class Ventas : Form
    {
        int cant;
        int total = 0;
        int sub = 0;
        int cambio = 0;
        int recibo = 0;
        int folio = 2;
        int rowEscribir;
        clsValidaciones objValidaciones = new clsValidaciones();
        List<String> productos = new List<string>();
        public Ventas()
        {
            InitializeComponent();
        }

        private void Ventas_Load_1(object sender, EventArgs e)
        {
            clsDatosVenta o = new clsDatosVenta();
            var lista = o.getProducto();
            cmbProductos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbProductos.AutoCompleteMode = AutoCompleteMode.Suggest;
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            for (int i = 0; i < o.getProducto()[0].Nombre.Length; i++)
            {
                cmbProductos.Items.Insert(i, o.getProducto()[i].Nombre);
                datos.Add((o.getProducto())[i].Nombre);
            }
            cmbProductos.AutoCompleteCustomSource = datos;
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                if (c.Name != "Cantidad") c.ReadOnly = true;
            }

        }

        private void cmbProductos_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (e.KeyData == Keys.Enter)
                {
                    clsDatosVenta ob = new clsDatosVenta();
                    List<clsInventario> pro;
                    pro = ob.getProductos(cmbProductos.Text);
                    dataGridView1.Rows.Add(pro[0].Nombre,
                    pro[0].Precio,
                    "1",
                    pro[0].Descripcion);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = ((dataGridView1.Rows.Count) - 1);
            for(int iter = 0; iter < i; iter++)
            {
                dataGridView2.Rows.Add(dataGridView1.Rows[iter].Cells[0].Value.ToString(),
                    dataGridView1.Rows[iter].Cells[1].Value.ToString(),
                    dataGridView1.Rows[iter].Cells[2].Value.ToString(),
                    dataGridView1.Rows[iter].Cells[3].Value.ToString());
            }
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            int iterData = ((dataGridView2.Rows.Count) - 1);
            total = 0;
            for (int itera = 0; itera<iterData; itera++)
            {
                
                total = Int32.Parse(dataGridView2.Rows[itera].Cells[1].Value.ToString()) + total;
                cant = Int32.Parse(dataGridView2.Rows[itera].Cells[2].Value.ToString());
                if (cant > 1)
                {
                    total = total * cant;
                }
                sub = total;
                lblSubtotal.Text = sub.ToString();
                lbltotal.Text = total.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Llene primero el campo de Recibo", "Datos ingresados incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Llenado de los campos del formulario para guardarlos en la Base de Datos
                try
                {
                    clsDatosVenta objDao = new clsDatosVenta();
                clsVenta objSolicitud = new clsVenta();
                clsDVenta objDVenta = new clsDVenta();
                objSolicitud.Folio = folio;
                objSolicitud.IdUsuario = 1;
                objSolicitud.Subtotal = double.Parse(lblSubtotal.Text);
                objSolicitud.Total = double.Parse(lbltotal.Text);
                objSolicitud.Recibo = double.Parse(textBox1.Text);
                objSolicitud.Cambio = double.Parse(lblCambio.Text);
                objSolicitud.Fecha = dateTimePicker1.Text;
                int row = ((dataGridView2.Rows.Count) - 1);
                for (int iter = 0; iter < row; iter++)
                {
                    dataGridView2.Rows.Add(1);
                    objDVenta.Folio = folio;
                    objDVenta.Nombre = dataGridView2.Rows[iter].Cells[0].Value.ToString();
                    objDVenta.Precio = double.Parse(dataGridView2.Rows[iter].Cells[1].Value.ToString());
                    objDVenta.Cantidad = Int32.Parse(dataGridView2.Rows[iter].Cells[2].Value.ToString());
                    objDao.AgregarDVenta(objDVenta);
                }
                // Se insertan los datos de venta
                objDao.AgregarProducto(objSolicitud);

                // Muestra mensaje de satisfaccion
                MessageBox.Show("Solicitud Registrada", "Insertar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.DataSource = null;
                    dataGridView2.Rows.Clear();
                    dataGridView2.Refresh();
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    lblCambio.Text = "0";
                    lblSubtotal.Text = "0";
                    lbltotal.Text = "0";
                }
                catch (Exception ex)
            {
                // Muestra mensaje en caso de que haya errores
                MessageBox.Show("Error al llenar los campos, verifique sus datos", "Datos ingresados incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidaciones.Numeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                recibo = Int32.Parse(textBox1.Text);
                if (recibo == total)
                {
                    cambio = 0;
                }
                else if (recibo > total)
                {
                    cambio = recibo - total;
                }
                else if (recibo < total)
                {
                    cambio = total - recibo;
                    lblCambio.BackColor = Color.Red;

                }
                lblCambio.Text = cambio.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 1)
            {
                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
                dataGridView2.Refresh();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                lblCambio.Text = "0";
                lblSubtotal.Text = "0";
                lbltotal.Text = "0";
            }
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            lblCambio.Text = "0";
            lblSubtotal.Text = "0";
            lbltotal.Text = "0";
        }
    }
}

