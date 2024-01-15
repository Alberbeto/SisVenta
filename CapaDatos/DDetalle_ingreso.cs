using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace CapaDatos
{
    public class DDetalle_ingreso
    {
        private int _Iddetalle_ingreso;
        private int _Idingreso;
        private int _Idarticulo;
        private decimal _Precio_Compra;
        private decimal _Precio_Venta;
        private int _Stock_Inicial;
        private int _Stock_Actual;
        private DateTime _Fecha_Produccio;
        private DateTime _Fecha_Vencimiento;
        private string _TextoBuscar;

        public int Iddetalle_ingreso { get => _Iddetalle_ingreso; set => _Iddetalle_ingreso = value; }
        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }

        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public decimal Precio_Compra { get => _Precio_Compra; set => _Precio_Compra = value; }
        public decimal Precio_Venta { get => _Precio_Venta; set => _Precio_Venta = value; }
        public int Stock_Inicial { get => _Stock_Inicial; set => _Stock_Inicial = value; }
        public int Stock_Actual { get => _Stock_Actual; set => _Stock_Actual = value; }
        public DateTime Fecha_Produccio { get => _Fecha_Produccio; set => _Fecha_Produccio = value; }
        public DateTime Fecha_Vencimiento { get => _Fecha_Vencimiento; set => _Fecha_Vencimiento = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
       

        public  DDetalle_ingreso()
        {

        }


        public DDetalle_ingreso(int iddetalle_ingreso, int idingreso,
            int idarticulo,decimal precio_compra, decimal precio_venta,
            int stock_inicial, int stock_actual, DateTime fecha_produccion, DateTime fecha_vencimiento, string textobuscar)
        {

            this.Iddetalle_ingreso = iddetalle_ingreso;
            this.Idingreso = idingreso;
            this.Idarticulo = idarticulo;
            this.Precio_Compra = precio_compra;
            this.Precio_Venta = precio_venta;
            this.Stock_Inicial = stock_inicial;
            this.Stock_Actual = stock_actual;
            this.Fecha_Produccio = fecha_produccion;
            this.Fecha_Vencimiento = fecha_vencimiento;
            this.TextoBuscar = textobuscar;



            

        }

        public string Insertar(DDetalle_ingreso ddetalle_ingreso,
            ref SqlConnection sqlCon, ref SqlTransaction sqltransa)
        {
            string rpta = "";
          

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.Transaction = sqltransa;
                cmd.CommandText = "spinsertar_detalle_ingreso";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@iddetalle_ingreso";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Direction = ParameterDirection.Input;
               
                cmd.Parameters.Add(parameter);


                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@idingreso";
                parameter2.SqlDbType= SqlDbType.Int;
                parameter2.Value = ddetalle_ingreso.Idingreso;
                cmd.Parameters.Add(parameter2);

                SqlParameter parameter3 = new SqlParameter();
                parameter3.ParameterName = "@idarticulo";
                parameter3.SqlDbType = SqlDbType.Int;
                parameter3.Value = ddetalle_ingreso.Idarticulo;
                cmd.Parameters.Add(parameter3);


                SqlParameter parameter4 = new SqlParameter();
                parameter4.ParameterName = "@precio_compra";
                parameter4.SqlDbType = SqlDbType.Money;
                parameter4.Value = ddetalle_ingreso.Precio_Compra;
                cmd.Parameters.Add(parameter4);

                SqlParameter parameter5 = new SqlParameter();
                parameter5.ParameterName = "@precio_venta";
                parameter5.SqlDbType = SqlDbType.Money;
                parameter5.Value = ddetalle_ingreso.Precio_Venta;
                cmd.Parameters.Add(parameter5);

                SqlParameter parameter6= new SqlParameter();
                parameter6.ParameterName = "@stock_inicial";
                parameter6.SqlDbType = SqlDbType.Int;
                parameter6.Value = ddetalle_ingreso.Stock_Inicial;
                cmd.Parameters.Add(parameter6);

                SqlParameter parameter7 = new SqlParameter();
                parameter7.ParameterName = "@stock_actual";
                parameter7.SqlDbType = SqlDbType.Int;
                parameter7.Value = ddetalle_ingreso.Stock_Actual;
                cmd.Parameters.Add(parameter7);


                SqlParameter parameter8 = new SqlParameter();
                parameter8.ParameterName = "@fecha_produccion";
                parameter8.SqlDbType = SqlDbType.DateTime;
                parameter8.Value = ddetalle_ingreso.Fecha_Produccio;
                cmd.Parameters.Add(parameter8);

                SqlParameter parameter9 = new SqlParameter();
                parameter9.ParameterName = "@fecha_vencimiento";
                parameter9.SqlDbType = SqlDbType.DateTime;
                parameter9.Value = ddetalle_ingreso.Fecha_Vencimiento;
                cmd.Parameters.Add(parameter8);

                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se guardo el registro";

            }
            catch (Exception ex)
            {

                rpta = ex.Message + ex.StackTrace;
            }
          

            return rpta;
        }


    






    }
}
