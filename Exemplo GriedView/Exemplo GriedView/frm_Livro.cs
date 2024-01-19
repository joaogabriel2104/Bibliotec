using Exemplo_GriedView.Logica;
using Exemplo_GriedView.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exemplo_GriedView
{
    public partial class frm_Livro : Form
    {
        public frm_Livro()
        {
            InitializeComponent();
        }

        #region Buscar Livros
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            tblResultado.Rows.Clear();
            ListaLivro listalivro = new ListaLivro();

            listalivro.busca = txtBusca.Text;
            listalivro.Listar();

            for (int i = 0; i < listalivro.Lista.Count; i++)
            {
                tblResultado.Rows.Add(listalivro.Lista[i].Codigo, listalivro.Lista[i].ISBN, listalivro.Lista[i].Titulo, listalivro.Lista[i].Editora.Nome);
            }
        }
        #endregion

        #region Detalhes Livro
        private void tblResultado_SelectionChanged(object sender, EventArgs e)
        {
            ListaLivro listalivro = new ListaLivro();
            listalivro.Livro = new Livro();

            listalivro.Livro.Codigo = int.Parse(tblResultado.Rows[tblResultado.CurrentRow.Index].Cells[0].Value.ToString());

            btnEmprestar.Enabled = false;
            lblLocalizacao.Text = "";
            chkFixo.Checked = false;
            chkFixo.Enabled = false;

            string autores = "";
            string categorias = "";

            listalivro.Detalhes();
            var listaexemplares = listalivro.ListaExemplaresDisponiveis(listalivro.Livro);

            lblTitulo.Text = listalivro.UmLivro.Titulo.ToString();
            lblCodigo.Text = listalivro.UmLivro.Codigo.ToString();
            lblISBN.Text = listalivro.UmLivro.ISBN.ToString();
            lblEditora.Text = listalivro.UmLivro.Editora.Nome;
            lblEdição.Text = listalivro.UmLivro.AnoEdicao.ToString();
            lblAutores.Text = null;
            for (int a = 0; a < listalivro.UmLivro.Autor.Count; a++)
            {
                autores += listalivro.UmLivro.Autor[a].Nome + ", ";
            }
            autores = autores.Substring(0, autores.Length - 2);
            lblAutores.Text = autores;
            lblSinopse.Text = listalivro.UmLivro.Sinopse.ToString();
            #region Foto de Capa
            if (!String.IsNullOrEmpty(listalivro.UmLivro.Capa))
            {
                byte[] imageBytes = Convert.FromBase64String(listalivro.UmLivro.Capa);
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    pcbCapa.Image = Image.FromStream(ms, true);
                }
            }
            else
            {
                pcbCapa.Image = null;
            }
            #endregion
            lblCategoria.Text = null;
            for (int a = 0; a < listalivro.UmLivro.Categoria.Count; a++)
            {
                categorias += listalivro.UmLivro.Categoria[a].Nome + ", ";
            }
            categorias = categorias.Substring(0, categorias.Length - 2);
            lblCategoria.Text = categorias;
            lstExemplares.Items.Clear();
            for (int a = 0; a < listaexemplares.Count; a++)
            {
                lstExemplares.Items.Add(listaexemplares[a].Codigo);
            }
            var listaexemplaresemprestados = listalivro.Disponibilidade(listalivro.Livro);
            lblDisponibilidade.Text = listaexemplares.Count.ToString() + "/" + listaexemplaresemprestados.Count.ToString();
        }
        #endregion

        #region Botão emprestar habilitado ou não
        private void lstExemplares_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaLivro listalivro = new ListaLivro();
            listalivro.UmExemplar = new Exemplar();

            if (lstExemplares.SelectedItem != null)
            {
                btnEmprestar.Enabled = true;
                string ExemplarSelecionado = lstExemplares.SelectedItem.ToString();

                Livro livro = new Livro();
                Exemplar exemplar = new Exemplar();

                livro.Codigo = int.Parse(tblResultado.Rows[tblResultado.CurrentRow.Index].Cells[0].Value.ToString());
                exemplar.Codigo = int.Parse(ExemplarSelecionado);

                listalivro.DadosExemplar(livro, exemplar);

                lblLocalizacao.Text = listalivro.UmExemplar.Localizacao.Nome.ToString();
                chkFixo.Checked = listalivro.UmExemplar.Fixo;
                if(chkFixo.Checked == true)
                {
                    chkFixo.Enabled = false;
                }
                else
                {
                    chkFixo.Enabled = true;
                }
            }
            else
            {
                chkFixo.Enabled = false;
                btnEmprestar.Enabled = false;
            }
        }
        #endregion

        #region Usuario
        private void btnIcon_Click(object sender, EventArgs e)
        {
            frm_Cliente cliente = new frm_Cliente();
            ListaCliente listacliente = new ListaCliente();
            cliente.ShowDialog();

            if(cliente.Cliente == true)
            {
                Usuario usuario = new Usuario();

                lblCodigoCliente.Text = cliente.Usuario1.Login;
                usuario.Login = cliente.Usuario1.Login;
                listacliente.NomeCli(usuario);

                lblCliente.Text = listacliente.Usuario1.Nome;
            }
            else
            {
                lblCodigoCliente.Text = "";
                lblCliente.Text = "Cliente não identificado";
            }
        }
        #endregion

        #region Emprestar
        private void btnEmprestar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblCodigoCliente.Text))
            {
                ListaEmprestimo listaemprestimo = new ListaEmprestimo();

                listaemprestimo.LivrosEmprestadosSemConsulta(lblCodigoCliente.Text);
                int LivrosEmprestadosSemConsulta = listaemprestimo.ListaEmprestados.Count;
                listaemprestimo.LivrosEmprestadosComConsulta(lblCodigoCliente.Text);
                int LivrosEmprestadosComConsulta = listaemprestimo.ListaEmprestados.Count;

                bool Emprestar = false;

                if(LivrosEmprestadosSemConsulta > 2)
                {
                    if(LivrosEmprestadosComConsulta < 1)
                    {
                        if(chkFixo.Checked == true)
                        {
                            Emprestar = true;
                        }
                        else
                        {
                            Emprestar = false;
                        }
                    }
                    else
                    {
                        Emprestar = false;
                    }
                }
                else
                {
                    if(chkFixo.Checked == false)
                    {
                        Emprestar = true;
                    }
                    else
                    {
                        if (LivrosEmprestadosComConsulta < 1)
                        {
                            Emprestar = true;
                        }
                        else
                        {
                            Emprestar = false;
                        }
                    }
                }

                if (Emprestar == true)
                {
                    btnEmprestar.Enabled = false;

                    String ExemplarSelecionado = lstExemplares.SelectedItem.ToString();
                    int index = lstExemplares.SelectedIndex;
                    lstExemplares.Items.RemoveAt(index);

                    string Disponibilidade = lblDisponibilidade.Text.Substring(0, 1).ToString();
                    string Total = lblDisponibilidade.Text.Substring(2, 1).ToString();
                    int Disponivel = int.Parse(Disponibilidade) - 1;
                    lblDisponibilidade.Text = Disponivel.ToString() + "/" + Total;


                    int ChkFixo = 0;
                    if (chkFixo.Checked == true)
                    {
                        ChkFixo = 1;
                    }
                    else
                    {
                        ChkFixo = 2;
                    }

                    Usuario usuario = new Usuario();
                    Exemplar exemplar = new Exemplar();
                    TipoEmprestimo tipoEmprestimo = new TipoEmprestimo();
                    Emprestimo emprestimo = new Emprestimo();
                    Livro livro = new Livro();

                    usuario.Login = lblCodigoCliente.Text;
                    exemplar.Codigo = int.Parse(ExemplarSelecionado);
                    livro.Codigo = int.Parse(tblResultado.Rows[tblResultado.CurrentRow.Index].Cells[0].Value.ToString());
                    tipoEmprestimo.Codigo = int.Parse(ChkFixo.ToString());

                    listaemprestimo.Empréstimo(usuario, exemplar, livro, tipoEmprestimo);
                    MessageBox.Show("Livro emprestado com sucesso!");
                    if (MessageBox.Show(lblCliente.Text + " deseja fazer mais um empréstimo?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        lblCliente.Text = "Cliente não identificado";
                        lblCodigoCliente.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Usuário excedeu o limite de empréstimos!");
                }
            }
            else
            {
                MessageBox.Show("Cliente não identificado!");
            }
        }
        #endregion

        #region Tirar Cliente
        private void btnTirarCliente_Click(object sender, EventArgs e)
        {
            lblCodigoCliente.Text = "";
            lblCliente.Text = "Cliente não identificado";
        }
        #endregion
    }
}
