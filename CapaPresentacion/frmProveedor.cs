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
    public partial class frmProveedor : Form
    {   
       private  bool Is_Nuevo=false;
        private bool Is_Editar =false;
        public frmProveedor()
        {
            InitializeComponent();
            this.ttMnesaje.SetToolTip(this.txtRazonSocial, "Escribe tu razon social");
            this.ttMnesaje.SetToolTip(this.txtNumDocumento, "Ingrese numero de documento del Proveedor ");
            this.ttMnesaje.SetToolTip(this.txtDireccion, "Ingrese la direccion de Proveedor");


        }

        public void MensajeDeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "SISTEMA DE VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Limpiar()
        {
            this.txtRazonSocial.Text = string.Empty;
            this.txtNumDocumento.Text = string.Empty;   
            this.txtDireccion.Text = string.Empty;  
            this.txtTelefono.Text = string.Empty;
            this.txtUrl.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
        }

        //LAS CAJAS DE TEXTO SOLO LECTURA
        public void Habilitar(bool valor)
        {
            this.txtRazonSocial.ReadOnly = !valor;
            this.txtNumDocumento.ReadOnly = !valor;
            this.txtDireccion.ReadOnly= !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtUrl.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.cbSector_Comercial.Enabled = valor;
            this.cbTipo_Documento.Enabled = valor;
            this.txtIdProveedor.ReadOnly = !valor;

        }

        public void Botones()
        {
            //CUANDO SE REQALZIA EL CLICK PO Q LO BOTONES YA VIENE POR DEFAULT HABILITADOS
            if(this.Is_Nuevo || this.Is_Editar)
            {
                Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }else
            {
                Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        public void OcultarColumnas()

            //Ocultar las columans indicando el indice 
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
                
        }

        public void Mostrar()
        {
            //TRAER TODA LA FUENTE DE DATOS
            this.dataListado.DataSource = NProveedor.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total de Registros " +Convert.ToString (dataListado.Rows.Count);
        }

        public void BuscarRazonSocial()
        {
            this.dataListado.DataSource = NProveedor.BuscarRazonSocial(this.txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total de Registros" + Convert.ToString(this.dataListado.Rows.Count);

        }

        public void BuscarDocumento()
        {
            this.dataListado.DataSource = NProveedor.BuscarNumDocumento(this.txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total de Registro " + Convert.ToString(this.dataListado.Rows.Count);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(cbBuscar.Text.Equals("Razon Social"))
            {
                this.BuscarRazonSocial();
            }else if(cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarDocumento();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Realmente desea eliminiar el registro", "SISTEMA DE VENTAS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question); ;

                if (opcion == DialogResult.OK)
                {
                    string codigo;
                    string rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {

                            codigo = Convert.ToString(row.Cells[1].Value);
                            rpta = NProveedor.Eliminar(Convert.ToInt32(codigo));

                            if (rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se elimino correctamente el registro");
                            }
                            else
                            {
                                this.MensajeDeError(rpta);
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
            }else
            {
                this.dataListado.Columns[1].Visible = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
           this.Is_Nuevo= true;
           this.Is_Editar= false;
            Botones();
            Habilitar(true);
            Limpiar();
            txtRazonSocial.Focus();

        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
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
                if(txtRazonSocial.Text == string.Empty || this.txtNumDocumento.Text== string.Empty || this.txtDireccion.Text == string.Empty)
                {
                    MensajeDeError("Ingrese campo obligatorio");
                    errorIcono.SetError(txtRazonSocial, "ingrese razon social");
                    errorIcono.SetError(txtNumDocumento, "ingrese Numero de documeto");
                    errorIcono.SetError(txtDireccion, "ingrese Direccion");
                }
                else
                {
                    if (this.Is_Nuevo==true){

                        rpta = NProveedor.Insertar(this.txtRazonSocial.Text.Trim().ToUpper(),this.cbSector_Comercial.Text, this.cbTipo_Documento.Text, this.txtNumDocumento.Text, this.txtDireccion.Text,txtTelefono.Text, this.txtEmail.Text, this.txtUrl.Text);
                    }else
                    {
                        rpta = NProveedor.Editar(Convert.ToInt32(this.txtIdProveedor.Text)  ,this.txtRazonSocial.Text.Trim().ToUpper(), this.cbSector_Comercial.Text, this.cbTipo_Documento.Text, this.txtNumDocumento.Text, this.txtDireccion.Text, txtTelefono.Text, this.txtEmail.Text, this.txtUrl.Text);

                    }

                    if(rpta == "OK")
                    {
                        if (this.Is_Nuevo == true)
                        {
                            this.MensajeOk("Se inserto correctamente el regitstro");
                        }
                        else
                        {
                            this.MensajeOk("Se Guardo correctamente el rtegistro");
                        }
                    }else
                    {
                        MensajeDeError(rpta);
                    }
                }

                this.Is_Nuevo= false;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdProveedor.Text.Equals(""))
            {
                this.Is_Editar= true;
                this.Botones();
                this.Habilitar(true);

            }else
            {
                this.MensajeDeError("Debe de seleccionar primnero el registro a modificas");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Is_Nuevo = false;
            this.Is_Editar = false;
            this.Botones();
            this.Limpiar(); 
            this.txtIdProveedor.Text=string.Empty;
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdProveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idproveedor"].Value);
            this.txtRazonSocial.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["razon_social"].Value);
            this.cbSector_Comercial.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sector_comercial"].Value);
            this.cbTipo_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_documento"].Value);
            this.txtNumDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["num_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.txtUrl.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["url"].Value);






            tabControl1.SelectedIndex = 1;
        }
    }
}
