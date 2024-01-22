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

namespace CapaPresentacion
{
    public partial class frmCliente : Form
    {
        private bool Is_Nuevo = false;
        private bool Is_Editar = false;
        public frmCliente()
        {
            InitializeComponent();
            this.ttMnesaje.SetToolTip(this.txtNombre, "Ingrese el nombre del cliente");
            this.ttMnesaje.SetToolTip(this.txtApellidos, "Ingrese el apellido del cliente");
            this.ttMnesaje.SetToolTip(this.txtNumDoc, "ingrese el numero de documento del cliente");
            this.ttMnesaje.SetToolTip(this.txtDireccion, "Ingrese la direccion del cliente");
            this.ttMnesaje.SetToolTip(this.txtTelefono, "Ingrese el telefono del cliente");
            this.ttMnesaje.SetToolTip(this.txtEmail, "Ingrese el email del cliente");
        }

        public void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "SISTEMA DE VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "SISTEMA DE VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }
        public void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtNumDoc.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
           
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;  
           
        }

        public void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtApellidos.ReadOnly = !valor;
            this.cbSexo.Enabled = valor;
            this.dtFechaNac.Enabled = valor;
            this.cbTipDoc.Enabled = valor;
            this.txtNumDoc.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;

        }

        public void Botones()
        {
            if(this.Is_Nuevo || this.Is_Editar)
            {
                Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }else
            {
                Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }
        public void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();
            OcultarColumnas();
            this.lblTotal.Text = "El Registro total es :" + Convert.ToString(dataListado.Rows.Count);
        }

        public void BuscarApellidos()
        {
            this.dataListado.DataSource = NCliente.BuscarApellido(this.txtBuscar.Text);
            OcultarColumnas();
            this.lblTotal.Text = "El registro total es :" + Convert.ToString(this.dataListado.Rows.Count);
        }

        public void BuscarDocumento()
        {
            this.dataListado.DataSource = NCliente.BuscarDocumento(this.txtBuscar.Text);
            OcultarColumnas();
            this.lblTotal.Text = "El registro total es :" + Convert.ToString(this.dataListado.Rows.Count);
        }



        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            //CAPITULO 12:15
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            Mostrar();
            Habilitar(false);
            Botones();
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.cbBuscar.Text.Equals("APELLIDOS"))
            {
                BuscarApellidos();
            }
            else
            {
                if (this.cbBuscar.Text.Equals("DOCUMENTO"))
                {
                    BuscarDocumento();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                
                DialogResult op;

                op = MessageBox.Show("Realmente desea eliminar el registro", "SISTEMA DE VENTAS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if(op == DialogResult.OK)
                {
                    string rpta = "";
                    string codigo;
                    foreach (DataGridViewRow row in this.dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            rpta = NCliente.Eliminar(Convert.ToInt32(codigo));
                            if (rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se ha eliminado de forma correcta el registro");
                            }
                            else
                            {
                                this.MensajeError(rpta);
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

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Is_Nuevo = true;
            this.Is_Editar = false;
            Botones();
            Habilitar(true);
            Limpiar();
            txtNombre.Focus();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (txtNombre.Text == string.Empty|| txtApellidos.Text == string.Empty||txtNumDoc.Text==string.Empty|| txtDireccion.Text==string.Empty||txtTelefono.Text==string.Empty||txtEmail.Text==string.Empty) {

                    MensajeError("ingrese los campos faltantes");
                    errorIcono.SetError(txtNombre,"Ingrese el nombre");
                    errorIcono.SetError(txtApellidos, "Ingrese los Apellidos");
                    errorIcono.SetError(txtNumDoc, "Ingrese el Numero de Docuemnto");
                    errorIcono.SetError(txtDireccion, "Ingrese la Direccion");
                    errorIcono.SetError(txtTelefono, "Ingrese el Telefono");
                    errorIcono.SetError(txtEmail, "Ingrese el Email");
                }
                else
                {
                    if(this.Is_Nuevo==true)
                    {
                        rpta = NCliente.Insertar(this.txtNombre.Text.Trim().ToLower(), this.txtApellidos.Text, this.cbSexo.Text,
                             this.dtFechaNac.Value, this.cbTipDoc.Text, this.txtNumDoc.Text, this.txtDireccion.Text, this.txtTelefono.Text,
                             this.txtEmail.Text);
                    }else
                    {
                        rpta = NCliente.Editar(Convert.ToInt32(this.txtIdCliente.Text),this.txtNombre.Text.Trim().ToLower(), this.txtApellidos.Text, this.cbSexo.Text,
                             this.dtFechaNac.Value, this.cbTipDoc.Text, this.txtNumDoc.Text, this.txtDireccion.Text, this.txtTelefono.Text,
                             this.txtEmail.Text);
                    }

                    if (rpta=="OK")
                    {
                        if (this.Is_Nuevo == true)
                        {
                            this.MensajeOK("Se Guardo correctamente el registro");
                        }
                        else
                        {
                            this.MensajeOK("Se Actualizo correctamente el registro");
                        }
                    }
                    else
                    {
                        MensajeError(rpta);
                    }
                }

                this.Is_Nuevo = false;
                this.Is_Editar = false;
                this.Botones();
                this.Limpiar();
                this.Mostrar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcliente"].Value);
            this.txtNombre.Text =Convert.ToString( this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtApellidos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellidos"].Value);
            this.txtNumDoc.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["num_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.cbSexo.Text= Convert.ToString(this.dataListado.CurrentRow.Cells["sexo"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.cbTipDoc.Text= Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_documento"].Value);
            this.dtFechaNac.Value= Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha_nacimiento"].Value);

            tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdCliente.Text.Equals(""))
            {
                this.Is_Editar = true;
                this.Botones();
                this.Habilitar(true);

            }
            else
            {
                this.MensajeError("Debe de seleccionar primnero el registro a modificas");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Is_Nuevo = false;
            this.Is_Editar = false;
            this.Botones();
            this.Limpiar();
            this.txtIdCliente.Text = string.Empty;

            //CAPITULO 21 
        }
    }
}
