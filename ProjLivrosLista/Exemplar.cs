using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjLivrosLista
{
    class Exemplar
    {
        private int tombo;
        private List<Emprestimo> emprestimos = new List<Emprestimo>();

        public int Tombo { get => tombo; set => tombo = value; }
        internal List<Emprestimo> Emprestimos { get => emprestimos; set => emprestimos = value; }

        public Exemplar(int tombo, List<Emprestimo> emprestimos)
        {
            this.tombo = tombo;
            this.emprestimos = emprestimos;
        }

        public Exemplar(int tombo)
        {
            this.tombo = tombo;
        }

        public Exemplar()
        {
        }

        public bool emprestar()
        {
            if (disponivel())
            {
                this.emprestimos.Add(new Emprestimo(DateTime.Now));
                return true;
            }

            else
                return false;
        }

        public bool devolver()
        {
            if (disponivel())
                return false;
            else
            {
                this.emprestimos.Last().DtDevolucao = DateTime.Now;
                return true;
            }

        }

        public bool disponivel()
        {
            if (this.emprestimos.Count == 0 || this.emprestimos.Last().DtDevolucao != DateTime.MinValue)
                return true;
            else
                return false;
        }

        public int qtdeEmprestimos()
        {
            int qtde = this.emprestimos.Count;

            return qtde;
        }
    }
}
