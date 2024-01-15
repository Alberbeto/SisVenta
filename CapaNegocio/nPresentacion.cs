using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public  class nPresentacion
    {
        public static string Insertar(string nombre,string descripcion)
        {
            DPresentacion obj = new DPresentacion();
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            return obj.Insertar(obj);
        }

        public static string Editar(int idpresentacion,string nombre,string descripcion)
        {
            DPresentacion obj = new DPresentacion();
            obj.Idpresentacion = idpresentacion;
            obj.Nombre = nombre;
            obj.Descripcion= descripcion;

            return obj.Editar(obj);
        }

        public static string Eliminar(int idpresentacion)
        {
            DPresentacion obj = new DPresentacion();

            obj.Idpresentacion= idpresentacion;

            return obj.Eliminar(obj);
            
        }

        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            DPresentacion obj = new DPresentacion();
            obj.Textobuscar= textobuscar;

            return obj.BuscarNombre(obj);
        }
    }
}
