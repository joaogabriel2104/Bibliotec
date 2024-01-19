using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_GriedView.Modelos
{
    internal class Computador
    {
        public int DataUso { get; set; }
        public Usuario Usuario { get; set; }

        public Computador(int datauso, Usuario usuario)
        {
            this.DataUso = datauso;
            this.Usuario = usuario;
        }
    }
}
