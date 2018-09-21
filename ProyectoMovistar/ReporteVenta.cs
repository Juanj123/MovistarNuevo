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
    public partial class ReporteVenta : Form
    {
        public ReporteVenta()
        {
            InitializeComponent();
        }
        clsDatosReporteVentas daoReporte = new clsDatosReporteVentas();

        public void mostrarEmpleados()
        {

            List<string> c = daoReporte.mostrarEmpleados();
            if (c != null)
            {
                foreach (string i in c)
                {
                    cmbEmpleados.Items.Add(i);
                }
            }
            else
            {
                MessageBox.Show("No se encontraron datos", "AVISO", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            string mes = Convert.ToString(dtpfecha.Value.Month);
            string dia = Convert.ToString(dtpfecha.Value.Day);
            string anio = Convert.ToString(dtpfecha.Value.Year);
            string fecha = anio + "-" + mes + "-" + dia;

            if (!cmbEmpleados.Text.Equals(""))
            {


                dgVenta.DataSource = daoReporte.MostrarVenta(daoReporte.obtenerId(cmbEmpleados.SelectedItem.ToString()), fecha);

                txtTotal.Text = Convert.ToString(daoReporte.obtenerTotal(daoReporte.obtenerId(cmbEmpleados.SelectedItem.ToString()), fecha));
            }
            else
            {
                MessageBox.Show("Selecciona un Usuario", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReporteVenta_Load(object sender, EventArgs e)
        {
            mostrarEmpleados();
        }
    }
}
