using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LojaABC
{
    public partial class frmFuncionarios : Form
    {
        public frmFuncionarios()
        {
            InitializeComponent();
            desativarCampos();
        }

        //desativar campos
        public void desativarCampos()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            mskCEP.Enabled = false;
            mskCPF.Enabled = false;
            cbbEstado.Enabled = false;
            dtpNascimento.Enabled = false;

            btnCadastrar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = false;
            btnAlterar.Enabled = false;
        }

        //ativando os campos
        public void ativarCampos()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            mskCEP.Enabled = true;
            mskCPF.Enabled = true;
            cbbEstado.Enabled = true;
            dtpNascimento.Enabled = true;

            btnCadastrar.Enabled = true;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = true;
            btnAlterar.Enabled = false;
            btnPesquisar.Enabled = false;

            txtNome.Focus();
        }
        public void limparCampos()
        {
            txtNome.Clear();
            txtEndereco.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            mskCEP.Clear();
            mskCPF.Clear();
            cbbEstado.Enabled = true;
            dtpNascimento.Enabled = true;
            txtNome.Focus();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisar abrir = new frmPesquisar();
            abrir.Show();

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ativarCampos();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btnCarregaCEP_Click(object sender, EventArgs e)
        {
            WSCorreios.AtendeClienteClient ws = new WSCorreios.AtendeClienteClient();

            WSCorreios.enderecoERP endereco = ws.consultaCEP(mskCEP.Text);

            txtEndereco.Text = endereco.end;
            txtBairro.Text = endereco.bairro;
            txtCidade.Text = endereco.cidade;
            cbbEstado.Text = endereco.uf;

        }

        private void btnTestaBanco_Click(object sender, EventArgs e)
        {
            Conexao.obterConexao();

            MessageBox.Show("Aberto");

            Conexao.fecharConexao();

            MessageBox.Show("Fechado");
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

        }
        
        //Cadastrar funcionarios
        public void cadastrarFuncionarios()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "insert into tbFuncionarios" +
                "(nome,cpf,dataNasc,endereco,numero,bairro,cidade,siglaEst,cep)" +
                "values(@nome,@cpf,@dataNasc,@endereco,@numero,@bairro,@cidade,@siglaEst,@cep);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome",MySqlDbType.VarChar,100).Value = txtNome.Text;
            
            comm.Connection = Conexao.obterConexao();

            comm.ExecuteNonQuery();

            Conexao.fecharConexao();




        }

    }
}
