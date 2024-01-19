using Exemplo_GriedView.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_GriedView.Logica
{
    internal class ListaLivro
    {
        public string busca { get; set; }
        public List<Livro> Lista { get; set; }
        public Livro UmLivro { get; set; }
        public List<Exemplar> ListaExemplar { get; set; }
        public Exemplar UmExemplar { get; set; }
        public Livro Livro { get; set; }
        public List<Exemplar> ExemplarDisponivel { get; set; }
        public List<ListaEmprestimo> ListaEmprestimos { get; set; }

        #region Listar Livros
        public void Listar()
        {
            Lista = new List<Livro>();

            Banco banco = new Banco("localhost", "root", "root", "bibliotec");
            banco.Conectar();
            MySqlDataReader dados = banco.Consultar("select l.cd_livro, l.cd_isbn, l.nm_livro, l.aa_edicao, l.ds_sinopse, l.cd_editora, " +
                "E.nm_editora, group_concat(distinct(LA.cd_autor)), group_concat(distinct(A.nm_autor)), " +
                "group_concat(distinct(LC.cd_categoria)), group_concat(distinct(C.nm_categoria)), l.img_capa " +
                "from livro L " +
                "join editora E on (L.cd_editora = E.cd_editora) " +
                "join livro_autor LA on (LA.cd_livro = L.cd_livro) " +
                "join autor A on (LA.cd_autor = A.cd_autor) " +
                "join livro_categoria LC on (LC.cd_livro = L.cd_livro) " +
                "join categoria C on (LC.cd_categoria = C.cd_categoria) " +
                "where L.cd_livro = '" + busca + "' or L.cd_ISBN = '" + busca + "' or L.nm_livro like '" + busca + "%' " +
                "group by cd_livro;");

            while (dados.Read())
            {
                Editora editora = new Editora(int.Parse(dados[5].ToString()), dados[6].ToString());
                List<Autor> ListaAutor = new List<Autor>();
                List<Categoria> categoria = new List<Categoria>();

                if (dados[7].ToString().IndexOf(",") >= 0)
                {
                    string[] Codigos = dados[7].ToString().Split(',');
                    string[] Nomes = dados[8].ToString().Split(',');
                    for (int i = 0; i < Nomes.Length; i++)
                    {
                        Autor autor = new Autor(int.Parse(Codigos[i]), Nomes[i]);
                        ListaAutor.Add(autor);
                    }
                }
                else
                {
                    string Codigo = dados[7].ToString();
                    string Nome = dados[8].ToString();

                    Autor autor = new Autor(int.Parse(Codigo), Nome);
                    ListaAutor.Add(autor);
                }
                Livro livro = new Livro(int.Parse(dados[0].ToString()), dados[1].ToString(), dados[2].ToString(), int.Parse(dados[3].ToString()), dados[4].ToString(), editora, ListaAutor, categoria, null);
                Lista.Add(livro);
            }
            if (!dados.IsClosed) dados.Close();
            banco.Desconectar();
        }
        #endregion

        #region Detalhes
        public void Detalhes()
        {
            Banco banco = new Banco("localhost", "root", "root", "bibliotec");
            banco.Conectar();
            MySqlDataReader dados = banco.Consultar("select l.cd_livro, l.cd_isbn, l.nm_livro, l.aa_edicao, l.ds_sinopse, l.cd_editora, " +
                "E.nm_editora, group_concat(distinct(LA.cd_autor)), group_concat(distinct(A.nm_autor)), " +
                "group_concat(distinct(LC.cd_categoria)), group_concat(distinct(C.nm_categoria)), l.img_capa, " +
                "group_concat(distinct(EX.cd_exemplar)), EX.ic_fixo " +
                "from livro L " +
                "join editora E on (L.cd_editora = E.cd_editora) " +
                "join livro_autor LA on (LA.cd_livro = L.cd_livro) " +
                "join autor A on (LA.cd_autor = A.cd_autor) " +
                "join livro_categoria LC on (LC.cd_livro = L.cd_livro) " +
                "join categoria C on (LC.cd_categoria = C.cd_categoria) " +
                "join Exemplar EX on (L.cd_livro = EX.cd_livro) " +
                "where L.cd_livro = " + Livro.Codigo);

            dados.Read();
            Editora editora = new Editora(int.Parse(dados[5].ToString()), dados[6].ToString());
            List<Autor> ListaAutor = new List<Autor>();
            List<Categoria> ListaCategoria = new List<Categoria>();

            #region Autor
            if (dados[7].ToString().IndexOf(",") >= 0)
            {
                string[] CodigosAutor = dados[7].ToString().Split(',');
                string[] NomesAutor = dados[8].ToString().Split(',');

                for (int i = 0; i < NomesAutor.Length; i++)
                {
                    Autor autor = new Autor(int.Parse(CodigosAutor[i]), NomesAutor[i]);
                    ListaAutor.Add(autor);
                }
            }
            else
            {
                string CodigoAutor = dados[7].ToString();
                string NomeAutor = dados[8].ToString();  

                Autor autor = new Autor(int.Parse(CodigoAutor), NomeAutor);
                ListaAutor.Add(autor);
            }
            #endregion

            #region Categoria
            if (dados[9].ToString().IndexOf(",") >= 0)
            {
                string[] CodigosCategoria = dados[9].ToString().Split(',');
                string[] NomesCategorias = dados[10].ToString().Split(',');
                for (int i = 0; i < NomesCategorias.Length; i++)
                {
                    Categoria categoria = new Categoria(int.Parse(CodigosCategoria[i]), NomesCategorias[i]);
                    ListaCategoria.Add(categoria);
                }
            }
            else
            {
                string CodigoCategoria = dados[9].ToString();
                string NomeCategoria = dados[10].ToString();

                Categoria categoria = new Categoria(int.Parse(CodigoCategoria), NomeCategoria);
                ListaCategoria.Add(categoria);
            }
            #endregion

            Livro livro = new Livro(int.Parse(dados[0].ToString()), dados[1].ToString(), dados[2].ToString(), int.Parse(dados[3].ToString()), dados[4].ToString(), editora, ListaAutor, ListaCategoria, null);

            #region Foto da Capa
            livro.Capa = "";
            if (!String.IsNullOrEmpty(dados[11].ToString()))
            {
                byte[] foto = null;
                foto = (byte[])dados[11];
                string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                livro.Capa = base64String;
            }
            #endregion

            UmLivro = livro;

            if (!dados.IsClosed) dados.Close();
            banco.Desconectar();
        }
        #endregion

        #region Lista Exemplares Disponiveis
        public List<Exemplar> ListaExemplaresDisponiveis(Livro livro)
        {
            List<Exemplar> Lista = new List<Exemplar>();

            Banco banco = new Banco("localhost", "root", "root", "bibliotec");
            banco.Conectar();
            MySqlDataReader dados = banco.Consultar("Select EX.cd_exemplar, EX.cd_livro from exemplar EX " +
                "where EX.cd_livro = " + livro.Codigo + " and " +
                "EX.cd_exemplar not in (select cd_exemplar from emprestimo where cd_livro = " + livro.Codigo + " and dt_devolucao is null)");
            while (dados.Read())
            {
                #region Exemplar
                string[] CodigosExemplares = dados[0].ToString().Split(',');
                for (int i = 0; i < CodigosExemplares.Length; i++)
                {
                    Exemplar exemplar = new Exemplar(int.Parse(CodigosExemplares[i]));
                    Lista.Add(exemplar);
                }
                #endregion
            }

                if (!dados.IsClosed) dados.Close();
            banco.Desconectar();

            return Lista;
        }
        #endregion

        #region Disponibilidade
        public List<Exemplar> Disponibilidade(Livro Livro)
        {
            List<Exemplar> Exemplares = new List<Exemplar>();

            Banco banco = new Banco("localhost", "root", "root", "bibliotec");
            banco.Conectar();
            MySqlDataReader dados = banco.Consultar("select cd_exemplar from exemplar where cd_livro = " + Livro.Codigo);

            while(dados.Read())
            {
                Exemplar exemplar = new Exemplar(int.Parse(dados[0].ToString()));
                Exemplares.Add(exemplar);
            }

            if (!dados.IsClosed) dados.Close();
            banco.Desconectar();

            return Exemplares;
        }
        #endregion

        #region Dados Exemplar
        public void DadosExemplar(Livro Livro, Exemplar Exemplar)
        {
            Banco banco = new Banco("localhost", "root", "root", "bibliotec");
            banco.Conectar();
            MySqlDataReader dados = banco.Consultar("Select EX.cd_exemplar, EX.cd_RFID, EX.cd_livro, EX.ic_fixo, L.cd_localizacao, nm_localizacao from exemplar EX " +
                "join localizacao L on(L.cd_localizacao = EX.cd_localizacao) where cd_livro = " + Livro.Codigo + " and cd_exemplar = " + Exemplar.Codigo);

            dados.Read();

            Livro livro = new Livro(int.Parse(dados[2].ToString()));

            Localizacao localizacao = new Localizacao(int.Parse(dados[4].ToString()), dados[5].ToString());
            Exemplar exemplar = new Exemplar(int.Parse(dados[0].ToString()), dados[1].ToString(), livro, bool.Parse(dados[3].ToString()), localizacao);
            UmExemplar = exemplar;

            if (!dados.IsClosed) dados.Close();
            banco.Desconectar();
        }
        #endregion
    }
}