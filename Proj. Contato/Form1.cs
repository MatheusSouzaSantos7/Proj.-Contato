using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Proj.Contato
{
    public partial class Form1 : Form
    {
        private Contatos agenda = new Contatos();

        // Componentes dinâmicos
        private TextBox txtNome, txtEmail, txtDia, txtMes, txtAno, txtTelefone;
        private ListBox listBoxContatos;
        private Button btnAdicionar, btnPesquisar, btnAlterar, btnRemover, btnListar, btnSair;

        public Form1()
        {
            InitializeComponent();
            CriarInterface();
        }

        private void CriarInterface()
        {
            // Labels
            CriarLabel("Nome:", new Point(20, 20));
            CriarLabel("Email:", new Point(20, 60));
            CriarLabel("Data de Nascimento (Dia/Mês/Ano):", new Point(20, 100));
            CriarLabel("Telefone principal:", new Point(20, 140));

            // Textboxes
            txtNome = CriarTextBox(new Point(200, 20));
            txtEmail = CriarTextBox(new Point(200, 60));
            txtDia = CriarTextBox(new Point(220, 100), 30);
            txtMes = CriarTextBox(new Point(260, 100), 30);
            txtAno = CriarTextBox(new Point(300, 100), 50);
            txtTelefone = CriarTextBox(new Point(200, 140), 150);

            // ListBox para exibir os contatos
            listBoxContatos = new ListBox()
            {
                Location = new Point(20, 180),
                Size = new Size(850, 150)
            };
            Controls.Add(listBoxContatos);

            // Botões dinâmicos
            btnAdicionar = CriarBotao("Adicionar", new Point(20, 350), btnAdicionar_Click);
            btnPesquisar = CriarBotao("Pesquisar", new Point(130, 350), btnPesquisar_Click);
            btnAlterar = CriarBotao("Alterar", new Point(240, 350), btnAlterar_Click);
            btnRemover = CriarBotao("Remover", new Point(350, 350), btnRemover_Click);
            btnListar = CriarBotao("Listar", new Point(20, 400), btnListar_Click);
            btnSair = CriarBotao("Sair", new Point(130, 400), btnSair_Click);
        }

        // Método auxiliar para criar labels
        private void CriarLabel(string texto, Point posicao)
        {
            Label lbl = new Label()
            {
                Text = texto,
                Location = posicao,
                AutoSize = true
            };
            Controls.Add(lbl);
        }

        // Método auxiliar para criar caixas de texto
        private TextBox CriarTextBox(Point posicao, int largura = 150)
        {
            TextBox txt = new TextBox()
            {
                Location = posicao,
                Size = new Size(largura, 20)
            };
            Controls.Add(txt);
            return txt;
        }

        // Método auxiliar para criar botões
        private Button CriarBotao(string texto, Point posicao, EventHandler eventoClick)
        {
            Button btn = new Button()
            {
                Text = texto,
                Location = posicao,
                Size = new Size(100, 30) // Definindo tamanho fixo para todos os botões
            };
            btn.Click += eventoClick;
            Controls.Add(btn);
            return btn;
        }

        // Função do botão Sair
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Função do botão Adicionar
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                // Coleta as informações dos campos de texto
                string nome = txtNome.Text;
                string email = txtEmail.Text;
                Data dataNasc = new Data(int.Parse(txtDia.Text), int.Parse(txtMes.Text), int.Parse(txtAno.Text));
                Telefone telefone = new Telefone(txtTelefone.Text, true);

                // Cria o contato com o telefone principal e o adiciona à agenda
                Contato contato = new Contato(nome, email, dataNasc, telefone);
                if (agenda.adicionar(contato))
                    MessageBox.Show("Contato adicionado com sucesso!");
                else
                    MessageBox.Show("Falha ao salvar");

                // Atualiza a lista de contatos no ListBox
                AtualizarListaContatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar contato: " + ex.Message);
            }
        }

        // Função do botão Pesquisar
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            Contato c = agenda.pesquisar(new Contato(nome, "", new Data()));
            if (c != null)
            {
                MessageBox.Show("Contato encontrado:\n" + c.ToString());
            }
            else
            {
                MessageBox.Show("Contato não encontrado.");
            }
        }

        // Função do botão Alterar
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                string email = txtEmail.Text;
                Data dataNasc = new Data(int.Parse(txtDia.Text), int.Parse(txtMes.Text), int.Parse(txtAno.Text));
                Telefone telefone = new Telefone(txtTelefone.Text, true);

                Contato c = new Contato(nome, email, dataNasc, telefone);
                bool alterado = agenda.Alterar(c);
                if (alterado)
                {
                    MessageBox.Show("Contato alterado com sucesso.");
                    AtualizarListaContatos();
                }
                else
                {
                    MessageBox.Show("Contato não encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar contato: " + ex.Message);
            }
        }

        // Função do botão Remover
        private void btnRemover_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            Contato c = agenda.pesquisar(new Contato(nome, "", new Data()));
            if (c != null)
            {
                bool removido = agenda.remover(c);
                if (removido)
                {
                    MessageBox.Show("Contato removido com sucesso.");
                    AtualizarListaContatos();
                }
            }
            else
            {
                MessageBox.Show("Contato não encontrado.");
            }
        }

        // Função do botão Listar
        private void btnListar_Click(object sender, EventArgs e)
        {
            AtualizarListaContatos();
        }

        // Método auxiliar para atualizar a ListBox com os contatos da agenda
        private void AtualizarListaContatos()
        {
            listBoxContatos.Items.Clear(); // Limpa a lista atual

            // Acessa a lista de contatos usando o método Listar()
            foreach (var contato in agenda.Listar())
            {
                listBoxContatos.Items.Add(contato.ToString()); // Adiciona os contatos ao ListBox
            }
        }
    }
}
