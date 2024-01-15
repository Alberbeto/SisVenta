using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaDatos
{
    public  class DProveedor
    {
        private int idproveedor;
        private string razon_social;
        private string sector_comercial;
        private string tipo_documento;
        private string num_documento;
        private string direccion;
        private string telefono;
        private string email;
        private string url;
        private string textobuscar;

        public int Idproveedor { get => idproveedor; set => idproveedor = value; }
        public string Razon_social { get => razon_social; set => razon_social = value; }
        public string Sector_comercial { get => sector_comercial; set => sector_comercial = value; }
        public string Tipo_documento { get => tipo_documento; set => tipo_documento = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Url { get => url; set => url = value; }
        public string Textobuscar { get => textobuscar; set => textobuscar = value; }
        public string Num_documento { get => num_documento; set => num_documento = value; }

        public DProveedor()
        {


        }

        public DProveedor(int  idproveedor, string razon_social,string sector_comercial,string tipo_documento,string num_documento,string direccion, string telefono, string email, string url,string textobuscar)
        {
            this.Idproveedor = idproveedor;
            this.Razon_social = razon_social;
            this.Sector_comercial = sector_comercial;
            this.Tipo_documento = tipo_documento;
            this.Num_documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Url = url;
            this.Textobuscar = textobuscar;


        }

        public string Insertar(DProveedor proveedor)
        {
            string rpta = "";
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = Clase_Conexion.Cn;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insertar_proveedor";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramen = new SqlParameter();
                paramen.ParameterName = "@idproveedor";
                paramen.SqlDbType = SqlDbType.Int;
                paramen.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramen);

                SqlParameter paramen2 = new SqlParameter();
                paramen2.ParameterName = "@razon_social";
                paramen2.SqlDbType = SqlDbType.VarChar;
                paramen2.Size = 50;
                paramen2.Value = proveedor.Razon_social;
                cmd.Parameters.Add(paramen2);

                SqlParameter paramen3 = new SqlParameter();
                paramen3.ParameterName = "@sector_comercial";
                paramen3.SqlDbType = SqlDbType.VarChar;
                paramen3.Size = 50;
                paramen3.Value = proveedor.Sector_comercial;
                cmd.Parameters.Add(paramen3);

                SqlParameter paramen4 = new SqlParameter();
                paramen4.ParameterName = "@tipo_documento";
                paramen4.SqlDbType = SqlDbType.VarChar;
                paramen4.Size = 20;
                paramen4.Value = proveedor.Tipo_documento;
                cmd.Parameters.Add(paramen4);


                SqlParameter paramen5 = new SqlParameter();
                paramen5.ParameterName = "@num_documento";
                paramen5.SqlDbType = SqlDbType.VarChar;
                paramen5.Size = 11;
                paramen5.Value = proveedor.Num_documento;
                cmd.Parameters.Add(paramen5);

                SqlParameter paramen6 = new SqlParameter();
                paramen6.ParameterName = "@direccion";
                paramen6.SqlDbType = SqlDbType.VarChar;
                paramen6.Size = 100;
                paramen6.Value = proveedor.Direccion;
                cmd.Parameters.Add(paramen6);


                SqlParameter paramen7 = new SqlParameter();
                paramen7.ParameterName = "@telefono";
                paramen7.SqlDbType = SqlDbType.VarChar;
                paramen7.Size = 10;
                paramen7.Value = proveedor.Telefono;
                cmd.Parameters.Add(paramen7);


                SqlParameter paramen8 = new SqlParameter();
                paramen8.ParameterName = "@email";
                paramen8.SqlDbType = SqlDbType.VarChar;
                paramen8.Size = 50;
                paramen8.Value = proveedor.Email;
                cmd.Parameters.Add(paramen8);

                SqlParameter paramen9 = new SqlParameter();
                paramen9.ParameterName = "@url";
                paramen9.SqlDbType = SqlDbType.VarChar;
                paramen9.Size = 100;
                paramen9.Value = proveedor.Url;
                cmd.Parameters.Add(paramen9);


                rpta = cmd.ExecuteNonQuery()== 1 ? "OK" : "No se pudo guardar correctamente" ;



            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();   
                }
            }
            return rpta;
        }


        public string Editar(DProveedor proveedor)
        {
            string rpta = "";
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn.ConnectionString = Clase_Conexion.Cn;
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "editar_proveedor";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@idproveedor";
                param.SqlDbType = SqlDbType.Int;
                param.Value = proveedor.Idproveedor;
                cmd.Parameters.Add(param);

                SqlParameter paramen2 = new SqlParameter();
                paramen2.ParameterName = "@razon_social";
                paramen2.SqlDbType = SqlDbType.VarChar;
                paramen2.Size = 50;
                paramen2.Value = proveedor.Razon_social;
                cmd.Parameters.Add(paramen2);

                SqlParameter paramen3 = new SqlParameter();
                paramen3.ParameterName = "@sector_comercial";
                paramen3.SqlDbType = SqlDbType.VarChar;
                paramen3.Size = 50;
                paramen3.Value = proveedor.Sector_comercial;
                cmd.Parameters.Add(paramen3);

                SqlParameter paramen4 = new SqlParameter();
                paramen4.ParameterName = "@tipo_documento";
                paramen4.SqlDbType = SqlDbType.VarChar;
                paramen4.Size = 20;
                paramen4.Value = proveedor.Tipo_documento;
                cmd.Parameters.Add(paramen4);


                SqlParameter paramen5 = new SqlParameter();
                paramen5.ParameterName = "@num_documento";
                paramen5.SqlDbType = SqlDbType.VarChar;
                paramen5.Size = 11;
                paramen5.Value = proveedor.Num_documento;
                cmd.Parameters.Add(paramen5);

                SqlParameter paramen6 = new SqlParameter();
                paramen6.ParameterName = "@direccion";
                paramen6.SqlDbType = SqlDbType.VarChar;
                paramen6.Size = 100;
                paramen6.Value = proveedor.Direccion;
                cmd.Parameters.Add(paramen6);


                SqlParameter paramen7 = new SqlParameter();
                paramen7.ParameterName = "@telefono";
                paramen7.SqlDbType = SqlDbType.VarChar;
                paramen7.Size = 10;
                paramen7.Value = proveedor.Telefono;
                cmd.Parameters.Add(paramen7);


                SqlParameter paramen8 = new SqlParameter();
                paramen8.ParameterName = "@email";
                paramen8.SqlDbType = SqlDbType.VarChar;
                paramen8.Size = 50;
                paramen8.Value = proveedor.Email;
                cmd.Parameters.Add(paramen8);

                SqlParameter paramen9 = new SqlParameter();
                paramen9.ParameterName = "@url";
                paramen9.SqlDbType = SqlDbType.VarChar;
                paramen9.Size = 100;
                paramen9.Value = proveedor.Url;
                cmd.Parameters.Add(paramen9);


                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se guardo correctamnete";


            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if( cnn.State == ConnectionState.Open)
                {
                    cnn.Close();    
                }
            }
            return rpta;    
        }

        public string Eliminar(DProveedor proveedor)
        {
            string rpta="";
            SqlConnection cnn = new SqlConnection();

            try
            {
                cnn.ConnectionString = Clase_Conexion.Cn;
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "eliminar_proveedor";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@idproveedor";
                param.SqlDbType = SqlDbType.Int;
                param.Value = proveedor.Idproveedor;
                cmd.Parameters.Add(param);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se Eliminio el registro";
            }
            catch (Exception ex)
            {

                rpta =ex.Message;
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


        public DataTable Mostrar()
        {
            DataTable dt = new DataTable("proveedor");
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn.ConnectionString= Clase_Conexion.Cn;
            
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "mostrar_proveedor";
                cmd.CommandType = CommandType.StoredProcedure;  

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);  
                adapter.Fill(dt);


            }
            catch (Exception)
            {

                dt = null;
            }

            return dt;
        }

        public DataTable BuscarRazonSocial(DProveedor proveedor)
        {
            DataTable dt = new DataTable("proveedor");
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn.ConnectionString = Clase_Conexion.Cn;   
            
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "buscar_razon_social";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@textobuscar";
                param.SqlDbType = SqlDbType.VarChar;
                param.Size =50;
                param.Value = proveedor.Textobuscar;
                cmd.Parameters.Add(param);

                SqlDataAdapter da  = new SqlDataAdapter(cmd);
                da.Fill(dt);


            }
            catch (Exception)
            {

                dt = null;
            }

            return dt;
        }


        public DataTable BuscarNumDocumento(DProveedor proveedor)
        {
            DataTable dt = new DataTable("proveedor");
            SqlConnection cnn = new SqlConnection();
            try
            {
               cnn.ConnectionString= Clase_Conexion.Cn;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "buscar_num_documento";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@textobuscar";
                param.SqlDbType = SqlDbType.VarChar;
                param.Size = 50;
                param.Value = proveedor.Textobuscar;
                cmd.Parameters.Add(param);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);


            }
            catch (Exception)
            {

                dt = null;
            }

            return dt;
        }



    }
}
