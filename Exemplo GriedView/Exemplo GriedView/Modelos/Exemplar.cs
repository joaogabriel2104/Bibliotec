using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_GriedView.Modelos
{
    public class Exemplar
    {
        public int Codigo { get; set; }
        public string RFID { get; set; }
        public Livro Livro { get; set; }
        public bool Fixo { get; set; }
        public Localizacao Localizacao { get; set; }

        public Exemplar(int codigo, string rfid, Livro livro, bool Fixo, Localizacao localizacao)
        {
            this.Codigo = codigo;
            this.RFID = rfid;
            this.Livro = livro;
            this.Fixo = Fixo;
            this.Localizacao = localizacao;
        }

        public Exemplar(int codigo)
        {
            this.Codigo = codigo;
        }

        public Exemplar()
        {
        }
    }
}
