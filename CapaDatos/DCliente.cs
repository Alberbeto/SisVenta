using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public  class DCliente
    {
        private int _idcliente;
        private string _nombre;
        private string _apellidos;
        private string _sexo;
        private DateTime _fecha_nacimiento;
        private string _tipo_documento;
        private string _num_documento;
        private string _direccion;
        private string _telefono;
        private string _email;
        private string _textobuscar;

        public int Idcliente { get => _idcliente; set => _idcliente = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellidos { get => _apellidos; set => _apellidos = value; }
        public string Sexo { get => _sexo; set => _sexo = value; }
        public DateTime Fecha_nacimiento { get => _fecha_nacimiento; set => _fecha_nacimiento = value; }
        public string Tipo_documento { get => _tipo_documento; set => _tipo_documento = value; }
        public string Num_documento { get => _num_documento; set => _num_documento = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Email { get => _email; set => _email = value; }
        public string Textobuscar { get => _textobuscar; set => _textobuscar = value; }
    
        public DCliente()
        {

        }

        public DCliente(int idcliente, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento, string tipo_docuemnto, string num_documento, string direccion, string telefono, string email, string textobuscar)
        {
            this.Idcliente = idcliente;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.Fecha_nacimiento = fecha_nacimiento;
            this.Tipo_documento = tipo_docuemnto;
            this.Num_documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Textobuscar = textobuscar;
        }

        public string Insertar(DCliente cliente)
        {
            string rpta = "";
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn.ConnectionString = Clase_Conexion.Cn;
                cnn.Open();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = cnn;
                cmm.CommandText = "sp_insertar_cliente";
                cmm.CommandType = CommandType.StoredProcedure;

                SqlParameter param  = new SqlParameter();
                param.ParameterName = "@idcliente";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Output;
                cmm.Parameters.Add(param);

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@nombre";
                param1.SqlDbType = SqlDbType.VarChar;
                param1.Size = 20;
                param1.Value = cliente.Nombre;
                cmm.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@apellidos";
                param2.SqlDbType = SqlDbType.VarChar;
                param2.Size = 40;
                param2.Value = cliente.Apellidos;
                cmm.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@sexo";
                param3.SqlDbType=SqlDbType.VarChar;
                param3.Size = 1;
                param3.Value = cliente.Sexo;
                cmm.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@fecha_nacimiento";
                param4.SqlDbType = SqlDbType.Date;
                param4.Value = cliente.Fecha_nacimiento;
                cmm.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@tipo_documento";
                param5.SqlDbType = SqlDbType.VarChar;
                param5.Size = 20;
                param5.Value = cliente.Tipo_documento;
                cmm.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter();
                param6.ParameterName ="@num_documento";
                param6.SqlDbType= SqlDbType.VarChar;
                param6.Size = 11;
                param6.Value = cliente.Num_documento;
                cmm.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter();
                param7.ParameterName = "@direccion";
                param7.SqlDbType = SqlDbType.VarChar;
                param7.Size = 100;
                param7.Value = cliente.Direccion;
                cmm.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter();
                param8.ParameterName = "@telefono";
                param8.SqlDbType=SqlDbType.VarChar;
                param8.Size = 10;
                param8.Value = cliente.Telefono;
                cmm.Parameters.Add(param8);

                SqlParameter param9 = new SqlParameter();
                param9.ParameterName = "@email";
                param9.SqlDbType=SqlDbType.VarChar;
                param9.Size = 50;
                param9.Value = cliente.Email;
                cmm.Parameters.Add(param9);

                rpta = cmm.ExecuteNonQuery() == 1 ? "OK" : "No Se Guardo el registro";




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



        public string Editar(DCliente cliente)
        {
            string rpta = "";
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn.ConnectionString = Clase_Conexion.Cn;
                cnn.Open();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = cnn;
                cmm.CommandText = "sp_editar_cliente";
                cmm.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@idcliente";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = cliente.Idcliente;
                cmm.Parameters.Add(param);

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@nombre";
                param1.SqlDbType = SqlDbType.VarChar;
                param1.Size = 20;
                param1.Value = cliente.Nombre;
                cmm.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@apellidos";
                param2.SqlDbType = SqlDbType.VarChar;
                param2.Size = 40;
                param2.Value = cliente.Apellidos;
                cmm.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@sexo";
                param3.SqlDbType = SqlDbType.VarChar;
                param3.Size = 1;
                param3.Value = cliente.Sexo;
                cmm.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@fecha_nacimiento";
                param4.SqlDbType = SqlDbType.Date;
                param4.Value = cliente.Fecha_nacimiento;
                cmm.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@tipo_documento";
                param5.SqlDbType = SqlDbType.VarChar;
                param5.Size = 20;
                param5.Value = cliente.Tipo_documento;
                cmm.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter();
                param6.ParameterName = "@num_documento";
                param6.SqlDbType = SqlDbType.VarChar;
                param6.Size = 11;
                param6.Value = cliente.Num_documento;
                cmm.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter();
                param7.ParameterName = "@direccion";
                param7.SqlDbType = SqlDbType.VarChar;
                param7.Size = 100;
                param7.Value = cliente.Direccion;
                cmm.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter();
                param8.ParameterName = "@telefono";
                param8.SqlDbType = SqlDbType.VarChar;
                param8.Size = 10;
                param8.Value = cliente.Telefono;
                cmm.Parameters.Add(param8);

                SqlParameter param9 = new SqlParameter();
                param9.ParameterName = "@email";
                param9.SqlDbType = SqlDbType.VarChar;
                param9.Size = 50;
                param9.Value = cliente.Email;
                cmm.Parameters.Add(param9);

                rpta = cmm.ExecuteNonQuery() == 1 ? "OK" : "No Edito el Registro";




            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if( cnn.State== ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return rpta;
        }

        public string Eliminar(DCliente cliente)
        {
            string rpta = "";
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn.ConnectionString = Clase_Conexion.Cn;
                cnn.Open();
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = cnn;
                cmm.CommandText = "sp_eliminar_cliente";
                cmm.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@idcliente";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = cliente.Idcliente;
                cmm.Parameters.Add(param);

                rpta = cmm.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el regisgtro";


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

        public  DataTable Mostrar()
        {
            DataTable dt = new DataTable("cliente");
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn.ConnectionString= Clase_Conexion.Cn;
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = cnn;
                cmm.CommandText = "sp_mostrar_cliente";
                cmm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmm);
                da.Fill(dt);


            }
            catch (Exception)
            {

                dt = null;
            }
            return dt;
        }


        public DataTable BuscarApellido(DCliente cliente)
        {
            DataTable dt = new DataTable("cliente");
            SqlConnection cnn =new SqlConnection();
            try
            {
                cnn.ConnectionString = Clase_Conexion.Cn;
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = cnn;
                cmm.CommandText = "sp_buscar_apellidos";
                cmm.CommandType = CommandType.StoredProcedure;

                SqlParameter Param = new SqlParameter();
                Param.ParameterName = "@textobuscar";
                Param.SqlDbType = SqlDbType.VarChar;
                Param.Size = 50;
                Param.Value = cliente.Textobuscar;
                cmm.Parameters.Add(Param);

                SqlDataAdapter da = new SqlDataAdapter(cmm);
                da.Fill(dt);


            }
            catch (Exception)
            {

                dt = null;
            }
            return dt;
        }


        public DataTable BuscarDocumento(DCliente cliente)
        {
            DataTable dt = new DataTable("cliente");
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn.ConnectionString = Clase_Conexion.Cn;
                SqlCommand cmm = new SqlCommand();
                cmm.Connection = cnn;
                cmm.CommandText = "sp_buscar_documento";
                cmm.CommandType = CommandType.StoredProcedure;

                SqlParameter Param = new SqlParameter();
                Param.ParameterName = "@textobuscar";
                Param.SqlDbType = SqlDbType.VarChar;
                Param.Size = 50;
                Param.Value = cliente.Textobuscar;
                cmm.Parameters.Add(Param);

                SqlDataAdapter da = new SqlDataAdapter(cmm);
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
