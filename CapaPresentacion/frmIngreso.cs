using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmIngreso : Form
    {
        //generamos una instancia con el nombre del formulario
        private static frmIngreso _Intancia;
        //para poder enviar el id trabakor desde mi frmprincipal
        public int IdTrabajor;

        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;

        //creamos un metodo de manera estaica 
        //con el nombre del formaluario
        public static frmIngreso GetInstancia()
        {
            //si la instancia es igual a nulo
            //creame una nueva instancia y retornalo
            if(_Intancia == null)
            {
                _Intancia = new frmIngreso();
            }

            return _Intancia;
        }

        //recibir los paramos de proveedor 
        public void SetProveedor(string idproveedor, string nombre)
        {
            this.txtIdProveedor.Text = idproveedor;
            this.txtProveedor.Text = nombre;
        }
        //recibir los paramos del articulo
        public void SetArticulo(string idarticulo, string nombre)
        {
            this.txtArticulo.Text = idarticulo;
            this.txtIdArticulo.Text = nombre;
        }
        public frmIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtProveedor, "Seleccione el proveedor");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese la serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Ingrese el numero del comprobante");
            this.ttMensaje.SetToolTip(this.txtStock, "ingrese la cantidad de la compra");
            this.ttMensaje.SetToolTip(this.txtArticulo, "Seleccione el articulo de compra");
            this.txtIdProveedor.Visible= false;
            this.txtIdArticulo.Visible= false;
            this.txtProveedor.ReadOnly=false;
            this.txtArticulo.ReadOnly=false;
           
        
        }

        public void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "SISTEMAS DE VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "SISTEMA DE VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Limpiar()
        {
            this.txtIdIngreso.Text= string.Empty;
            this.txtIdProveedor.Text= string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtSerie.Text= string.Empty;
            this.txtCorrelativo.Text= string.Empty;
            this.txtIgv.Text= string.Empty;
            this.lblTotalPgado.Text = "0.0";


        }

        private void LimpiarDetalee()
        {
            this.txtIdArticulo.Text= string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStock.Text= string.Empty;
            this.txtPrecioCompra.Text= string.Empty;
            this.txtPrecioVenta.Text= string.Empty;
        }

        public void Habilitar(bool valor) {
            this.txtIdIngreso.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIgv.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cbComprobante.Enabled = !valor;
            this.txtStock.ReadOnly= !valor;
            this.txtPrecioCompra.ReadOnly= !valor;
            this.txtPrecioVenta.ReadOnly= !valor;
            this.dtFechaProd.Enabled= valor;
            this.dtFechaVen.Enabled= valor;
            this.btnBuscarArticulo.Enabled= valor;
            this.btnBuscarProveedor.Enabled= valor;
            this.btnAgregar.Enabled= valor;
            this.btnQuitar.Enabled= valor;



        }

        public void Botones()
        {
            if (this.IsNuevo) {

                Habilitar(true);
                btnNuevo.Enabled = false;
                btnCancelar.Enabled = true;
                btnGuardar.Enabled = false;



            }
            else
            {
                Habilitar(false);
                btnNuevo.Enabled = true;
                btnCancelar.Enabled = false;
                btnGuardar.Enabled = true;
            }
        }

        public void OcultarColumnas()
        {
            this.dtListado.Columns[0].Visible = false;
            this.dtListado.Columns[1].Visible = false;
        }

        public void Mostar()
        {
            this.dtListado.DataSource = NIngreso.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "el numero de registro es " + Convert.ToString(dtListado.Rows.Count); 
        }

        public void BuscarFechas()
        {
            this.dtListado.DataSource = NIngreso.BuscarFechas(dtfecha1.Value.ToString("dd/MM/yyyy"), dtfecha2.Value.ToString("dd/MM/yyyy"));
            OcultarColumnas();
            lblTotal.Text = "el numero de registro es " + Convert.ToString(dtListado.Rows.Count);

        }

        public void MostarDetalle()
        {
            this.dtListado.DataSource = NIngreso.MostarDetalle(this.txtIdIngreso.Text);
            
        }
        private void frmIngreso_Load(object sender, EventArgs e)
        {

        }

        private void frmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Intancia = null;
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaProveedor_Ingreso frm = new frmVistaProveedor_Ingreso();
            frm.ShowDialog();
            //para que aparezca como u cuadro de dialogo
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            frmVistaArticulo_Ingreso frm = new frmVistaArticulo_Ingreso();
            frm .ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarFechas();
        }

        private void dtListado_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
