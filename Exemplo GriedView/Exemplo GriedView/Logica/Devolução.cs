using Exemplo_GriedView.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_GriedView.Logica
{
    internal class Devolução
    {
        public List<TipoOcorrencia> ListaTipoOcorrencias = new List<TipoOcorrencia>();
        public Usuario usuario = new Usuario();

        public void Devolucao(Livro Livro, Exemplar Exemplar, Usuario Usuario)
        {
            Banco banco = new Banco("localhost", "root", "root", "bibliotec");
            banco.Conectar();
            banco.Inserir("UPDATE emprestimo SET dt_devolucao = CURRENT_DATE() WHERE cd_livro = " + Livro.Codigo + " AND cd_exemplar = " + Exemplar.Codigo + " AND nm_login = '" + Usuario.Login + "' AND dt_devolucao IS NULL;");

            banco.Desconectar();
        }

        public void TipoOcorrencia()
        {
            Banco banco = new Banco("localhost", "root", "root", "bibliotec");
            banco.Conectar();
            MySqlDataReader dados = banco.Consultar("select cd_tipo_ocorrencia, nm_tipo_ocorrencia from tipo_ocorrencia");

            while(dados.Read())
            {
                TipoOcorrencia tipoOcorrencia = new TipoOcorrencia(int.Parse(dados[0].ToString()), dados[1].ToString());
                ListaTipoOcorrencias.Add(tipoOcorrencia);
            }

            if (!dados.IsClosed) dados.Close();
            banco.Desconectar();
        }

        public void RegistarOcorrencia(string login, int codExemplar, int codLivro, int codTipoOcorrencia, string Descricao, string dataEmprestimo)
        {
            Banco banco = new Banco("localhost", "root", "root", "bibliotec");
            banco.Conectar();
            banco.Inserir("insert into Ocorrencia (nm_login, cd_exemplar, cd_livro, dt_emprestimo, cd_tipo_ocorrencia, ds_ocorrencia) " +
                "values('" + login + "', " + codExemplar + ", " + codLivro + ", '" + dataEmprestimo + "', " + codTipoOcorrencia + ", '" + Descricao + "')");

            banco.Desconectar();
        }
    }
}
