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
    public partial class frmPresentacion : Form
    {
        public bool IsNuevo=false;
        public bool IsEditar = false;
        public frmPresentacion()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre de la presentacion");
        }
        public void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje,"Sistema de ventas",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        public void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtIdPresentacion.Text = string.Empty;  
        }

        public void Habilitar(bool valor)
        {
            //solo lectura
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtIdPresentacion.ReadOnly = !valor;
        }

        public void botones()
        {
            if(this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;
            }else
            {

                this.Habilitar(false);
                btnNuevo.Enabled=true; 
                btnGuardar.Enabled=false;
                btnEditar.Enabled=true;
                btnCancelar.Enabled=false;

            }
        }

        public void OcultarColumnas()
        {
            this.dtListado.Columns[0].Visible = false;
            this.dtListado.Columns[1].Visible = false;
        }

        public void Mostrar() 
        {
            this.dtListado.DataSource = nPresentacion.Mostrar();
            this.OcultarColumnas();
            lblTexto.Text = "Total de Resgistro: " + Convert.ToString(dtListado.Rows.Count);
        
        
        }
        public void BuscarNombre()
        {
            this.dtListado.DataSource = nPresentacion.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTexto.Text = "Total de Resgistro " + Convert.ToString(dtListado.Rows.Count);


        }

        private void frmPresentacion_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.botones();
            this.Habilitar(false);
            this.Mostrar();
           
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
            this.botones();
            this.Limpiar();
            this.Habilitar(true);
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if(txtNombre.Text == string.Empty)
                {
                    MensajeError("falta registrar algunos datos, seran remarcados ");
                    errorIcono.SetError(txtNombre, "ingrese nombre");
                }
                else
                {

                    if (this.IsNuevo)
                    {
                        rpta = nPresentacion.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim().ToUpper());

                    }
                    else
                    {
                        rpta = nPresentacion.Editar(Convert.ToInt32(this.txtIdPresentacion.Text), this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim().ToUpper());
                    }

                    if(rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("se inserto de forma correcta");
                        }else
                        {
                            this.MensajeOk("se edito de forma correcta");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                        
                    }
                }
                
                this.IsNuevo = false;
                this.IsEditar = false;
                this.botones();
                this.Limpiar();
                this.Mostrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dtListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdPresentacion.Text =Convert.ToString( this.dtListado.CurrentRow.Cells["idpresentacion"].Value);
            this.txtNombre.Text = Convert.ToString(this.dtListado.CurrentRow.Cells["Nombre"].Value);
            this.txtDescripcion.Text= Convert.ToString(this.dtListado.CurrentRow.Cells["Descripcion"].Value);

            tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdPresentacion.Text.Equals(""))
            {
                this.IsEditar= true;
                this.botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe seleccionar primero el registro a modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Habilitar(false);
            this.botones();
            this.Limpiar();
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if(chkEliminar.Checked)
            {
                this.dtListado.Columns[0].Visible = true;
            }else
            {
                this.dtListado.Columns[0].Visible = false;
            }
        }

        private void dtListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
            if (dtListado.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                //para determinar cua es check box q se ha seleccionado
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dtListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("esat seguro que desea eliminar el registro", "SISTEMA DE VENTAS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(opcion == DialogResult.OK)
                {
                    string codigo;
                    string rpta = "";

                    foreach(DataGridViewRow row in dtListado.Rows)
                    {
                        //recorre fila por fila para ver si es verdadero
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            rpta = nPresentacion.Eliminar(Convert.ToInt32(codigo));

                            if (rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se elimino correctamente el registro");
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dtListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("CellClick");
        }

        private void dtListado_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("CellEnter");
        }
    }
}
