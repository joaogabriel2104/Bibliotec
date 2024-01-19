using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_GriedView.Modelos
{
    public class Emprestimo
    {
        public Usuario Usuario { get; set; }
        public Exemplar Exemplar { get; set; }
        public Livro Livro { get; set; }
        public string DataEmprestimo { get; set; }
        public string HoraEmprestimo { get; set; }
        public string DataDevolucaoEstimada { get; set; }
        public string DataDevolucao { get; set; }
        public TipoEmprestimo Tipo { get; set; }

        public Emprestimo(Usuario usuario, Exemplar exemplar, Livro livro, string dataemprestimo, string horaemprestimo, string datadevolucaoestimada, string datadevolucao, TipoEmprestimo tipo)
        {
            this.Usuario = usuario;
            this.Exemplar = exemplar;
            this.Livro = livro;
            this.DataEmprestimo = dataemprestimo;
            this.HoraEmprestimo = horaemprestimo;
            this.DataDevolucaoEstimada = datadevolucaoestimada;
            this.DataDevolucao = datadevolucao;
            this.Tipo = tipo;
        }
        public Emprestimo(Exemplar exemplar, Livro livro, string datadevolucao)
        {
            this.Exemplar = exemplar;
            this.Livro = livro;
            this.DataDevolucao = datadevolucao;
        }

        public Emprestimo()
        {
        }
    }
}
