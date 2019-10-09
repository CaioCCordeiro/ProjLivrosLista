using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjLivrosLista
{
    class Livro
    {
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares = new List<Exemplar>();

        public int Isbn { get => isbn; set => isbn = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Editora { get => editora; set => editora = value; }
        internal List<Exemplar> Exemplares { get => exemplares; set => exemplares = value; }

        public Livro(int isbn, string titulo, string autor, string editora, List<Exemplar> exemplares)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
            this.exemplares = exemplares;
        }

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
        }

        public Livro(int isbn)
        {
            this.isbn = isbn;
        }

        public Livro()
        {
        }

        public void adicionarExemplar (Exemplar exemplar)
        {
            exemplar.Tombo = exemplares.Count() + 1;
            this.exemplares.Add(exemplar);
            Console.WriteLine("Novo Exemplar adicionado");
        }

        public int qtdeExemplares()
        {
            int qtde = this.exemplares.Count;

            return qtde;
        }

        public int qtdeDisponiveis()
        {
            int qtde = this.exemplares.Where(Exemplar => Exemplar.disponivel()).Count();

            return qtde;
        }

        public int qtdeEmprestimos()
        {
            int qtde = 0;

            foreach(Exemplar exemplar in this.exemplares)
            {
                qtde += exemplar.qtdeEmprestimos();
            }

            return qtde;
        }

        public double percDisponibilidade()
        {
            try
            {
                int perc = (100 * qtdeDisponiveis()) / qtdeExemplares();

                return perc;
            }
            catch(DivideByZeroException)
            {
                return 0;
            }
            
        }
    }
}
