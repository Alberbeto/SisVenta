using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;


namespace CapaDatos
{
    public class DPresentacion
    {
        private int idpresentacion;
        private string nombre;
        private string descripcion;
        private string textobuscar;

        public int Idpresentacion { get => idpresentacion; set => idpresentacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Textobuscar { get => textobuscar; set => textobuscar = value; }

        public DPresentacion() { 
        
        
        }


        public DPresentacion(int idpresentacion,string nombre,string descripcion,string textobuscar)
        {
            this.Idpresentacion = idpresentacion;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Textobuscar = textobuscar;

        }
    
        public string Insertar(DPresentacion presentacion)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Clase_Conexion.Cn;
                conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "spinsertar_presentancion";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parametroId = new SqlParameter();
                parametroId.ParameterName = "@idpresentacion";
                parametroId.SqlDbType = SqlDbType.Int;
                parametroId.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parametroId);

                SqlParameter parametroNombre = new SqlParameter();
                parametroNombre.ParameterName = "@nombre";
                parametroNombre.SqlDbType = SqlDbType.VarChar;
                parametroNombre.Size = 50;
                parametroNombre.Value = presentacion.Nombre;
                cmd.Parameters.Add(parametroNombre);

                SqlParameter parametroDescrip = new SqlParameter();
                parametroDescrip.ParameterName = "@descripcion";
                parametroDescrip.SqlDbType = SqlDbType.VarChar;
                parametroDescrip.Size = 256;
                parametroDescrip.Value = presentacion.Descripcion;
                cmd.Parameters.Add(parametroDescrip);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se ha guardo el registro";


            }
            catch (Exception ex)
            {

               rpta = ex.Message;
            }finally
            {
                if(conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return rpta;
        }


        public string Editar(DPresentacion presentacion)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Clase_Conexion.Cn;
                conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "speditar_presentacion";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idparametro = new SqlParameter();
                idparametro.ParameterName = "@idpresentacion";
                idparametro.SqlDbType = SqlDbType.Int;
                idparametro.Value = presentacion.Idpresentacion;
                cmd.Parameters.Add(idparametro);

                SqlParameter parametroNombre =new SqlParameter();
                parametroNombre.ParameterName = "@nombre";
                parametroNombre.SqlDbType = SqlDbType.VarChar;
                parametroNombre.Size = 50;
                parametroNombre.Value=presentacion.Nombre;
                cmd.Parameters.Add(parametroNombre);

                SqlParameter parametroDescripcion =new SqlParameter();
                parametroDescripcion.ParameterName = "@descripcion";
                parametroDescripcion.SqlDbType = SqlDbType.VarChar;
                parametroDescripcion.Size = 256;
                parametroDescripcion.Value = presentacion.Descripcion;
                cmd.Parameters.Add(parametroDescripcion);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "no se actualizo el registro";
            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if(conexion.State == ConnectionState.Open)
                {
                    conexion.Close();   
                }
            }

            return rpta;
        }



        public string Eliminar(DPresentacion presentacion)
        {
            string rpta = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Clase_Conexion.Cn;
                conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "speliminar_presentacion";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idparametro = new SqlParameter();
                idparametro.ParameterName = "@idpresentacion";
                idparametro.SqlDbType = SqlDbType.Int;
                idparametro.Value= presentacion.Idpresentacion;
                cmd.Parameters.Add(idparametro);    

                rpta = cmd.ExecuteNonQuery()==1?"OK": "no se eliminaron los registros";

            }
            catch (Exception ex)
            {

                rpta= ex.Message;   
            }
            finally
            {
                if(conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return rpta;
        }

        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("presentacion");
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = Clase_Conexion.Cn;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = "spmostrar_presentacion";
                cmd.CommandType= CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);


            }
            catch (Exception)
            {

                dt = null;
            }
            return dt;
        }


        public DataTable BuscarNombre(DPresentacion presentacion)
        {
            DataTable dt = new DataTable("presentacion");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString= Clase_Conexion.Cn;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection=conexion;
                cmd.CommandText = "spbuscar_presentacion_nombre";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idparametro = new SqlParameter();
                idparametro.ParameterName = "@textobuscar";
                idparametro.SqlDbType = SqlDbType.VarChar;
                idparametro.Size = 50;
                idparametro.Value = presentacion.Textobuscar;
                cmd.Parameters.Add(idparametro);

                SqlDataAdapter adapter = new SqlDataAdapter( cmd);
                adapter.Fill(dt);

            }
            catch (Exception)
            {

                dt = null;
            }
            return dt;
           
        }

       

        
    
    }
}
