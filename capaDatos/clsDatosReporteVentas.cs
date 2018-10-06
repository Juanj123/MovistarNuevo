using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using capaPojos;
using System.Data;

namespace capaDatos
{
    public class clsDatosReporteVentas
    {
        clsConexion conexion = new clsConexion();
        public List<string> mostrarEmpleados()
        {
            try
            {
                List<string> cat = new List<string>();
                clsUsuarios pojoUsuarios;
                MySqlCommand cm = new MySqlCommand();
                MySqlDataReader dr;
                conexion.conectar(); ;
                string sql = "select nombre from usuarios";
                cm.CommandText = sql;
                cm.CommandType = CommandType.Text;
                cm.Connection = conexion.cn;
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    pojoUsuarios = new clsUsuarios();
                    pojoUsuarios.Usuario = dr.GetString("nombre");
                    cat.Add(pojoUsuarios.Usuario);
                }
                return cat;
            }
            catch (Exception exc)
            {
                return null;
            }
            finally
            {
                conexion.cerrar();
            }
        }


        public DataTable MostrarVenta(int idEmpleado, string fecha)
        {
            try
            {
                DataTable dato = new DataTable();
                conexion.conectar();
                MySqlCommand cm = new MySqlCommand("select d.nombreProduct as NombreProducto, d.precioProcuct as Precio, d.cantidadProduct as Cantidad  , d.total as Total from dVentas d join ventas v where d.folio = v.folio and v.idUsuario = " + idEmpleado + " and v.fecha like '" + fecha.ToString() + "'", conexion.cn);
                MySqlDataAdapter dt = new MySqlDataAdapter(cm);
                DataSet ds = new DataSet();
                dt.Fill(ds, "dVenta");
                dato = ds.Tables["dVenta"];
                dt.Dispose();
                cm.Dispose();

                return dato;
            }
            catch
            {
                return null;
            }
            finally
            {
                conexion.cerrar();
            }
        }

        public int obtenerId(string n)
        {
            int id = 0;
            try
            {
                MySqlCommand cm = new MySqlCommand();
                MySqlDataReader dr;
                conexion.conectar();
                string sql = "select idUsuario  from usuarios where nombre = '" + n.ToString() + "'";
                cm.CommandText = sql;
                cm.CommandType = CommandType.Text;
                cm.Connection = conexion.cn;
                dr = cm.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    id = dr.GetInt32("idUsuario");
                    return id;
                }
                else
                {
                    return id;
                }
            }
            catch (Exception)
            {
                return id;
            }
            finally
            {
                conexion.cerrar();
            }
        }

        public int obtenerTotal(int idEmpleado, string fecha)
        {
            int id = 0;
            try
            {
                MySqlCommand cm = new MySqlCommand();
                MySqlDataReader dr;
                conexion.conectar();
                string sql = "select sum(total) as total from dVenta d join ventas v where d.folio = v.folio and v.idUsuario = " + idEmpleado + " and fecha like '" + fecha + "'";
                cm.CommandText = sql;
                cm.CommandType = CommandType.Text;
                cm.Connection = conexion.cn;
                dr = cm.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    id = dr.GetInt32("total");
                    return id;
                }
                else
                {
                    return id;
                }
            }
            catch (Exception)
            {
                return id;
            }
            finally
            {
                conexion.cerrar();
            }
        }
    }
}
