using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gerenciador_financeiro_csharp
{
    public partial class Form1 : Form
    {
        private TransacaoRepository repo = new TransacaoRepository();
        public Form1()
        {
            InitializeComponent();
        }
        private void CarregarDados()
        {
            dgvTransacoes.DataSource = repo.Listar();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Receita");
            cmbTipo.Items.Add("Despesa");
            cmbTipo.SelectedIndex = 0;

            CarregarDados();
            AtualizarSaldo();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Digite a descrição!");
                    return;

                }
                if (!decimal.TryParse(textBox2.Text, out decimal valor))
                {

                    MessageBox.Show("Digite um valor válido!");
                    return;
                }
                if (cmbTipo.SelectedItem == null)
                {
                    MessageBox.Show("Selecione um tipo!");
                    return;
                }

                Transacao t = new Transacao
                {
                    Descricao = textBox1.Text,
                    Valor = valor,
                    Tipo = cmbTipo.Text,
                    Data = DateTime.Now
                };
                repo.Adicionar(t);
                CarregarDados();
                AtualizarSaldo();
                MessageBox.Show("Salvo com sucessao!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
        private void dgvTransacoes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Receita");
            cmbTipo.Items.Add("Despesa");
            cmbTipo.SelectedIndex = 0;
            CarregarDados();
            AtualizarSaldo();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void AtualizarSaldo()
        {
            decimal total = 0;

            DataTable tabela = repo.Listar();

            foreach (DataRow row in tabela.Rows)
            {
                if (row["valor"] != DBNull.Value && row["tipo"] != DBNull.Value)
                {
                    decimal valor = Convert.ToDecimal(row["valor"]);
                    string tipo = row["tipo"].ToString();

                    if (tipo == "Receita")
                        total += valor;
                    else if (tipo == "Despesa")
                        total -= valor;
                }
            }

            lblSaldo.Text = "Saldo: " + total.ToString("C2");

            lblSaldo.ForeColor = total >= 0 ? Color.Green : Color.Red;
        }
        private void lblSaldo_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvTransacoes.CurrentRow == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }
            var confirm = MessageBox.Show(
                "Deseja excluir essa transação?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (confirm == DialogResult.No)
                return;
            
                int id = Convert.ToInt32(dgvTransacoes.CurrentRow.Cells["id"].Value);
                repo.Deletar(id);
                CarregarDados();
                AtualizarSaldo();
                MessageBox.Show("Excluido");
            }

        }
    }

