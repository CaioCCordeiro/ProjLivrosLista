using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjLivrosLista
{
    class Livros
    {
        private List<Livro> acervo = new List<Livro>();

        internal List<Livro> Acervo { get => acervo; set => acervo = value; }

        public Livros(List<Livro> acervo)
        {
            this.Acervo = acervo;
        }

        public Livros()
        {
        }

        public void adicionar(Livro livro)
        {
            this.acervo.Add(livro);
        }

        public Livro pesquisar(Livro livro)
        {
            Livro encontrado = new Livro();
            foreach (Livro livrao in this.acervo)
                if (livrao.Isbn.Equals(livro.Isbn))
                    encontrado = livrao;

            return encontrado;
        }
    }
}
