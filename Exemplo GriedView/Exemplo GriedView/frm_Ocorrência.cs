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
    public partial class frm_Ocorrência : Form
    {
        public Usuario Usuario { get; set; }
        public Livro Livro { get; set; }
        public Exemplar Exemplar { get; set; }
        public Emprestimo Emprestimo { get; set; }
        public frm_Ocorrência()
        {
            InitializeComponent();
        }

        public frm_Ocorrência(Usuario Usuario, Livro Livro, Exemplar Exemplar, Emprestimo Emprestimo)
        {
            InitializeComponent();
            this.Usuario = Usuario;
            this.Livro = Livro;
            this.Exemplar = Exemplar;
            this.Emprestimo = Emprestimo;
        }

        private void frm_Ocorrência_Load(object sender, EventArgs e)
        {
            Devolução devolução = new Devolução();
            devolução.ListaTipoOcorrencias = new List<TipoOcorrencia>();
            devolução.TipoOcorrencia();
            for (int i = 0; i < devolução.ListaTipoOcorrencias.Count; i++)
            {
                cmbTipo.Items.Add(devolução.ListaTipoOcorrencias[i].Nome);
            }
            cmbTipo.SelectedIndex = 0;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Devolução devolução = new Devolução();
            if (cmbTipo.SelectedIndex > 0)
            {
                if (!String.IsNullOrEmpty(txtDescricao.Text))
                {
                    devolução.RegistarOcorrencia(Usuario.Login, Exemplar.Codigo, Livro.Codigo, int.Parse(cmbTipo.SelectedIndex.ToString()), txtDescricao.Text, Emprestimo.DataEmprestimo);
                    MessageBox.Show("Ocorrência registrada com sucesso!");
                    Close();
                }
                else
                {
                    MessageBox.Show("A descrição está vazia!");
                }
            }
            else
            {
                MessageBox.Show("Tipo de ocorrência não identificado!");
            }
        }
    }
}
