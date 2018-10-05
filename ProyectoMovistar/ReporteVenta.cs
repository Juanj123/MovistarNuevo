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

            if (!cmbEmpleados.Text.Equals(""))
            {
                dgVenta.DataSource = daoReporte.MostrarVenta(daoReporte.obtenerId(cmbEmpleados.SelectedItem.ToString()), dtpfecha.Text);

                txtTotal.Text = sumar();
            }
            else
            {
                MessageBox.Show("Selecciona un Usuario", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string sumar()
        {
            
            int sumad=0;
            int c = 1;
            for (int i = 0; i < dgVenta.RowCount; i++)
            {
                sumad += Convert.ToInt32(dgVenta.Rows[i].Cells[3].Value);
            }
            return Convert.ToString(sumad);
        }
        private void ReporteVenta_Load(object sender, EventArgs e)
        {
            mostrarEmpleados();
        }
    }
}
