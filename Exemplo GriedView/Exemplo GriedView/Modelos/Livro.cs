using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo_GriedView.Modelos
{
    public class Livro
    {
        public int Codigo { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public int AnoEdicao { get; set; }
        public string Sinopse { get; set; }
        public Editora Editora { get; set; }
        public List<Autor> Autor { get; set; }
        public List<Categoria> Categoria { get; set; }
        public string Capa { get; set; }

        public Livro(int codigo, string isbn, string titulo, int ano, string sinopse, Editora editora, List<Autor> autor, List<Categoria> categoria, string capa)
        {
            this.Codigo = codigo;
            this.ISBN = isbn;
            this.Titulo = titulo;
            this.AnoEdicao = ano;
            this.Sinopse = sinopse;
            this.Editora = editora;
            this.Autor = autor;
            this.Categoria = categoria;
            this.Capa = capa;
        }
        public Livro(int codigo)
        {
            this.Codigo = codigo;
        }
        public Livro(int codigo, string titulo)
        {
            this.Codigo = codigo;
            this.Titulo = titulo;
        }

        public Livro()
        {
        }
    }
}
