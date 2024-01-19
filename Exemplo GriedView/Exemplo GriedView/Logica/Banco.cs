using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_GriedView.Logica
{
    internal class Banco
    {
        private string linhaConexao { get; set; }
        MySqlConnection conexao = null;
        MySqlCommand cSQL = null;

        public Banco(string host, string user, string senha, string db)
        {
            linhaConexao = "SERVER=" + host + ";UID=" + user + ";PASSWORD=" + senha + ";DATABASE=" + db;
        }

        public void Conectar()
        {
            conexao = new MySqlConnection(linhaConexao);
            try
            {
                conexao.Open();
            }
            catch
            {
                throw new Exception("Não foi possível conectar no Banco de Dados");
            }
        }

        public void Desconectar()
        {
            if (conexao != null)
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }

        public MySqlDataReader Consultar(string comando)
        {
            try
            {
                cSQL = new MySqlCommand(comando, conexao);
                return cSQL.ExecuteReader();
            }
            catch
            {
                throw new Exception("Ocorreu um erro na Consulta. Tente novamente!");
            }
        }

        public void Inserir(string comando)
        {
            try
            {
                cSQL = new MySqlCommand(comando, conexao);
                cSQL.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Ocorreu um erro na inserção. Tente novamente!");
            }
        }
    }
}
