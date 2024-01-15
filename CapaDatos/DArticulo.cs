using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Data.SqlTypes;

namespace CapaDatos
{
    public  class DArticulo
    {
        private int _Idarticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Imagen;
        private int _Idcategoria;
        private int _Idpresentacion;
        private string _Textobuscar;

        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public int Idpresentacion { get => _Idpresentacion; set => _Idpresentacion = value; }
        public string Textobuscar { get => _Textobuscar; set => _Textobuscar = value; }


       public DArticulo()
        {

        }

        public DArticulo(int idarticulo,string codigo,string nombre,string descripcion,byte[] imagen,int idcategoria,int idpresentacion,string textobuscar)
        {
           this.Idarticulo=idarticulo;
            this.Codigo=codigo;
            this.Nombre=nombre;
            this.Descripcion=descripcion;
            this.Imagen=imagen; 
            this.Idcategoria=idcategoria;
            this.Idpresentacion=idpresentacion;
            this.Textobuscar=textobuscar;

        }

        public string Insertar(DArticulo articulo)
        {
            string rpta = "";
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Clase_Conexion.Cn;
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "sp_insertar_articulo";
                cmd.CommandType = CommandType.StoredProcedure ;
               
                SqlParameter idarticulo = new SqlParameter();
                idarticulo.ParameterName = "@idarticulo";
                idarticulo.SqlDbType = SqlDbType.Int;
                idarticulo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(idarticulo);

                SqlParameter codigo = new SqlParameter();
                codigo.ParameterName = "@codigo";
                codigo.SqlDbType = SqlDbType.VarChar;
                codigo.Size = 50;
                codigo.Value = articulo.Codigo;
                cmd.Parameters.Add(codigo);

                SqlParameter nombre = new SqlParameter();
                nombre.ParameterName = "@nombre";
                nombre.SqlDbType = SqlDbType.VarChar;
                nombre.Size = 50;
                nombre.Value = articulo.Nombre;
                cmd.Parameters.Add(nombre);


                SqlParameter descripcion = new SqlParameter();
                descripcion.ParameterName = "@descripcion";
                descripcion.SqlDbType = SqlDbType.VarChar;
                descripcion.Size = 1024;
                descripcion.Value = articulo.Descripcion;
                cmd.Parameters.Add(descripcion);


                SqlParameter imgen = new SqlParameter();
                imgen.ParameterName = "@imgen";
                imgen.SqlDbType = SqlDbType.Image;
                imgen.Value = articulo.Imagen;
                cmd.Parameters.Add(imgen);


                SqlParameter idcategoria = new SqlParameter();
                idcategoria.ParameterName = "@idcategoria";
                idcategoria.SqlDbType = SqlDbType.Int;
                idcategoria.Value = articulo.Idcategoria;
                cmd.Parameters.Add(idcategoria);

                SqlParameter idpresentacion = new SqlParameter();
                idpresentacion.ParameterName = "@idpresentacion";
                idpresentacion.SqlDbType = SqlDbType.Int;
                idpresentacion.Value = articulo.Idpresentacion;
                cmd.Parameters.Add(idpresentacion);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se Insertaron los registros";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;

            }
            finally
            {
                if(cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return rpta;
        }


        public string Editar(DArticulo articulo)
        {
            string rpta = "";
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn.ConnectionString = Clase_Conexion.Cn;
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "sp_editar_articulo";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idarticulo = new SqlParameter();
                idarticulo.ParameterName = "@idarticulo";
                idarticulo.SqlDbType = SqlDbType.Int;
                idarticulo.Value = articulo.Idarticulo;
                cmd.Parameters.Add(idarticulo);

                SqlParameter codigo = new SqlParameter();
                codigo.ParameterName = "@codigo";
                codigo.SqlDbType = SqlDbType.VarChar;
                codigo.Size = 50;
                codigo.Value = articulo.Codigo;
                cmd.Parameters.Add(codigo);

                SqlParameter nombre = new SqlParameter();
                nombre.ParameterName = "@nombre";
                nombre.SqlDbType = SqlDbType.VarChar;
                nombre.Size = 50;
                nombre.Value = articulo.Nombre;
                cmd.Parameters.Add(nombre);


                SqlParameter descripcion = new SqlParameter();
                descripcion.ParameterName = "@descripcion";
                descripcion.SqlDbType = SqlDbType.VarChar;
                descripcion.Size = 1024;
                descripcion.Value = articulo.Descripcion;
                cmd.Parameters.Add(descripcion);


                SqlParameter imgen = new SqlParameter();
                imgen.ParameterName = "@imgen";
                imgen.SqlDbType = SqlDbType.Image;
                imgen.Value = articulo.Imagen;
                cmd.Parameters.Add(imgen);


                SqlParameter idcategoria = new SqlParameter();
                idcategoria.ParameterName = "@idcategoria";
                idcategoria.SqlDbType = SqlDbType.Int;
                idcategoria.Value = articulo.Idcategoria;
                cmd.Parameters.Add(idcategoria);

                SqlParameter idpresentacion = new SqlParameter();
                idpresentacion.ParameterName = "@idpresentacion";
                idpresentacion.SqlDbType = SqlDbType.Int;
                idpresentacion.Value = articulo.Idpresentacion;
                cmd.Parameters.Add(idpresentacion);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actulizaron los registros";

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if(cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            return rpta;
        }


        public string Eliminar(DArticulo articulo)
        {

            string rpta = "";
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn.ConnectionString = Clase_Conexion.Cn;
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "sp_editar_articulo";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idarticulo = new SqlParameter();
                idarticulo.ParameterName = "@idarticulo";
                idarticulo.SqlDbType = SqlDbType.Int;
                idarticulo.Value = articulo.Idarticulo;
                cmd.Parameters.Add(idarticulo);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se Eliminaron los registros";


            }
            catch (Exception ex )
            {

                rpta = ex.Message;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            return rpta;
        }

        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("articulo");
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Clase_Conexion.Cn;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "sp_mostrar_articulo";
                cmd.CommandType= CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch (Exception )
            {

                dt = null;
            }
            return dt;
        }

        public DataTable BuscarNombre(DArticulo articulo)
        {
            DataTable dt = new DataTable("articulo");
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Clase_Conexion.Cn;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "sp_buscar_articulo_nombre";
                cmd.CommandType = CommandType.StoredProcedure;
              

                
                SqlParameter textobuscar = new SqlParameter();
                textobuscar.ParameterName = "@textobuscar";
                textobuscar.Size = 50;
                textobuscar.SqlDbType = SqlDbType.VarChar;
                textobuscar.Value = articulo.Textobuscar;
                cmd.Parameters.Add(textobuscar);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch (Exception )
            {

                dt = null;
            }
            return dt;

            //  VIDEO 13 CONTINUAR
        }
    }
}
