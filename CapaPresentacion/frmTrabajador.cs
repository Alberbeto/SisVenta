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
    public partial class frmTrabajador : Form
    {
        private bool Is_Nuevo=false;
        private bool Is_Editar= false;
        public frmTrabajador()
        {
            InitializeComponent();
            ttMnesaje.SetToolTip(this.txtNombre, "Ingrese el nombre");
            ttMnesaje.SetToolTip(this.txtApellidos, "Ingrese los Apellidos");
            ttMnesaje.SetToolTip(this.txtNumDoc, "Ingrese el numero de documento");
            ttMnesaje.SetToolTip(this.txtDireccion, "Ingrese la direccion");
            ttMnesaje.SetToolTip(this.txtTelefono, "Ingrese el numero de telefono");
            ttMnesaje.SetToolTip(this.txtEmail, "Ingrese la direccion de Email");
            ttMnesaje.SetToolTip(this.txtUsuario, "Ingrese su usuario");
            ttMnesaje.SetToolTip(this.txtPassword, "Ingrese su contraseña");
        }

        public void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje,"SISTEMA DE VENTA",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        public void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "SISTEMA DE VENTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtNumDoc.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
        }

        public void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        public void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtApellidos.ReadOnly = !valor;
            this.txtNumDoc.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtUsuario.ReadOnly = !valor;
            this.txtPassword.ReadOnly = !valor;
            this.cbSexo.Enabled = valor;
            this.cbTipDoc.Enabled = valor;
            this.dtFechaNac.Enabled = valor;
            this.cbAcceso.Enabled = valor;
        }

        public void Botones()
        {
            if(this.Is_Nuevo || this.Is_Editar)
            {
                Habilitar(true);
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
            }else
            {
                Habilitar(false);
                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
            }
        }

        public void Mostar()
        {
            this.dataListado.DataSource = NTrabajador.Mostrar();
            OcultarColumnas();
            this.lblTotal.Text = "El numero de registros es: " + Convert.ToString(dataListado.Rows.Count);
        }

        public void BuscarApellido()
        {
            this.dataListado.DataSource = NTrabajador.BuscarApellido(txtBuscar.Text);
            OcultarColumnas();
            this.lblTotal.Text = "El numero de registros es: " + Convert.ToString(dataListado.Rows.Count);
        }

        public void BuscarDocumento()
        {
            this.dataListado.DataSource = NTrabajador.BuscarDocumento(txtBuscar.Text);
            OcultarColumnas();
            this.lblTotal.Text = "El numero de registros es: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void frmTrabajador_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            Mostar();
            Botones();
            Habilitar(false);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.cbBuscar.Text.Equals("APELLIDOS"))
            {
                BuscarApellido();
            }else
            {
                if (this.cbBuscar.Text.Equals("DOCUMENTOS"))
                {
                    BuscarDocumento();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Esta seguro que desea eliminar el registro", "SISTEMA DE VENTAS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if(opcion == DialogResult.OK)
                {
                    string rpta = "";
                    string codigo;

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo=Convert.ToString( row.Cells[1].Value);
                            rpta = NTrabajador.Eliminar(Convert.ToInt32(codigo));
                            if (rpta == "OK")
                            {
                                MensajeOK("el registro ha sido eliminado de forma correcta");
                            }
                            else
                            {
                                MensajeError(rpta);
                            }
                        }
                            
                    }

                    this.Mostar();
                    
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chkEliminar.Checked==true)
            {
                this.dataListado.Columns[0].Visible = true;
            }else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Is_Nuevo = true;
            Is_Editar = false;
            Habilitar(true);
            Botones();
           
            Limpiar();
            txtNombre.Focus();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                //e.RowIndex la fila qye hemos modificado nos retona la informacion
                DataGridViewCheckBoxCell ch = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ch.Value = !Convert.ToBoolean(ch.Value);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (txtNombre.Text==string.Empty || txtApellidos.Text==string.Empty|| txtNumDoc.Text == string.Empty || txtDireccion.Text == string.Empty || txtTelefono.Text == string.Empty || txtEmail.Text == string.Empty || txtUsuario.Text == string.Empty || txtPassword.Text == string.Empty)
                {
                    MensajeError("Introdusca los campos faltantes");
                    errorIcono.SetError(txtNombre, "Ingresa el nombre");
                    errorIcono.SetError(txtApellidos, "Ingresa el Apellido");
                    errorIcono.SetError(txtNumDoc, "Ingresa el numero de docuemnto");
                    errorIcono.SetError(txtDireccion, "Ingresa la direccion");
                    errorIcono.SetError(txtTelefono, "Ingresa el Telefono");
                    errorIcono.SetError(txtEmail, "Ingresa el Email");
                    errorIcono.SetError(txtUsuario, "Ingresa el Ussuario");
                    errorIcono.SetError(txtPassword, "Ingresa la Contraseña");
                }else
                {
                    if(this.Is_Nuevo == true)
                    {
                        rpta = NTrabajador.Insertar(txtNombre.Text, txtApellidos.Text, cbSexo.Text, dtFechaNac.Value, txtNumDoc.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text, cbAcceso.Text, txtUsuario.Text, txtPassword.Text);

                    }else
                    {
                        rpta = NTrabajador.Editar(Convert.ToInt32(txtIdTrabajador.Text),txtNombre.Text, txtApellidos.Text, cbSexo.Text, dtFechaNac.Value, txtNumDoc.Text, txtDireccion.Text, txtTelefono.Text, txtEmail.Text, cbAcceso.Text, txtUsuario.Text, txtPassword.Text);

                    }
                    if (rpta == "OK")
                    {
                        if (this.Is_Nuevo == true)
                        {
                            this.MensajeOK("Se ha guardado de forma correcta el registro");
                        }else
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
                Mostar();
                Limpiar();
                Botones();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdTrabajador.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idtrabajador"].Value);
            this.txtNombre.Text= Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtApellidos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellido"].Value);
            this.cbSexo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sexo"].Value);
            this.dtFechaNac.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha_nac"].Value);
            this.txtNumDoc.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["num_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.cbAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["acceso"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["usuario"].Value);
            this.txtPassword.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["password"].Value);

            tabControl1.SelectedIndex = 1;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdTrabajador.Text.Equals(""))
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
            this.txtIdTrabajador.Text = string.Empty;
        }
    }
}
