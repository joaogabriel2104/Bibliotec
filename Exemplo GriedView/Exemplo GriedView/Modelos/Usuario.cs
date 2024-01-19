using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_GriedView.Modelos
{
    public class Usuario
    {
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Bloqueado { get; set; }
        public string DataBloqueio { get; set; }
        public TipoUsuario Tipo {  get; set; }

        public Usuario(string login, string nome, string senha, bool bloqueado, string databloqueio, TipoUsuario tipo)
        {
            this.Login = login;
            this.Nome = nome;
            this.Senha = senha;
            this.Bloqueado = bloqueado;
            this.DataBloqueio = databloqueio;
            this.Tipo = tipo;
        }
        public Usuario(string login, string nome, string senha, bool bloqueado, TipoUsuario tipo)
        {
            this.Login = login;
            this.Nome = nome;
            this.Senha = senha;
            this.Bloqueado = bloqueado;
            this.Tipo = tipo;
        }
        public Usuario(string login)
        {
            this.Login = login;
        }
        public Usuario()
        {
        }

    }
}
