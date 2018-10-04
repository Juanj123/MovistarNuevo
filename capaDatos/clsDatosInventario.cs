using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaPojos;
using System.Data;
using MySql.Data.MySqlClient;

namespace capaDatos
{
   public class clsDatosInventario
    {
        clsConexion cone = new clsConexion();
        public void AgregarProducto(clsInventario objProducto)
        {
            string sql;
            MySqlCommand cm;
            cone.conectar();
            cm = new MySqlCommand();
            cm.Parameters.AddWithValue("@clave", objProducto.Clave);
            cm.Parameters.AddWithValue("@idUsuario", objProducto.Idusuario);
            cm.Parameters.AddWithValue("@idCategoria", objProducto.Categoria);
            cm.Parameters.AddWithValue("@imgProducto", objProducto.RutaImg);
            cm.Parameters.AddWithValue("@nombre", objProducto.Nombre);
            cm.Parameters.AddWithValue("@precio", objProducto.Precio);
            cm.Parameters.AddWithValue("@existencia", objProducto.Existencia);
            cm.Parameters.AddWithValue("@descripcion", objProducto.Descripcion);

            sql = "insert into inventario value(@clave,@idUsuario,@idCategoria,@imgProducto,@nombre,@precio,@existencia,@descripcion);";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cone.cn;
            cm.ExecuteNonQuery();
            cone.cerrar();
        }

        public void Eliminar(clsInventario objInventario)
        {
            string sql;
            MySqlCommand cm;
            cone.conectar();

            cm = new MySqlCommand();
            sql = "DELETE FROM inventario WHERE clave = '" + objInventario.Clave + "'";
            cm.CommandText = sql;
            cm.CommandType = System.Data.CommandType.Text; ;
            cm.Connection = cone.cn;
            cm.ExecuteNonQuery();
            cone.cerrar();
        }

        public int getIdEmpleado(string nombre)
        {
            cone.conectar();
            int numeroId = 0;
            List<clsUsuarios> lstUsuarios = new List<clsUsuarios>();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            sql = "select idUsuario from usuarios where nombre = '" + nombre + "';";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cone.cn;
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                clsUsuarios objAl = new clsUsuarios();
                numeroId = Convert.ToInt32(dr.GetString("idUsuario"));

            }
            cone.cerrar();
            return numeroId;
        }

        public void ModificarProducto(clsInventario objProducto)
        {
            string sql;
            MySqlCommand cm;
            cone.conectar();

            cm = new MySqlCommand();

            cm.Parameters.AddWithValue("@clave", objProducto.Clave);
            cm.Parameters.AddWithValue("@idusuario", objProducto.Idusuario);
            cm.Parameters.AddWithValue("@imgProducto", objProducto.RutaImg);
            cm.Parameters.AddWithValue("@nombre", objProducto.Nombre);
            cm.Parameters.AddWithValue("@Categoria", objProducto.Categoria);
            cm.Parameters.AddWithValue("@precio", objProducto.Precio);
            cm.Parameters.AddWithValue("@existencia", objProducto.Existencia);
            cm.Parameters.AddWithValue("@descripcion", objProducto.Descripcion);


            sql = "UPDATE inventario SET clave = @clave, idUsuario = @idusuario, idCategoria = @Categoria, imgProducto = @imgProducto," +
                "nombre = @nombre, precio = @precio, existencia = @existencia, descripcion = @descripcion" +
                "WHERE clave = @clave";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cone.cn;
            cm.ExecuteNonQuery();
            cone.cerrar();
        }

        public clsInventario buscarProducto(ref clsInventario cli)
        {
            cone.conectar();
            string consulta = "select * from inventario where clave= '" + cli.Clave + "'";
            MySqlCommand miCom = new MySqlCommand(consulta, cone.cn);
            MySqlDataReader midataReader = miCom.ExecuteReader();
            midataReader.Read();
            if (midataReader.HasRows)
            {
                cli.Clave = midataReader["clave"].ToString();
                cli.Idusuario = Convert.ToInt32(midataReader["idUsuario"].ToString());
                cli.RutaImg = midataReader["imgProducto"].ToString();
                cli.Nombre = midataReader["nombre"].ToString();
                cli.Categoria = Convert.ToInt32(midataReader["idCategoria"].ToString());
                cli.Precio = Convert.ToDouble(midataReader["precio"].ToString());
                cli.Existencia = Convert.ToInt32(midataReader["existencia"].ToString());
                cli.Descripcion = midataReader["descripcion"].ToString();
            }
            else
            {
                return null;
            }
            midataReader.Close();
            miCom.Dispose();
            cone.cn.Close();
            return cli;
        }

        public List<clsInventario> getDatosProducto()
        {
            List<clsInventario> lstProductos = new List<clsInventario>();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            cone.conectar();
            sql = "SELECT  clave, nombre, precio, existencia from inventario";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cone.cn;
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                clsInventario objProduct = new clsInventario();
                objProduct.Clave = Convert.ToString(dr.GetInt32("clave"));
                objProduct.Nombre = dr.GetString("nombre");
                objProduct.Precio = dr.GetDouble("precio");
                objProduct.Existencia = Convert.ToInt32(dr.GetInt32("existencia"));
                lstProductos.Add(objProduct);
            }

            cone.cerrar();
            return lstProductos;
        }

        public List<clsInventario> getDatosProductobyclave(string clave)
        {
            List<clsInventario> lstProductos = new List<clsInventario>();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            cone.conectar();
            sql = "SELECT  clave, nombre, precio, existencia from inventario where clave like '" + clave + "%'";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cone.cn;
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                clsInventario objProduct = new clsInventario();
                objProduct.Clave = Convert.ToString(dr.GetInt32("clave"));
                objProduct.Nombre = dr.GetString("nombre");
                objProduct.Precio = dr.GetDouble("precio");
                objProduct.Existencia = Convert.ToInt32(dr.GetInt32("existencia"));
                lstProductos.Add(objProduct);
            }

            cone.cerrar();
            return lstProductos;
        }

        public List<clsInventario> getDatosProductobynombre(string clave)
        {
            List<clsInventario> lstProductos = new List<clsInventario>();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            cone.conectar();
            sql = "SELECT  clave, nombre, precio, existencia from inventario where nombre like '" + clave + "%'";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cone.cn;
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                clsInventario objProduct = new clsInventario();
                objProduct.Clave = Convert.ToString(dr.GetInt32("clave"));
                objProduct.Nombre = dr.GetString("nombre");
                objProduct.Precio = dr.GetDouble("precio");
                objProduct.Existencia = Convert.ToInt32(dr.GetInt32("existencia"));
                lstProductos.Add(objProduct);
            }

            cone.cerrar();
            return lstProductos;
        }

        public List<clsInventario> getDatosProductobytipo(int clave)
        {
            List<clsInventario> lstProductos = new List<clsInventario>();
            string sql;
            
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            cone.conectar();
            sql = "SELECT  clave, nombre, precio, existencia from inventario where idCategoria like '" + clave + "%'";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cone.cn;
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                clsInventario objProduct = new clsInventario();
                objProduct.Clave = Convert.ToString(dr.GetInt32("clave"));
                objProduct.Nombre = dr.GetString("nombre");
                objProduct.Precio = dr.GetDouble("precio");
                objProduct.Existencia = Convert.ToInt32(dr.GetInt32("existencia"));
                lstProductos.Add(objProduct);
            }

            cone.cerrar();
            return lstProductos;
        }
        public void AgregarDVenta(clsDVenta objProducto)
        {
            string sql;
            MySqlCommand cm;
            cone.conectar();
            cm = new MySqlCommand();
            cm.Parameters.AddWithValue("@folio", objProducto.Folio);
            cm.Parameters.AddWithValue("@nombreProduct", objProducto.Nombre);
            cm.Parameters.AddWithValue("@precioProduct", objProducto.Precio);
            cm.Parameters.AddWithValue("@cantidadProduct", objProducto.Cantidad);
            cm.Parameters.AddWithValue("@total", objProducto.Total);

            sql = "insert  into dventas value(@folio,@nombreProduct,@precioProduct,@cantidadProduct, @total);";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cone.cn;
            cm.ExecuteNonQuery();
            cone.cerrar();
        }

        public List<clsCategorias> listaCategorias()
        {
            cone.conectar();
            List<clsCategorias> lstUsuarios = new List<clsCategorias>();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            sql = "select nombre from categoria;";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cone.cn;
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                clsCategorias objAl = new clsCategorias();
                objAl.Nombre = dr.GetString("nombre");
                lstUsuarios.Add(objAl);
            }
            cone.cerrar();
            return lstUsuarios;
        }
        public int getIdCategoria(string nombre)
        {
            cone.conectar();
            int numeroId = 0;
            List<clsCategorias> lstUsuarios = new List<clsCategorias>();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            sql = "select idCategoria from categoria where nombre = '" + nombre + "';";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cone.cn;
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                clsCategorias objAl = new clsCategorias();
                numeroId = Convert.ToInt32(dr.GetString("idCategoria"));

            }
            cone.cerrar();
            return numeroId;
        }
        public string getnombreCategoria(int id)
        {
            cone.conectar();
            string numeroId = "";
            List<clsCategorias> lstUsuarios = new List<clsCategorias>();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            sql = "select nombre from categoria where idCategoria = '" + id + "';";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cone.cn;
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                clsCategorias objAl = new clsCategorias();
                numeroId = dr.GetString("nombre");

            }
            cone.cerrar();
            return numeroId;
        }
        public void AgregarCategoria(clsCategorias objCategoria)
        {
            string sql;
            MySqlCommand cm;
            cone.conectar();
            cm = new MySqlCommand();
            cm.Parameters.AddWithValue("@idCategoria", objCategoria.Id);
            cm.Parameters.AddWithValue("@nombre", objCategoria.Nombre);
       
            sql = "insert  into categoria value(@idCategoria,@nombre);";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cone.cn;
            cm.ExecuteNonQuery();
            cone.cerrar();
        }
    }
}
