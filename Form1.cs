using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            CarregarDados();
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
                MessageBox.Show("Salvo com sucessao!");
            }
                    catch(Exception ex)
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
            cmbTipo.Items.Add("Entrada");
            cmbTipo.Items.Add("Saída");
            cmbTipo.SelectedIndex = 0;
            CarregarDados();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}