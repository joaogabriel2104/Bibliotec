using Exemplo_GriedView.Logica;
using Exemplo_GriedView.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exemplo_GriedView
{
    public partial class frm_Cliente : Form
    {
        public frm_Cliente()
        {
            InitializeComponent();
        }

        public Usuario Usuario1 { get; set; }
        public bool Cliente { get; set; }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            tblResultado.Rows.Clear();
            tblLivros.Rows.Clear();
            btnDevolver.Enabled = false;
            lblEmprestimos.Visible = false;
            lblNenhumLivro.Visible = false;
            string busca = "";
            busca = txtBusca.Text;
            ListaCliente listacliente = new ListaCliente();

            listacliente.busca = txtBusca.Text;
            listacliente.Listar();

            for (int i = 0; i < listacliente.Lista.Count; i++)
            {
                if (listacliente.Lista[i].Bloqueado == false)
                {
                    tblResultado.Rows.Add(listacliente.Lista[i].Login, listacliente.Lista[i].Nome, listacliente.Lista[i].Tipo.Nome, listacliente.Lista[i].Bloqueado);
                }
                else
                {
                    tblResultado.Rows.Add(listacliente.Lista[i].Login, listacliente.Lista[i].Nome, listacliente.Lista[i].Tipo.Nome, listacliente.Lista[i].Bloqueado, listacliente.Lista[i].DataBloqueio);
                }
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            ListaCliente listacliente = new ListaCliente();
            string login = "";
            if (tblResultado.Rows.Count > 0)
            {
                bool Checado = bool.Parse(tblResultado.Rows[tblResultado.CurrentRow.Index].Cells[3].Value.ToString());
                if (Checado == false)
                {
                    login = tblResultado.Rows[tblResultado.CurrentRow.Index].Cells[0].Value.ToString();
                    Usuario usuario = new Usuario();
                    usuario.Login = login;
                    Usuario1 = usuario;
                    Cliente = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Pessoa bloqueada!");
                }
            }
            else
            {
                MessageBox.Show("Nenhuma pessoa selecionada!");
            }
        }

        private void tblResultado_SelectionChanged(object sender, EventArgs e)
        {
            tblLivros.Rows.Clear();
            btnDevolver.Enabled = false;
            lblEmprestimos.Visible = true;
            string login = tblResultado.Rows[tblResultado.CurrentRow.Index].Cells[0].Value.ToString();
            ListaCliente listacliente = new ListaCliente();
            ListaEmprestimo listaemprestimo = new ListaEmprestimo();
            listaemprestimo.LivrosEmprestados(login);

            if (listaemprestimo.ListaEmprestados.Count > 0)
            {
                tblLivros.Visible = true;
                lblNenhumLivro.Visible = false;

                for (int i = 0; i < listaemprestimo.ListaEmprestados.Count; i++)
                {
                    tblLivros.Rows.Add(listaemprestimo.ListaEmprestados[i].Livro.Codigo, listaemprestimo.ListaEmprestados[i].Livro.Titulo, listaemprestimo.ListaEmprestados[i].Exemplar.Codigo, listaemprestimo.ListaEmprestados[i].DataEmprestimo, listaemprestimo.ListaEmprestados[i].HoraEmprestimo, listaemprestimo.ListaEmprestados[i].Tipo.Nome, listaemprestimo.ListaEmprestados[i].DataDevolucaoEstimada, listaemprestimo.ListaEmprestados[i].DataDevolucao);
                }
            }
            else
            {
                lblNenhumLivro.Visible = true;
                tblLivros.Visible = false;
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            Devolução devolucao = new Devolução();
            Usuario usuario = new Usuario();
            Livro livro = new Livro();
            Exemplar exemplar = new Exemplar();
            Emprestimo emprestimo = new Emprestimo();

            usuario.Login = tblResultado.Rows[tblResultado.CurrentRow.Index].Cells[0].Value.ToString();
            livro.Codigo = int.Parse(tblLivros.Rows[tblLivros.CurrentRow.Index].Cells[0].Value.ToString());
            exemplar.Codigo = int.Parse(tblLivros.Rows[tblLivros.CurrentRow.Index].Cells[2].Value.ToString());
            DateTime dataEmprestimo = DateTime.Parse(tblLivros.Rows[tblLivros.CurrentRow.Index].Cells[3].Value.ToString());
            emprestimo.DataEmprestimo = dataEmprestimo.ToString("yyyy-MM-dd");
            devolucao.Devolucao(livro, exemplar, usuario);

            int index = int.Parse(tblLivros.CurrentRow.Index.ToString());
            tblLivros.Rows.RemoveAt(index);
            MessageBox.Show("Livro devolvido com sucesso!");
            if (MessageBox.Show("Deseja fazer uma ocorrência?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                frm_Ocorrência ocorrencia = new frm_Ocorrência(usuario, livro, exemplar, emprestimo);
                ocorrencia.ShowDialog();
            }
        }

        private void tblLivros_SelectionChanged(object sender, EventArgs e)
        {
            if (tblLivros.Rows.Count != 0)
            {
                btnDevolver.Enabled = true;
            }
            else
            {
                btnDevolver.Enabled = false;
            }
        }
    }
}
