using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DIngreso
    {
        private int _Idingreso;
        private int _Idtrabajador;
        private int _Idproveedor;
        private DateTime _Fecha;
        private string _Tipo_Comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;
        private string _Estado;

        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipo_Comprobante { get => _Tipo_Comprobante; set => _Tipo_Comprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Igv { get => _Igv; set => _Igv = value; }
        public string Estado { get => _Estado; set => _Estado = value; }


        public DIngreso()
        {

        }

        public DIngreso(int idingreso, int idtrabajador, int idproveedor, DateTime fecha, string tipo_Comprobante, string serie,
            string correlativo, decimal igv, string estado)
        {
            this.Idingreso = idingreso;
            this.Idtrabajador = idtrabajador;
            this.Idproveedor = idproveedor;
            this.Fecha = fecha;
            this.Tipo_Comprobante = tipo_Comprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
            this.Estado = estado;

        }

        public string Insertar(DIngreso dIngreso, List<DDetalle_ingreso> detalle)
        {
            string rpta = "";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = Clase_Conexion.Cn;
                con.Open();
                SqlTransaction sqltran = con.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.Transaction = sqltran;
                cmd.CommandText = "spinsertar_ingreso";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@idingreso";
                parameter2.SqlDbType = SqlDbType.Int;
                parameter2.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parameter2);


                SqlParameter parameter3 = new SqlParameter();
                parameter3.ParameterName = "@idtrabajador";
                parameter3.SqlDbType = SqlDbType.Int;
                parameter3.Value = dIngreso.Idtrabajador;
                cmd.Parameters.Add(parameter3);


                SqlParameter parameter4 = new SqlParameter();
                parameter4.ParameterName = "@idproveedor";
                parameter4.SqlDbType = SqlDbType.Int;
                parameter4.Value = dIngreso.Idproveedor;
                cmd.Parameters.Add(parameter4);

                SqlParameter parameter5 = new SqlParameter();
                parameter5.ParameterName = "@fecha";
                parameter5.SqlDbType = SqlDbType.DateTime;
                parameter5.Value = dIngreso.Fecha;
                cmd.Parameters.Add(parameter5);

                SqlParameter parameter6 = new SqlParameter();
                parameter6.ParameterName = "@tipo_comprobante";
                parameter6.SqlDbType = SqlDbType.VarChar;
                parameter6.Size = 20;
                parameter6.Value = dIngreso.Tipo_Comprobante;
                cmd.Parameters.Add(parameter6);

                SqlParameter parameter7 = new SqlParameter();
                parameter7.ParameterName = "@serie";
                parameter7.SqlDbType = SqlDbType.VarChar;
                parameter7.Size = 4;
                parameter7.Value = dIngreso.Serie;
                cmd.Parameters.Add(parameter7);

                SqlParameter parameter8 = new SqlParameter();
                parameter8.ParameterName = "@correlativo";
                parameter8.SqlDbType = SqlDbType.VarChar;
                parameter8.Size = 7;
                parameter8.Value = dIngreso.Correlativo;
                cmd.Parameters.Add(parameter8);


                SqlParameter parameter9 = new SqlParameter();
                parameter9.ParameterName = "@igv";
                parameter9.SqlDbType = SqlDbType.Decimal;

                parameter9.Value = dIngreso.Igv;
                cmd.Parameters.Add(parameter9);

                SqlParameter parameter10 = new SqlParameter();
                parameter10.ParameterName = "@estado";
                parameter10.SqlDbType = SqlDbType.VarChar;
                parameter10.Size = 7;
                parameter10.Value = dIngreso.Estado;
                cmd.Parameters.Add(parameter10);


                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";
                if (rpta.Equals("OK"))
                {
                    //Obetenr el codigo del ingreo generado

                    this.Idingreso = Convert.ToInt32(cmd.Parameters["@ingreso"].Value);

                    foreach (DDetalle_ingreso dt in detalle)
                    {
                        dt.Idingreso = this.Idingreso;
                        //lalamr al emtodo insertraR

                        rpta = dt.Insertar(dt, ref con, ref sqltran);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }
                //EVALULAR 
                if (rpta.Equals("OK")) {
                    sqltran.Commit();
                } else
                {
                    //negar la trasbasaccion
                    sqltran.Rollback();
                }


            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return rpta;

        }

        public string Anular(DIngreso dingreso)
        {
            string rpta = "";
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = Clase_Conexion.Cn;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spanular_ingreso";
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter paramer = new SqlParameter();
                paramer.ParameterName = "@idingreso";
                paramer.SqlDbType = SqlDbType.Int;
                paramer.Value = dingreso.Idingreso;
                cmd.Parameters.Add(paramer);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se Anulo el registro";
            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return rpta;


        }

        public DataTable Mostar()
        {
            DataTable dt = new DataTable("ingreso");
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString= Clase_Conexion.Cn;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spmostrar_ingreso";
                cmd.CommandType= CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);


            }
            catch (Exception)
            {

                dt = null;
            }

            return dt;
        }

        public DataTable BuscarFechas(string TextoBuscar,string TextoBuscar2)
        {
            DataTable dt = new DataTable("ingreso");
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = Clase_Conexion.Cn;
                conn.Open();
                SqlCommand cmd = new SqlCommand();  
                cmd.Connection = conn;
                cmd.CommandText = "spbuscar_ingreso_fecha";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@textobuscar";
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Size = 20;
                parameter.Value = TextoBuscar;
                cmd.Parameters.Add(parameter);

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@textobuscar2";
                parameter2.SqlDbType = SqlDbType.VarChar;
                parameter2.Size = 20;
                parameter.Value = TextoBuscar2;
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

        public DataTable MostrarDtalle(string TextoBuscar)
        {
            DataTable dt = new DataTable("ingreso");
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = Clase_Conexion.Cn;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "spmostrar_detalle_ingreso";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@textobuscar";
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Size = 20;
                parameter.Value = TextoBuscar;
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
    }
}
