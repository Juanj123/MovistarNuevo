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
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
        }
        clsDatosInventario consulta = new clsDatosInventario();
        List<clsInventario> tabla = new List<clsInventario>();
        String Direccion;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "Archivos de Imagen|*.jpg";
            //Aquí incluiremos los filtros que queramos.
            BuscarImagen.FileName = "";
            BuscarImagen.Title = "Titulo del Dialogo";
            BuscarImagen.InitialDirectory = "C:\\Users\\Juanjo\\Documents\\Visual Studio 2015\\Projects\\Personal\\Imagenes";

            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                /// Si esto se cumple, capturamos la propiedad File Name y la guardamos en el control
                //this.textBox1.Text = BuscarImagen.FileName;
                Direccion = BuscarImagen.FileName;

                pbProducto.ImageLocation = Direccion;
                //Pueden usar tambien esta forma para cargar la Imagen solo activenla y comenten la linea donde se cargaba anteriormente 
                //this.pictureBox1.ImageLocation = textBox1.Text;
                pbProducto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsInventario objProducto = new clsInventario();
            clsDatosInventario objDatosInventario = new clsDatosInventario();
            //Se leen los datos de los txt
            objProducto.Clave = txtClave.Text;
            objProducto.Nombre = txtNombre.Text;
            objProducto.Precio = Convert.ToInt32(txtPrecio.Text);
            objProducto.Proovedor = txtProovedor.Text;
            objProducto.Existencia = Convert.ToInt32(txtExistencia.Text);
            objProducto.Descripcion = txtDescripcion.Text;
            objProducto.Idusuario = objDatosInventario.getIdEmpleado(lblEmpleado.Text);
            objProducto.RutaImg = Direccion;
            // INSERTA AL PRODUCTO MEDIANTE EL MÉTODO
            objDatosInventario.AgregarProducto(objProducto);
            // MUESTRA MENSAJE DE CONFIRMACION
            MessageBox.Show("Agregado", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            verProductos();
        }

        private void verProductos()
        {
            dataGridView1.Rows.Clear();
            tabla = consulta.getDatosProducto();
            foreach (clsInventario elemento in tabla)
            {
                dataGridView1.Rows.Add(elemento.Clave, elemento.Nombre, elemento.Precio, elemento.Existencia);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // CREA LOS OBJETOS
            clsInventario objProducto = new clsInventario();
            clsDatosInventario objDatosInventario = new clsDatosInventario();

            // LEE LOS DATOS DE LAS CAJAS Y LOS GUARDA EN EL OBJETO
            objProducto.Clave = txtClave.Text;
            objProducto.Nombre = txtNombre.Text;
            objProducto.Precio = Convert.ToInt32(txtPrecio.Text);
            objProducto.Proovedor = txtProovedor.Text;
            objProducto.Existencia = Convert.ToInt32(txtExistencia.Text);
            objProducto.Descripcion = txtDescripcion.Text;
            objProducto.Idusuario = objDatosInventario.getIdEmpleado(lblEmpleado.Text);
            objProducto.RutaImg = Direccion;
            // MUESTRA MENSAJE DE CONFIRMACION
            objDatosInventario.ModificarProducto(objProducto);
            MessageBox.Show("Producto Modificado", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnGuardar.Visible = true;
            btnModificar.Visible = false;
            txtClave.Text = "";
            txtNombre.Text = "";
            txtProovedor.Text = "";
            txtPrecio.Text = "";
            txtExistencia.Text = "";
            txtDescripcion.Text = "";
            pbProducto.Image = null;
            verProductos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtClave.Text = "";
            txtNombre.Text = "";
            txtProovedor.Text = "";
            txtPrecio.Text = "";
            txtExistencia.Text = "";
            txtDescripcion.Text = "";
            pbProducto.Image = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == dataGridView1.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                btnGuardar.Visible = false;
                btnModificar.Visible = true;
                clsInventario objinv = new clsInventario();
                clsDatosInventario objdatos = new clsDatosInventario();
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                objinv.Clave = Convert.ToString(fila.Cells["Clave"].Value);
                objdatos.buscarProducto(ref objinv);


                txtClave.Text = objinv.Clave;
                txtNombre.Text = objinv.Nombre;
                txtPrecio.Text = Convert.ToString(objinv.Precio);
                txtProovedor.Text = objinv.Proovedor;
                txtExistencia.Text = Convert.ToString(objinv.Existencia);
                txtDescripcion.Text = objinv.Descripcion;
                pbProducto.ImageLocation = objinv.RutaImg;
            }
            else
            {
                // CREA LOS OBJETOS
                clsDatosInventario datos = new clsDatosInventario();
                clsInventario producto = new clsInventario();
                DialogResult result = MessageBox.Show("Seguro que deseas eliminar?", "Movistar.....", MessageBoxButtons.YesNoCancel);
                // REFRESCA LOS DATOS Y MUESTRA EL MENSAJE "ELIMINADO"
                if (result == DialogResult.Yes)
                {
                    DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                    producto.Clave = Convert.ToString(fila.Cells["Clave"].Value);
                    datos.Eliminar(producto);

                    //verProductos();
                    MessageBox.Show("Producto Eliminado");
                }
            }
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            btnModificar.Visible = false;
            verProductos();
            dataGridView1.AllowUserToAddRows = false;
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (rbnClave.Checked == true)
            {
                dataGridView1.Rows.Clear();
                tabla = consulta.getDatosProductobyclave(txtBuscar.Text);
                foreach (clsInventario elemento in tabla)
                {
                    dataGridView1.Rows.Add(elemento.Clave, elemento.Nombre, elemento.Precio, elemento.Existencia);
                }
            }
            else
            {
                if (rbnNombre.Checked == true)
                {
                    dataGridView1.Rows.Clear();
                    tabla = consulta.getDatosProductobynombre(txtBuscar.Text);
                    foreach (clsInventario elemento in tabla)
                    {
                        dataGridView1.Rows.Add(elemento.Clave, elemento.Nombre, elemento.Precio, elemento.Existencia);
                    }
                }
                else
                {
                    if (rbnTipo.Checked == true)
                    {
                        dataGridView1.Rows.Clear();
                        tabla = consulta.getDatosProductobytipo(txtBuscar.Text);
                        foreach (clsInventario elemento in tabla)
                        {
                            dataGridView1.Rows.Add(elemento.Clave, elemento.Nombre, elemento.Precio, elemento.Existencia);
                        }
                    }
                }

            }
        }
    }
}
