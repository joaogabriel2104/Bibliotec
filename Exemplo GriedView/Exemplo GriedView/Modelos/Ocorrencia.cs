using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_GriedView.Modelos
{
    internal class Ocorrencia
    {
        public Usuario Usuario { get; set; }
        public Exemplar Exemplar { get; set; }
        public Livro Livro { get; set; }
        public Emprestimo Emprestimo { get; set; }

    }
}
