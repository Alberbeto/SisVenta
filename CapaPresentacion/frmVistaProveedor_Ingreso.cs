using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmVistaProveedor_Ingreso : Form
    {
        public frmVistaProveedor_Ingreso()
        {
            InitializeComponent();
        }

        private void frmVistaProveedor_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostar();
        }

        public void OcultarColumna()
        {
            this.dtListado.Columns[0].Visible = false;
            this.dtListado.Columns[1].Visible = false;
            this.dtListado.Columns[6].Visible = false;
            this.dtListado.Columns[8].Visible = false;
        }

        public void Mostar()
        {
            this.dtListado.DataSource = NProveedor.Mostrar();
            this.OcultarColumna();
            lblTotal.Text = "El numero de registo es :" + Convert.ToString(dtListado.Rows.Count);
        }

        public void BuscarDocumento()
        {
            this.dtListado.DataSource = NProveedor.BuscarNumDocumento(cbBuscar.Text);
            OcultarColumna();
            lblTotal.Text = "el numero de registro es :" + Convert.ToString(dtListado.Rows.Count);
        }

        public void BuscarRazonSocial()
        {
            this.dtListado.DataSource = NProveedor.BuscarRazonSocial(cbBuscar.Text);
            OcultarColumna();
            lblTotal.Text = "el numero de registro es :" + Convert.ToString(dtListado.Rows.Count);
        }

        private void dtListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtListado_DoubleClick(object sender, EventArgs e)
        {
            frmIngreso frm = frmIngreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(dtListado.CurrentRow.Cells["idproveedor"].Value);
            par2 = Convert.ToString(dtListado.CurrentRow.Cells["razon_social"].Value);

            frm.SetProveedor(par1, par2);
            this.Hide();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("DOCUMENTO"))
            {
                this.BuscarDocumento();
            }else if (cbBuscar.Text.Equals("RAZON SOCIAL"))
            {
                this.BuscarRazonSocial();
            }
        }
    }
}
