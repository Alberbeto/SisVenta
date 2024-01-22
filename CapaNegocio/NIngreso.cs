using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NIngreso
    {
        public static string Insertar(int idtrabajador, int idproveedor, DateTime fecha, string tipo_comprobante, string serie, string correlativo, decimal igv, string estado, DataTable dtdetalles)
        {
            DIngreso dIngreso = new DIngreso();
            dIngreso.Idtrabajador = idtrabajador;
            dIngreso.Idproveedor = idproveedor;
            dIngreso.Fecha = fecha;
            dIngreso.Tipo_Comprobante = tipo_comprobante;
            dIngreso.Serie = serie;
            dIngreso.Correlativo = correlativo;
            dIngreso.Igv = igv;
            dIngreso.Estado = estado;
            //lista creada en dINgreso jalado de DdetalleIngreso

            List<DDetalle_ingreso> detalles = new List<DDetalle_ingreso>();
            //recorrer de tipo fila de datos llamado fila
            //de mi parametro detalles de todas las filas que tengo
            //el cual va a rrecorrer uno por uno de mi capapresentacion
            foreach (DataRow row in dtdetalles.Rows)
            {
                DDetalle_ingreso detalle = new DDetalle_ingreso();

                //obtengo el valor en el objeto row busaca en l columna idarticulo en texto
                //// y luego lo conviertes a int
                detalle.Idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                detalle.Precio_Compra = Convert.ToDecimal(row["precio_compra"].ToString());
                detalle.Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Stock_Inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Fecha_Produccio = Convert.ToDateTime(row["fecha_produccio"].ToString());
                detalle.Fecha_Vencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString());
                detalles.Add(detalle);  
            }

            return dIngreso.Insertar(dIngreso,detalles);
        }


        public static string Anular(int idingreso)
        {
            DIngreso dingreso = new DIngreso();
            dingreso.Idingreso = idingreso;
            return dingreso.Anular(dingreso);
        }


       public static DataTable Mostrar()
        {
            return new DIngreso().Mostar();
        }


        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            DIngreso dIngreso = new DIngreso();
            return dIngreso.BuscarFechas(textobuscar, textobuscar2);
        }

        public static DataTable MostarDetalle(string textobuscar)
        {
            DIngreso dIngreso = new DIngreso();
            return dIngreso.MostrarDtalle(textobuscar);
        }
    }


    
}
          
    
