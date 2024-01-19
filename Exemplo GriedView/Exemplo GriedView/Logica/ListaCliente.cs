using Exemplo_GriedView.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_GriedView.Logica
{
    internal class ListaCliente
    {
        public string busca { get; set; }
        public List<Usuario> Lista { get; set; }
        public Usuario Usuario1 { get; set; }

        #region Listar Usuarios
        public void Listar()
        {
            Lista = new List<Usuario>();
            Banco banco = new Banco("localhost", "root", "root", "bibliotec");
            banco.Conectar();
            MySqlDataReader dados = banco.Consultar("select U.nm_login, U.nm_usuario, U.nm_senha, U.ic_bloqueado, " +
                "date_format(U.dt_bloqueio, '%d/%m/%Y') as dt_bloqueio, U.cd_tipo_usuario, TU.nm_tipo_usuario from usuario U " +
                "join tipo_usuario TU on(U.cd_tipo_usuario = TU.cd_tipo_usuario) " +
                "where U.nm_usuario like '" + busca + "%' or U.nm_login = '" + busca + "'");

            while(dados.Read())
            {
                string dataBloqueio = null;

                TipoUsuario tipousuario = new TipoUsuario(int.Parse(dados[5].ToString()), dados[6].ToString());

                if (bool.Parse(dados[3].ToString()) == true)
                {
                    dataBloqueio = null;
                }
                else
                {
                    dataBloqueio = dados[4].ToString();
                }

                Usuario usuario = new Usuario(dados[0].ToString(), dados[1].ToString(), dados[2].ToString(), bool.Parse(dados[3].ToString()), dataBloqueio, tipousuario);
                Lista.Add(usuario);
            }
            if (!dados.IsClosed) dados.Close();
            banco.Desconectar();
        }
        #endregion

        #region Nome do Cliente
        public void NomeCli(Usuario Usuario)
        {
            Usuario1 = new Usuario();
            Banco banco = new Banco("localhost", "root", "root", "bibliotec");
            banco.Conectar();
            MySqlDataReader dados = banco.Consultar("select nm_usuario from usuario where nm_login = '" + Usuario.Login + "'");

            dados.Read();
            Usuario1.Nome = dados[0].ToString();

            if (!dados.IsClosed) dados.Close();
            banco.Desconectar();
        }
        #endregion

    }
}
