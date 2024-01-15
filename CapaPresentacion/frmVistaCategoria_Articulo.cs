using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmVistaCategoria_Articulo : Form
    {
        public frmVistaCategoria_Articulo()
        {
            InitializeComponent();
        }
        private void OcultarColumas()
        {
            this.dtListado.Columns[0].Visible = false;
            this.dtListado.Columns[1].Visible = false;
           
        }

        private void Mostrar()
        {
            this.dtListado.DataSource = nCategoria.Mostrar();
            this.OcultarColumas();
            lblTotal.Text = "Total de registros" + Convert.ToString(dtListado.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.dtListado.DataSource = nCategoria.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumas();
            lblTotal.Text = "Total de registros" + Convert.ToString(dtListado.Rows.Count);

        }


        private void frmVistaCategoria_Articulo_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dtListado_DoubleClick(object sender, EventArgs e)
        {
            frmArticulo  frm = frmArticulo.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dtListado.CurrentRow.Cells["idcategoria"].Value);
            par2 = Convert.ToString(this.dtListado.CurrentRow.Cells["nombre"].Value);
            frm.setCtaegoria(par1, par2);
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
