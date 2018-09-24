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
            VentaList.Columns.Add("Producto", 250, HorizontalAlignment.Left);
            VentaList.Columns.Add("Cantidad", 160, HorizontalAlignment.Right);
            VentaList.Columns.Add("Precio", 170, HorizontalAlignment.Right);
            VentaList.Columns.Add("Total", 170, HorizontalAlignment.Right);
        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                MessageBox.Show("hola");
                
        }
        int to;
        private void button3_Click(object sender, EventArgs e)
        {
            //cont = 0;
            string varProducto = txtBuscarProducto.Text;
            int varPrecio = v.getPrecio(txtBuscarProducto.Text);
            int varCantidad = Convert.ToInt32(numericUpDown1.Value);
            double total = Convert.ToDouble(varPrecio * varCantidad);

            //Añadimos los elementos (filas) al ListView
            string[] elementosFila = new string[5];
            ListViewItem elementoListView;

            //Añadimos una primera fila al ListView
            elementosFila[0] = varProducto;
            elementosFila[1] = Convert.ToString(varPrecio);
            elementosFila[2] = Convert.ToString(varCantidad);
            elementosFila[3] = Convert.ToString(total);
            elementoListView = new ListViewItem(elementosFila);
            VentaList.Items.Add(elementoListView);

            to = to + Convert.ToInt32(total);
            txtTotal.Text = Convert.ToString(to);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) {
                if (to > Convert.ToInt32(txtRecibi.Text))
                {
                    MessageBox.Show("No seas codo Bro, ese billetito no alcanza para pagar");
                }
                else {
                    txtCambio.Text =Convert.ToString(Convert.ToInt32(txtRecibi.Text ) - to);
                }
            }
                
        }
    }
    }
