using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmArticulo : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        //enviar parametros de un formaluario a otro

        private static frmArticulo _Instancia;

        public static frmArticulo GetInstancia()
        {
            if(_Instancia == null)
            {
                _Instancia = new frmArticulo();
            }

            return _Instancia;
        }

        public void setCtaegoria(string idcategoria, string nombre)
        {
            this.txtIdCategoria.Text = idcategoria;
            this.txtCategoria.Text = nombre;

        }

      
        public frmArticulo()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del articulo");
            this.ttMensaje.SetToolTip(this.pxImagen, "seleccione la imegen del articulo");
            this.ttMensaje.SetToolTip(this.cbIdPresentacion, "seleccione la presentacion de articulo");
            this.ttMensaje.SetToolTip(this.txtCategoria, "Seleccionae la categoria del articulo");


            this.txtIdCategoria.Visible  = false;
            this.txtCategoria.ReadOnly = false;

            this.LlenarComboPresentacion();
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "SISTEMA DE VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "SISTEMA DE VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        private void limpiar()
        {
            this.txtCodigoVenta.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdarticulo.Text = string.Empty;
            this.txtCategoria.Text = string.Empty;
            this.txtIdCategoria.Text = string.Empty;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.blanco;
        }

        private void Habilitar(bool valor)
        {
            this.txtCodigoVenta.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.btnBuscarCategoria.Enabled = valor;
            this.cbIdPresentacion.Enabled = valor;
            this.btnCargar.Enabled = valor;
            this.txtIdarticulo.ReadOnly = !valor;
            this.btnLimpiar.Enabled = valor;
        }

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                Habilitar(true);
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
            }
            else
            {
                Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
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

        private void LlenarComboPresentacion()
        {
            cbIdPresentacion.DataSource = nPresentacion.Mostrar();
            cbIdPresentacion.ValueMember = "idpresentacion";
            cbIdPresentacion.DisplayMember = "nombre";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            DialogResult resultado = ofd.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagen.Image = Image.FromFile(ofd.FileName);

            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.blanco;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Habilitar(true);
            this.Botones();
            this.limpiar();
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtIdCategoria.Text == string.Empty || this.txtCodigoVenta.Text == string.Empty)
                {
                    MessageBox.Show("falta ingresar algunos datos, seriam marcados");
                    errorIcono.SetError(txtNombre, "ingrese un valor");
                    errorIcono.SetError(txtCodigoVenta, "ingrese un valor");
                    errorIcono.SetError(txtCategoria, "ingrese un valor");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    byte[] imagen = ms.GetBuffer();

                    if (this.IsNuevo)
                    {
                        rpta = nArticulo.Insertar(this.txtCodigoVenta.Text, this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDescripcion.Text.Trim().ToUpper(), imagen, Convert.ToInt32(this.txtIdCategoria.Text),
                            Convert.ToInt32(this.cbIdPresentacion.SelectedValue));
                    }
                    else
                    {
                        rpta = nArticulo.Editar(Convert.ToInt32(this.txtIdarticulo.Text), this.txtCodigoVenta.Text, this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDescripcion.Text.Trim().ToUpper(), imagen, Convert.ToInt32(this.txtIdCategoria.Text),
                            Convert.ToInt32(this.cbIdPresentacion.SelectedValue));
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("se inserto de forma correcta el registro");

                        }
                        else
                        {
                            this.MensajeError("se Actualizo de forma correcta el registro");

                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.limpiar();
                    this.Mostrar();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdarticulo.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleecioar el regitro a modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.limpiar();
            this.Habilitar(false);
        }

        private void dtListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //indice de la column es igual al indice de la
            //colunma de datalistado
            if (e.ColumnIndex == this.dtListado.Columns["Eliminar"].Index)
            {
                //para determinar cua es check box q se ha seleccionado
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)this.dtListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);

            }
        }

        private void dtListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdarticulo.Text = Convert.ToString(dtListado.CurrentRow.Cells["idarticulo"].Value);
            this.txtCodigoVenta.Text = Convert.ToString(dtListado.CurrentRow.Cells["codigo"].Value);
            this.txtNombre.Text = Convert.ToString(dtListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(dtListado.CurrentRow.Cells["descripcion"].Value);
            
            byte[] imagenBuffer = (byte[]) this.dtListado.CurrentRow.Cells["imgen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

            this.pxImagen.Image = Image.FromStream(ms);
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;


            this.txtIdCategoria.Text = Convert.ToString(dtListado.CurrentRow.Cells["idcategoria"].Value);
            this.txtCategoria.Text = Convert.ToString(dtListado.CurrentRow.Cells["Categoria"].Value);       
            this.cbIdPresentacion.SelectedValue = Convert.ToString(dtListado.CurrentRow.Cells["idpresentacion"].Value);

            this.tabControl1.SelectedIndex = 1;
        
        
        
        
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked == true)
            {
                this.dtListado.Columns[0].Visible = true;
            }
            else
            { this.dtListado.Columns[0].Visible = false; }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult option;
                option = MessageBox.Show("Realmente desea eliminar el registro", "SYSREMA DE VENTAS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (option == DialogResult.OK)
                {
                    string Codigo;
                    string Rtpa = "";

                    foreach (DataGridViewRow row in dtListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rtpa = nArticulo.Eliminar(Convert.ToInt32(Codigo));

                            if (Rtpa.Equals("OK"))
                            {
                                this.MensajeOk("Selimino correctamnete el regitro");
                            }
                            else
                            {
                                this.MensajeError(Rtpa);
                            }
                        }
                       
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message + ex.StackTrace);
            }    
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            frmVistaCategoria_Articulo form = new frmVistaCategoria_Articulo();
            form.ShowDialog();
        }

       

        private void frmArticulo_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void btnBuscarCategoria_Click_1(object sender, EventArgs e)
        {
            frmVistaCategoria_Articulo frm = new frmVistaCategoria_Articulo();
            frm.Show();
        }
    }
}
