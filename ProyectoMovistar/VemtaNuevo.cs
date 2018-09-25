using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaDatos;
using capaPojos;

namespace ProyectoMovistar
{
    public partial class VemtaNuevo : Form
    {
        public VemtaNuevo()
        {
            InitializeComponent();
        }
        clsDatosVenta v = new clsDatosVenta();
        private void VemtaNuevo_Load(object sender, EventArgs e)
        {
            generaColumnas();

            txtBuscarProducto.AutoCompleteCustomSource = cargarDatos();
            txtBuscarProducto.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuscarProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;

            lblFolio.Text = v.folio().ToString();
        }
        List<String> productos = new List<string>();
        private AutoCompleteStringCollection cargarDatos()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();

            var j = v.getProducto();

            for (int i = 0; i < j.Count; i++)
            {
                datos.Add(j[i].Nombre);
            }
            return datos;
        }

        public void generaColumnas()
        {
            VentaList.Clear();
            VentaList.View = View.Details;
            VentaList.Columns.Add("Producto", 230, HorizontalAlignment.Left);
            VentaList.Columns.Add("Cantidad", 160, HorizontalAlignment.Right);
            VentaList.Columns.Add("Precio", 170, HorizontalAlignment.Right);
            VentaList.Columns.Add("Total", 170, HorizontalAlignment.Right);
        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                MessageBox.Show("hola");

        }

        int cont = 0;
        int to;
        double total;
        List<clsVenta> listaVenta = new List<clsVenta>();
        private void button3_Click(object sender, EventArgs e)
        {
            //cont = 0;
            string varProducto = txtBuscarProducto.Text;
            int varPrecio = v.getPrecio(txtBuscarProducto.Text);
            int varCantidad = Convert.ToInt32(numericUpDown1.Value);
            total = Convert.ToDouble(varPrecio * varCantidad);

            //Añadimos los elementos (filas) al ListView
            string[] elementosFila = new string[5];
            ListViewItem elementoListView;

            //Añadimos una primera fila al ListView
            elementosFila[0] = varProducto;
            elementosFila[1] = Convert.ToString(varCantidad);
            elementosFila[2] = Convert.ToString(varPrecio);
            elementosFila[3] = Convert.ToString(total);
            elementoListView = new ListViewItem(elementosFila);
            VentaList.Items.Add(elementoListView);

            clsVenta ven = new clsVenta();
            ven.Folio = Convert.ToInt32(lblFolio.Text);
            ven.Nombre = varProducto;
            ven.Precio = varPrecio;
            ven.Cantidad = varCantidad;
            ven.Total = total;
            listaVenta.Add(ven);

            to = to + Convert.ToInt32(total);
            txtTotal.Text = Convert.ToString(to);

            txtBuscarProducto.Text = "";
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) {
                if (to > Convert.ToInt32(txtRecibi.Text))
                {
                    MessageBox.Show("No seas codo Bro, ese billetito no alcanza para pagar");
                }
                else {
                    txtCambio.Text = Convert.ToString(Convert.ToInt32(txtRecibi.Text) - to);
                    foreach (clsVenta item in listaVenta)
                    {
                        MessageBox.Show(Convert.ToString(item.Folio));
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtRecibi.Text == "")
            {
                MessageBox.Show("Llene primero el campo de Recibo", "Datos ingresados incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Llenado de los campos del formulario para guardarlos en la Base de Datos
                //try
                //{
                clsDatosVenta objDao = new clsDatosVenta();
                clsVenta objSolicitud = new clsVenta();
                clsDVenta objDVenta = new clsDVenta();
                objDVenta.Folio =Convert.ToInt32(lblFolio.Text);
                objDVenta.IdUusario = 1;
                objDVenta.Fecha = dtpFecha.Text;
                objDVenta.Recibo = Convert.ToInt32(txtRecibi.Text);
                objDVenta.Cambio = Convert.ToDouble(txtCambio.Text);

                foreach (clsVenta item in listaVenta)
                {
                    objSolicitud.Folio = item.Folio;
                    objSolicitud.Nombre = item.Nombre;
                    objSolicitud.Precio = item.Precio;
                    objSolicitud.Cantidad = item.Cantidad;
                    objSolicitud.Total = item.Total;
                    objDao.AgregarProducto(objSolicitud);
                }
                
                objDao.AgregarDVenta(objDVenta);
              
                

                // Muestra mensaje de satisfaccion
                MessageBox.Show("Venta Realizada con Exito", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

            private void button4_Click(object sender, EventArgs e)
            {

                foreach (ListViewItem lista in VentaList.SelectedItems) {
                    to = to - Convert.ToInt32(total);
                    txtTotal.Text = Convert.ToString(to);
                    VentaList.Items.Remove(lista);



                }

            }

            private void button1_Click(object sender, EventArgs e)
            {
                VentaList.Clear();
                txtTotal.Text = "";
                cont = 0;

            }


           
        }
    }
