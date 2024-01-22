using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DTrabajador

    {
        private int _idtrabajador;
        private string _nombre;
        private string _apellido;
        private string _sexo;
        private DateTime _fecha_nac;
        private string _num_documento;
        private string _direccion;
        private string _telefono;
        private string _email;
        private string _acceso;
        private string _usuario;
        private string _password;
        private string _textobuscar;


        public int Idtrabajador { get => _idtrabajador; set => _idtrabajador = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Sexo { get => _sexo; set => _sexo = value; }
        public DateTime Fecha_nac { get => _fecha_nac; set => _fecha_nac = value; }
        public string Num_documento { get => _num_documento; set => _num_documento = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Email { get => _email; set => _email = value; }
        public string Acceso { get => _acceso; set => _acceso = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public string Password { get => _password; set => _password = value; }
        public string Textobuscar { get => _textobuscar; set => _textobuscar = value; }


        public DTrabajador()
        {

        }

        public DTrabajador(int idtrabajador,string nombre,string apellido, string sexo,DateTime fecha_nac,string num_documento,string direccion,string telefono,string email,string acceso, string usuario, string password, string textobuscar)
        {
            DTrabajador obj = new DTrabajador();
            obj.Idtrabajador = idtrabajador;
            obj.Nombre = nombre;
            obj.Apellido = apellido;
            obj.Sexo = sexo;
            obj.Fecha_nac = fecha_nac;
            obj.Num_documento = num_documento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;
            obj.Acceso = acceso;
            obj.Usuario = usuario;
            obj.Password = password;
            obj.Textobuscar = textobuscar;
        }

        public string Insertar(DTrabajador trabajador)
        {
            string rpta = "";
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn.ConnectionString = Clase_Conexion.Cn;
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "spinsertar_trabajador";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@idtrabajador";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Output;
                param.Value = trabajador.Idtrabajador;
                cmd.Parameters.Add(param);  

                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@nombre";
                param2.SqlDbType = SqlDbType.VarChar;
                param2.Size = 20;
                param2.Value = trabajador.Nombre;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@apellido";
                param3.SqlDbType = SqlDbType.VarChar;
                param3.Size = 40;
                param3.Value = trabajador.Apellido;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@sexo";
                param4.SqlDbType = SqlDbType.VarChar;
                param4.Size = 1;
                param4.Value = trabajador.Sexo;
                cmd.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@fecha_nacimiento";
                param5.SqlDbType = SqlDbType.DateTime;
                param5.Value = trabajador.Fecha_nac;
                cmd.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter();
                param6.ParameterName = "@num_documento";
                param6.SqlDbType = SqlDbType.VarChar;
                param6.Size = 8;
                param6.Value = trabajador.Num_documento;
                cmd.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter();
                param7.ParameterName = "@direccion";
                param7.SqlDbType= SqlDbType.VarChar;
                param7.Size = 100;
                param7.Value = trabajador.Direccion;
                cmd.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter();
                param8.ParameterName = "@telefono";
                param8.SqlDbType = SqlDbType.VarChar;
                param8.Size = 10;
                param8.Value = trabajador.Telefono;
                cmd.Parameters.Add(param8);

                SqlParameter param9 = new SqlParameter();
                param9.ParameterName = "@email";
                param9.SqlDbType = SqlDbType.VarChar;
                param9.Size = 50;
                param9.Value = trabajador.Email;
                cmd.Parameters.Add(param9);

                SqlParameter param10 = new SqlParameter();
                param10.ParameterName = "@acceso";
                param10.SqlDbType=SqlDbType.VarChar;
                param10.Size = 20;
                param10.Value = trabajador.Acceso;
                cmd.Parameters.Add(param10);

                SqlParameter param11 = new SqlParameter();
                param11.ParameterName = "@usuario";
                param11.SqlDbType= SqlDbType.VarChar;
                param11.Size = 20;
                param11.Value = trabajador.Usuario;
                cmd.Parameters.Add(param11);

                SqlParameter param12 = new SqlParameter();
                param12.ParameterName = "@password";
                param12.SqlDbType= SqlDbType.VarChar;
                param12.Size = 20;
                param12.Value = trabajador.Password;
                cmd.Parameters.Add(param12);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se puede insertar el registro";
            }
            catch (Exception ex)
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


        public string Editar(DTrabajador trabajador)
        {
            string rpta = "";
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn.ConnectionString = Clase_Conexion.Cn;
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "speditar_trabajador";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@idtrabajador";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = trabajador.Idtrabajador;
                cmd.Parameters.Add(param);

                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@nombre";
                param2.SqlDbType = SqlDbType.VarChar;
                param2.Size = 20;
                param2.Value = trabajador.Nombre;
                cmd.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@apellidos";
                param3.SqlDbType = SqlDbType.VarChar;
                param3.Size = 40;
                param3.Value = trabajador.Apellido;
                cmd.Parameters.Add(param3);

                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@sexo";
                param4.SqlDbType = SqlDbType.VarChar;
                param4.Size = 1;
                param4.Value = trabajador.Sexo;
                cmd.Parameters.Add(param4);

                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@fecha_nacimiento";
                param5.SqlDbType = SqlDbType.DateTime;
                param5.Value = trabajador.Fecha_nac;
                cmd.Parameters.Add(param5);

                SqlParameter param6 = new SqlParameter();
                param6.ParameterName = "@num_documento";
                param6.SqlDbType = SqlDbType.VarChar;
                param6.Size = 8;
                param6.Value = trabajador.Num_documento;
                cmd.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter();
                param7.ParameterName = "@direccion";
                param7.SqlDbType = SqlDbType.VarChar;
                param7.Size = 100;
                param7.Value = trabajador.Direccion;
                cmd.Parameters.Add(param7);

                SqlParameter param8 = new SqlParameter();
                param8.ParameterName = "@telefono";
                param8.SqlDbType = SqlDbType.VarChar;
                param8.Size = 10;
                param8.Value = trabajador.Telefono;
                cmd.Parameters.Add(param8);

                SqlParameter param9 = new SqlParameter();
                param9.ParameterName = "@email";
                param9.SqlDbType = SqlDbType.VarChar;
                param9.Size = 50;
                param9.Value = trabajador.Email;
                cmd.Parameters.Add(param9);

                SqlParameter param10 = new SqlParameter();
                param10.ParameterName = "@acceso";
                param10.SqlDbType = SqlDbType.VarChar;
                param10.Size = 20;
                param10.Value = trabajador.Acceso;
                cmd.Parameters.Add(param10);

                SqlParameter param11 = new SqlParameter();
                param11.ParameterName = "@usuario";
                param11.SqlDbType = SqlDbType.VarChar;
                param11.Size = 20;
                param11.Value = trabajador.Usuario;
                cmd.Parameters.Add(param11);

                SqlParameter param12 = new SqlParameter();
                param12.ParameterName = "@password";
                param12.SqlDbType = SqlDbType.VarChar;
                param12.Size = 20;
                param12.Value = trabajador.Password;
                cmd.Parameters.Add(param12);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se puede actualizar el registro";
            }
            catch (Exception ex)
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


        public string Eliminar(DTrabajador trabajador)
        {
            string rpta = "";
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn.ConnectionString = Clase_Conexion.Cn;
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "speliminar_trabajador";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@idtrabajador";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Input;
                param.Value = trabajador.Idtrabajador;
                cmd.Parameters.Add(param);

                

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se puede eliminar el registro";
            }
            catch (Exception ex)
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

        public DataTable Mostar()
        {
            DataTable dt = new DataTable("trabajador");
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn.ConnectionString = Clase_Conexion.Cn;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "spmostrar_trabajador";
                cmd.CommandType= CommandType.StoredProcedure;

                SqlDataAdapter da   = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception)
            {

                dt = null;
            }

            return dt;
            
        }


        public DataTable BuscarApellido(DTrabajador trabajador)
        {
            DataTable dt = new DataTable("trabajador");
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn.ConnectionString = Clase_Conexion.Cn;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "spbuscar_trabajador_apellidos";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@textobuscar";
                parameter.SqlDbType= SqlDbType.VarChar;
                parameter.Size = 50;
                parameter.Value = trabajador.Textobuscar;
                cmd.Parameters.Add(parameter);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception)
            {

                dt = null;
            }

            return dt;

        }



        public DataTable BuscarDocumento(DTrabajador trabajador)
        {
            DataTable dt = new DataTable("trabajador");
            SqlConnection cnn = new SqlConnection();
            try
            {
                cnn.ConnectionString = Clase_Conexion.Cn;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = "spbuscar_trabajador_num_documento";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@textobuscar";
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Size = 50;
                parameter.Value = trabajador.Textobuscar;
                cmd.Parameters.Add(parameter);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception)
            {

                dt = null;
            }

            return dt;

        }

        public DataTable Login(DTrabajador trabajador)
        {
            DataTable dt = new DataTable("trabajador");
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Clase_Conexion.Cn;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "splogin";
                cmd.CommandType= CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@usuario";
                parameter.SqlDbType= SqlDbType.VarChar;
                parameter.Size = 20;
                parameter.Value = trabajador.Usuario;
                cmd.Parameters.Add(parameter);


                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@password";
                parameter2.SqlDbType = SqlDbType.VarChar;
                parameter2.Size = 20;
                parameter2.Value = trabajador.Password;
                cmd.Parameters.Add(parameter2);

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
