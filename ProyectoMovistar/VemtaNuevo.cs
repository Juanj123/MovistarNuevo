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

            VentaList.Focus();
            VentaList.FullRowSelect = true;
        }
       
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
        }

        int to;
        double total;
        int i = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            
            clsDatosInventario inventarioo = new clsDatosInventario();
            string varProducto = txtBuscarProducto.Text;
            int varPrecio = v.getPrecio(txtBuscarProducto.Text);
            int varCantidad = Convert.ToInt32(numericUpDown1.Value);
            total = Convert.ToDouble(varPrecio * varCantidad);
            string[] elementosFila = new string[5];
            ListViewItem elementoListView;

            if (VentaList.Items.Count == 0)
            {
                elementosFila[0] = varProducto;
                elementosFila[1] = Convert.ToString(varCantidad);
                elementosFila[2] = Convert.ToString(varPrecio);
                elementosFila[3] = Convert.ToString(total);
                elementoListView = new ListViewItem(elementosFila);
                VentaList.Items.Add(elementoListView);
                to = to + Convert.ToInt32(total);
                txtTotal.Text = Convert.ToString(to);

                txtBuscarProducto.Text = "";
            }
            else {

                ListViewItem item1 = VentaList.FindItemWithText(varProducto);
                if (item1 != null)
                {
                    
                    int h = Convert.ToInt32(VentaList.Items[item1.Index].SubItems[1].Text) + varCantidad;
                    VentaList.Items[item1.Index].SubItems[1].Text = Convert.ToString(h);
                    VentaList.Items[item1.Index].SubItems[3].Text = Convert.ToString(h* Convert.ToInt32(VentaList.Items[item1.Index].SubItems[2].Text));
                    to = to + Convert.ToInt32(total);
                    txtTotal.Text = Convert.ToString(to);

                    txtBuscarProducto.Text = "";
                    i++;
                }
                else
                {
                    elementosFila[0] = varProducto;
                    elementosFila[1] = Convert.ToString(varCantidad);
                    elementosFila[2] = Convert.ToString(varPrecio);
                    elementosFila[3] = Convert.ToString(total);
                    elementoListView = new ListViewItem(elementosFila);
                    VentaList.Items.Add(elementoListView);
                    to = to + Convert.ToInt32(total);
                    txtTotal.Text = Convert.ToString(to);

                    txtBuscarProducto.Text = "";
                    i++;

                }
              }
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
                
                clsDatosInventario inventarioo = new clsDatosInventario();
                clsDatosVenta objDao = new clsDatosVenta();
                clsVenta objSolicitud = new clsVenta();
                clsDVenta objDVenta = new clsDVenta();
                objSolicitud.Folio = Convert.ToInt32(lblFolio.Text);
                objSolicitud.IdUusario = inventarioo.getIdEmpleado("Ramon Perez");
                objSolicitud.Fecha = dtpFecha.Text;
                objSolicitud.Recibo = Convert.ToInt32(txtRecibi.Text);
                objSolicitud.Cambio = Convert.ToDouble(txtCambio.Text);
                objDao.AgregarProducto(objSolicitud);
               
                for (int i = 0; i < VentaList.Items.Count; i++)
                {
                    objDVenta.Folio = Convert.ToInt32(lblFolio.Text);
                    objDVenta.Nombre = VentaList.Items[i].SubItems[0].Text;
                    objDVenta.Precio=Convert.ToInt32( VentaList.Items[i].SubItems[2].Text);
                    objDVenta.Cantidad= Convert.ToInt32(VentaList.Items[i].SubItems[1].Text);
                    objDVenta.Total= Convert.ToInt32(VentaList.Items[i].SubItems[3].Text);
                    objDao.AgregarDVenta(objDVenta);
                }
                MessageBox.Show("Venta Realizada con Exito", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VentaList.Clear();
                txtRecibi.Text = "";
                txtTotal.Text = "";
                txtCambio.Text = "";
                lblFolio.Text = v.folio().ToString();
            }
        }


            private void button4_Click(object sender, EventArgs e)
            {

            int valor = Convert.ToInt32(VentaList.SelectedItems[0].SubItems[3].Text);

            //MessageBox.Show((Convert.ToString(valor)));
            foreach (ListViewItem lista in VentaList.SelectedItems)
            {

                to = to - valor;
                txtTotal.Text = Convert.ToString(to);
                VentaList.Items.Remove(lista);


            }



        }

            private void button1_Click(object sender, EventArgs e)
            {
                VentaList.Clear();
                txtTotal.Text = "";
            }

        private void VentaList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
    }
