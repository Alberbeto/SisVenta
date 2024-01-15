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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            //EL TIMEPO ALTUAL
            lblHora.Text = DateTime.Now.ToString();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable dt = NTrabajador.Login(this.txtUsuario1.Text, this.txtPassword1.Text);
            //Evaluar Si existe el usuario

            if(dt.Rows.Count == 0) {

                MessageBox.Show("No tiene Acceso al sistema", "SISTEMA DE VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
            {
                frmPrincipal frm = new frmPrincipal();
                frm.Idtrabajador = dt.Rows[0][0].ToString();
                frm.Apellidos= dt.Rows[0][1].ToString();
                frm.Nombre= dt.Rows[0][2].ToString();
                frm.Acceso= dt.Rows[0][3].ToString();


                frm.Show();
                this.Hide();
            }
        }
    }
}
