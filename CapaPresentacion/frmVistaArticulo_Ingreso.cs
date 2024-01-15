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
    public partial class frmVistaArticulo_Ingreso : Form
    {
        public frmVistaArticulo_Ingreso()
        {
            InitializeComponent();
        }

        private void frmVistaArticulo_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void OcultarColumas()
        {


            this.dtListado.Columns[0].Visible = false;
            this.dtListado.Columns[1].Visible = false;
            this.dtListado.Columns[6].Visible = false;
            this.dtListado.Columns[8].Visible = false;


        }

        private void Mostrar()
        {
            this.dtListado.DataSource = nArticulo.Mostrar();
            this.OcultarColumas();
            lblTotal.Text = "Total de registros" + Convert.ToString(dtListado.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.dtListado.DataSource = nArticulo.BustarNombre(this.txtBuscar.Text);
            this.OcultarColumas();
            lblTotal.Text = "Total de registros" + Convert.ToString(dtListado.Rows.Count);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dtListado_DoubleClick(object sender, EventArgs e)
        {
            frmIngreso ingreso = frmIngreso.GetInstancia();
            string par1, par2;
            par1= Convert.ToString(this.dtListado.CurrentRow.Cells["idarticulo"].Value);
            par2= Convert.ToString(this.dtListado.CurrentRow.Cells["nombre"].Value);

            ingreso.SetArticulo(par1, par2);
            this.Hide();
        }
    }
}
