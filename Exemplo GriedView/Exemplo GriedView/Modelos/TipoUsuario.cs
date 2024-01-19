using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_GriedView.Modelos
{
    public class TipoUsuario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }

        public TipoUsuario(int codigo, string nome)
        {
            this.Codigo = codigo;
            this.Nome = nome;
        }
        public TipoUsuario(int codigo)
        {
            this.Codigo = codigo;
        }
    }
}
