using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaABC
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            bool validaUsu = validarUsuario(txtUsuario.Text, txtSenha.Text);

            if (validaUsu == true)
            {
                frmMenuPrincipal abrir = new frmMenuPrincipal();
                abrir.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos!!!",
                "Mensagem do sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                txtUsuario.Text = "";
                txtSenha.Clear();
                txtUsuario.Focus();
            }
        }

        public bool validarUsuario(string usuario, string senha)
        {
            if (usuario.Equals("senac") && senha.Equals("senac"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            //Close();
            //this.Close();
            DialogResult dr = MessageBox.Show("Deseja sair?",
                "Mensagem do sistema",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button3);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                txtUsuario.Focus();
            }
        }
    }
}
