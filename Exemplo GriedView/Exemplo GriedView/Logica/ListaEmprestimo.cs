using Exemplo_GriedView.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_GriedView.Logica
{
    internal class ListaEmprestimo
    {
        public List<Emprestimo> ListaEmprestados { get; set; }

        public void Empréstimo(Usuario Usuario, Exemplar Exemplar, Livro Livro, TipoEmprestimo TipoEmprestimo)
        {
            DateTime DataAtual = DateTime.Now;

            Banco banco = new Banco("localhost", "root", "root", "bibliotec");
            banco.Conectar();
            string DataDevolucao = "";
            if (int.Parse(TipoEmprestimo.Codigo.ToString()) == 2)
            {
                DataDevolucao = "date_add(current_date(), interval 14 day)";
            }
            else
            {
                DataDevolucao = "current_date()";
            }

            banco.Inserir("insert into emprestimo (nm_login, cd_exemplar, cd_livro, dt_emprestimo, hr_emprestimo, dt_devolucao_estimada, dt_devolucao, cd_tipo_emprestimo) " +
               "values('" + Usuario.Login + "', " + Exemplar.Codigo + ", " + Livro.Codigo + ", '" + DataAtual.ToString("yyyy-MM-dd") + "', '" + DataAtual.ToString("HH:mm:ss") + "', " + DataDevolucao + ", NULL, " + TipoEmprestimo.Codigo + ")");

            banco.Desconectar();
        }

        #region Livros Emprestados
        public void LivrosEmprestados(string login)
        {
            ListaEmprestados = new List<Emprestimo>();
            Banco banco = new Banco("localhost", "root", "root", "bibliotec");
            banco.Conectar();
            MySqlDataReader dados = banco.Consultar("select EM.nm_login, EM.cd_exemplar, " +
                "EM.cd_livro, date_format(EM.dt_emprestimo, '%d/%m/%Y') as dt_emprestimo, EM.hr_emprestimo, " +
                "date_format(EM.dt_devolucao_estimada, '%d/%m/%Y') as dt_devolucao_estimada, " +
                "EM.dt_devolucao, EM.cd_tipo_emprestimo, TE.nm_tipo_emprestimo, L.nm_livro " +
                "from emprestimo EM join Livro L on(L.cd_livro = EM.cd_livro) join tipo_emprestimo TE " +
                "on(EM.cd_tipo_emprestimo = TE.cd_tipo_emprestimo) " +
                "where nm_login = '" + login + "' and dt_devolucao is null;");

            while (dados.Read())
            {
                Usuario usuario = new Usuario(dados[0].ToString());
                Exemplar exemplar = new Exemplar(int.Parse(dados[1].ToString()));
                Livro livro = new Livro(int.Parse(dados[2].ToString()), dados[9].ToString());
                TipoEmprestimo tipoemprestimo = new TipoEmprestimo(int.Parse(dados[7].ToString()), dados[8].ToString());
                Emprestimo emprestimo = new Emprestimo(usuario, exemplar, livro, dados[3].ToString(), dados[4].ToString(), dados[5].ToString(), dados[6].ToString(), tipoemprestimo);
                ListaEmprestados.Add(emprestimo);
            }

            if (!dados.IsClosed) dados.Close();
            banco.Desconectar();
        }
        #endregion

        #region Livros Emprestados Sem Consulta
        public void LivrosEmprestadosSemConsulta(string login)
        {
            ListaEmprestados = new List<Emprestimo>();
            Banco banco = new Banco("localhost", "root", "root", "bibliotec");
            banco.Conectar();
            MySqlDataReader dados = banco.Consultar("select EM.nm_login, EM.cd_exemplar, " +
                "EM.cd_livro, date_format(EM.dt_emprestimo, '%d/%m/%Y') as dt_emprestimo, EM.hr_emprestimo, " +
                "date_format(EM.dt_devolucao_estimada, '%d/%m/%Y') as dt_devolucao_estimada, " +
                "EM.dt_devolucao, EM.cd_tipo_emprestimo, TE.nm_tipo_emprestimo, L.nm_livro " +
                "from emprestimo EM join Livro L on(L.cd_livro = EM.cd_livro) join tipo_emprestimo TE " +
                "on(EM.cd_tipo_emprestimo = TE.cd_tipo_emprestimo) " +
                "where nm_login = '" + login + "' and dt_devolucao is null and EM.cd_tipo_emprestimo != 1;");

            while (dados.Read())
            {
                Usuario usuario = new Usuario(dados[0].ToString());
                Exemplar exemplar = new Exemplar(int.Parse(dados[1].ToString()));
                Livro livro = new Livro(int.Parse(dados[2].ToString()), dados[9].ToString());
                TipoEmprestimo tipoemprestimo = new TipoEmprestimo(int.Parse(dados[7].ToString()), dados[8].ToString());
                Emprestimo emprestimo = new Emprestimo(usuario, exemplar, livro, dados[3].ToString(), dados[4].ToString(), dados[5].ToString(), dados[6].ToString(), tipoemprestimo);
                ListaEmprestados.Add(emprestimo);
            }

            if (!dados.IsClosed) dados.Close();
            banco.Desconectar();
        }
        #endregion

        #region Livros Emprestados Com Consulta
        public void LivrosEmprestadosComConsulta(string login)
        {
            ListaEmprestados = new List<Emprestimo>();
            Banco banco = new Banco("localhost", "root", "root", "bibliotec");
            banco.Conectar();
            MySqlDataReader dados = banco.Consultar("select EM.nm_login, EM.cd_exemplar, " +
                "EM.cd_livro, date_format(EM.dt_emprestimo, '%d/%m/%Y') as dt_emprestimo, EM.hr_emprestimo, " +
                "date_format(EM.dt_devolucao_estimada, '%d/%m/%Y') as dt_devolucao_estimada, " +
                "EM.dt_devolucao, EM.cd_tipo_emprestimo, TE.nm_tipo_emprestimo, L.nm_livro " +
                "from emprestimo EM join Livro L on(L.cd_livro = EM.cd_livro) join tipo_emprestimo TE " +
                "on(EM.cd_tipo_emprestimo = TE.cd_tipo_emprestimo) " +
                "where nm_login = '" + login + "' and dt_devolucao is null and EM.cd_tipo_emprestimo = 1;");

            while (dados.Read())
            {
                Usuario usuario = new Usuario(dados[0].ToString());
                Exemplar exemplar = new Exemplar(int.Parse(dados[1].ToString()));
                Livro livro = new Livro(int.Parse(dados[2].ToString()), dados[9].ToString());
                TipoEmprestimo tipoemprestimo = new TipoEmprestimo(int.Parse(dados[7].ToString()), dados[8].ToString());
                Emprestimo emprestimo = new Emprestimo(usuario, exemplar, livro, dados[3].ToString(), dados[4].ToString(), dados[5].ToString(), dados[6].ToString(), tipoemprestimo);
                ListaEmprestados.Add(emprestimo);
            }

            if (!dados.IsClosed) dados.Close();
            banco.Desconectar();
        }
        #endregion
    }
}
