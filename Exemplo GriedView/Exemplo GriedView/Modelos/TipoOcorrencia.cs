using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_GriedView.Modelos
{
    internal class TipoOcorrencia
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }

        public TipoOcorrencia(int codigo, string nome)
        {
            this.Codigo = codigo;
            this.Nome = nome;
        }
    }
}
