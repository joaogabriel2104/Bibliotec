using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_GriedView.Modelos
{
    public class Localizacao
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }

        public Localizacao(int codigo, string nome)
        {
            this.Codigo = codigo;
            this.Nome = nome;
        }
        public Localizacao(int codigo)
        {
            this.Codigo = codigo;
        }
        public Localizacao()
        {
        }
    }
}
