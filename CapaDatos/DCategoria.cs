using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Permissions;

namespace CapaDatos
{
    public class DCategoria
    {

        private int _Idcategoria;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;

        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
    
        public DCategoria() { 
        
        
        }

        public DCategoria(int idcategoria,string nombre,string descripcion, string textobuscar)
        {
            this.Idcategoria=idcategoria;
            this.Nombre = nombre;
            this.Descripcion=descripcion;
            this.TextoBuscar=textobuscar;
        }

        //Metodo Insertar

        public string Insertar(DCategoria categoria)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Clase_Conexion.Cn;
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spinsertar_categorias";
                sqlcmd.CommandType = CommandType.StoredProcedure;
                
                SqlParameter parId = new SqlParameter();
                parId.ParameterName = "@idcategoria";
                parId.SqlDbType = SqlDbType.Int;
                parId.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(parId);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value= categoria.Nombre;
                sqlcmd.Parameters.Add(parNombre);

                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 256;
                parDescripcion.Value = categoria.Descripcion;
                sqlcmd.Parameters.Add(parDescripcion);


                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "no se guardo el registro";
            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally 
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
                
            }

            return rpta;
        }

        //Modoto Editar

        public string Editar(DCategoria categoria)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Clase_Conexion.Cn;
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "speditar_categorias";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId = new SqlParameter();
                parId.ParameterName = "@idcategoria";
                parId.SqlDbType = SqlDbType.Int;
                parId.Value = categoria.Idcategoria;
                sqlcmd.Parameters.Add(parId);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = categoria.Nombre;
                sqlcmd.Parameters.Add(parNombre);

                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 256;
                parDescripcion.Value = categoria.Descripcion;
                sqlcmd.Parameters.Add(parDescripcion);


                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "no se actualizo el registro";
            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }

            }

            return rpta;
        }


        //Metodo Eliminar 

        public string Eliminar(DCategoria categoria)
        {

            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Clase_Conexion.Cn;
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "speliminar_categorias";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId = new SqlParameter();
                parId.ParameterName = "@idcategoria";
                parId.SqlDbType = SqlDbType.Int;
                parId.Value = categoria.Idcategoria;
                sqlcmd.Parameters.Add(parId);






                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "no se Elimino el registro";
            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }

            }

            return rpta;
        }

        //Metodo Mostar

        public DataTable Mostar()
        {
            DataTable Dtresultado = new DataTable("categoria");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString= Clase_Conexion.Cn;
              
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection= sqlcon;
                sqlcmd.CommandText = "spmostrar_categorias";
                sqlcmd.CommandType= CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(Dtresultado);


            }
            catch (Exception )
            {

                Dtresultado = null;
            }
            return Dtresultado;


        }

        //Metodo BuscarNombre

        public DataTable BuscarNombre(DCategoria categoria)
        {
            DataTable Dtresultado = new DataTable("categoria");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Clase_Conexion.Cn;

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_categorias";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter prtexto = new SqlParameter();
                prtexto.ParameterName = "@textobuscar";
                prtexto.SqlDbType = SqlDbType.VarChar;
                prtexto.Size= 50;
                prtexto.Value = categoria.TextoBuscar;
               sqlcmd.Parameters.Add(prtexto);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(Dtresultado);


            }
            catch (Exception )
            {

                Dtresultado = null;
            }
            return Dtresultado;

        }

    }

   
    
    
}




